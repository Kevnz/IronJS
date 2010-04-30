﻿namespace IronJS.Ast.Types

  open IronJS
  open IronJS.Aliases
  open IronJS.Ast

  type DynamicScopeLevels = {
    Global: int
    Local: int
  } with
    static member New = {
      Global = 0
      Local = 0
    }

  type State = { 
    ScopeChain: Types.Scope list
    DynamicScopeLevels : DynamicScopeLevels list
    FunctionMap : Dict<int, Types.Scope * Node>
  } with
    static member New = {
      ScopeChain = []
      DynamicScopeLevels = [{Global = 0; Local = 0}]
      FunctionMap = null
    }

namespace IronJS.Ast

  open IronJS
  open IronJS.Aliases
  open IronJS.Ast
  open IronJS.Ast.Types

  module State =

    let getActiveScope (ps:Types.State) =
      ps.ScopeChain.Head

    let getParentScopes (ps:Types.State) =
      ps.ScopeChain.Tail

    let getScopeLevel (ps:Types.State) =
      ps.ScopeChain.Length

    let getScopeChain (ps:Types.State) =
      ps.ScopeChain

    let globalDynamicScopeLevel (ps:Types.State) =
      ps.DynamicScopeLevels.Head.Global

    let isInsideLocalDynamicScope (ps:Types.State) =
      ps.DynamicScopeLevels.Head.Local > 0

    let isInsideDynamicScope (ps:Types.State) =
      globalDynamicScopeLevel ps > 0

    let inGlobalScope (ps:Types.State) =
      ps.ScopeChain.Length = 1

    let modifyTopScope sr fn = 
      match getScopeChain !sr with
      | []     -> failwith "Empty scope-chain"
      | fs::tl -> sr := {!sr with ScopeChain = fn fs::tl}

    let enterScope sr (parms:AntlrToken seq) =
      let variables = 
        Seq.mapi (fun i (t:AntlrToken) -> 
          (t.Text, Variable.setParameter {Types.Variable.New with Name = t.Text; Index = i})
        ) parms

      let scope = {
        Types.Scope.New with 
          ScopeLevel  = getScopeLevel !sr;
          Variables = Map.ofSeq variables
      }

      sr := {
        !sr with 
          ScopeChain = (scope :: getScopeChain !sr)
          DynamicScopeLevels = {DynamicScopeLevels.New with Global = globalDynamicScopeLevel !sr} :: (!sr).DynamicScopeLevels
      }

    let exitScope sr =
      match getScopeChain !sr with
      | fs::tl -> sr := {
                    !sr with
                      ScopeChain = tl
                      DynamicScopeLevels = (!sr).DynamicScopeLevels.Tail
                  }

                  fs // return old top-scope

      | _     -> failwith "Couldn't exit scope"

    let enterDynamicScope sr =
        let sh = Scope.setFlag Flags.Scope.HasDS (getActiveScope !sr)
        let ds = (!sr).DynamicScopeLevels
        let sl = ds.Head

        sr := {
          !sr with 
            ScopeChain = sh :: getParentScopes !sr
            DynamicScopeLevels = {sl with Local = sl.Local+1; Global = sl.Global+1} :: ds.Tail
        }

    let exitDynamicScope sr =
        let ds = (!sr).DynamicScopeLevels
        let sl = ds.Head

        sr :=  {
          !sr with 
            DynamicScopeLevels = {sl with Local = sl.Local-1; Global = sl.Global+1} :: ds.Tail
        }

    let createLocal sr name initUndefined =
      if inGlobalScope !sr then ()
      else
        modifyTopScope sr (fun fs ->
          let var  = {Types.Variable.New with Name = name}
          let var' = if initUndefined then Variable.setInitToUndefined var else var
          Scope.setLocal fs name var'
        )

    let getVariable sr name =
      let sl = (!sr).DynamicScopeLevels.Head

      match getScopeChain !sr with
      | x::xs when Scope.hasLocal x name -> Variable(name, sl.Local)
      | x::xs when Scope.hasClosure x name -> Closure(name, sl.Global)
      | _  -> 
        match List.tryFindIndex (fun s -> Scope.hasLocal s name) (!sr).ScopeChain with
        //We found a scope with a Local named 'name'
        | Some(level) -> 
          let rec updateScopes fsList =
            match fsList with
            | []    -> fsList
            | fs::tl -> 
              if Scope.hasLocal fs name 
                then Scope.setClosedOver fs name :: tl
                else Scope.createClosure fs name level :: updateScopes tl

          sr := {!sr with ScopeChain = updateScopes (!sr).ScopeChain}
          Closure(name, sl.Global)

        //Or not, it's a global
        | None -> 
          Global(name, sl.Global)

    let assignedFrom sr name node =
      modifyTopScope sr (fun fs ->
        let lv  = fs.Variables.[name]
        Scope.setLocal fs name {lv with AssignedFrom = node :: lv.AssignedFrom}
      )

    let usedAs sr name typ =
      modifyTopScope sr (fun fs ->
        let lv = fs.Variables.[name]
        Scope.setLocal fs name {lv with UsedAs = lv.UsedAs ||| typ}
      )

    let usedWith sr name rname =
      modifyTopScope sr (fun fs ->
        let lv = fs.Variables.[name]
        Scope.setLocal fs name {lv with UsedWith = lv.UsedWith.Add(rname)}
      )

    let usedWithClosure sr name rname =
      modifyTopScope sr (fun fs ->
        let lv = fs.Variables.[name]
        Scope.setLocal fs name {lv with UsedWithClosure = lv.UsedWithClosure.Add(rname)}
      )
  
    let analyzeAssign sr left right =
    
      match left with
      | Variable(name, _) ->
        match right with
        | Variable(rightName, _) -> 
          if isInsideDynamicScope !sr
            then usedAs sr name Types.Dynamic
            else usedWith sr name rightName

        | Closure(rightName, _) -> 
          if isInsideDynamicScope !sr
            then usedAs sr name Types.Dynamic
            else usedWithClosure sr name rightName

        | _ ->
          match Utils.getNodeType right with
          | Types.Dynamic -> assignedFrom sr name right
          | typ           -> usedAs sr name typ

      | Closure(name, _) ->

        let rec updateScopes sc =
          match sc with
          | [] -> []
          | fs::tl ->
            if Scope.hasLocal fs name
              then let typ = if isInsideDynamicScope !sr 
                               then Types.Dynamic
                               else Utils.getNodeType right
                   let lv  = fs.Variables.[name]
                   let lv' = {lv with UsedAs = lv.UsedAs ||| typ}
                   {fs with Variables = fs.Variables.Add(name, lv')} :: tl
              else fs :: updateScopes tl

        sr := {!sr with ScopeChain = (updateScopes (!sr).ScopeChain)}

      | _ -> ()