// <auto-generated />
namespace IronJS.Tests.UnitTests.Sputnik.Conformance.NativeECMAScriptObjects.RegExpObjects.PropertiesOfTheRegExpPrototypeObject
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class RegExpPrototypeTestTests : SputnikTestFixture
    {
        public RegExpPrototypeTestTests()
            : base(@"Conformance\15_Native_ECMA_Script_Objects\15.10_RegExp_Objects\15.10.6_Properties_of_the_RegExp_Prototype_Object\15.10.6.3_RegExp.prototype.test")
        {
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 15.10.6.3")]
        [TestCase("S15.10.6.3_A1_T1.js", Description = "Equivalent to the expression RegExp.prototype.exec(string) != null")]
        [TestCase("S15.10.6.3_A1_T10.js", Description = "Equivalent to the expression RegExp.prototype.exec(string) != null")]
        [TestCase("S15.10.6.3_A1_T11.js", Description = "Equivalent to the expression RegExp.prototype.exec(string) != null")]
        [TestCase("S15.10.6.3_A1_T12.js", Description = "Equivalent to the expression RegExp.prototype.exec(string) != null")]
        [TestCase("S15.10.6.3_A1_T13.js", Description = "Equivalent to the expression RegExp.prototype.exec(string) != null")]
        [TestCase("S15.10.6.3_A1_T14.js", Description = "Equivalent to the expression RegExp.prototype.exec(string) != null")]
        [TestCase("S15.10.6.3_A1_T15.js", Description = "Equivalent to the expression RegExp.prototype.exec(string) != null")]
        [TestCase("S15.10.6.3_A1_T16.js", Description = "Equivalent to the expression RegExp.prototype.exec(string) != null")]
        [TestCase("S15.10.6.3_A1_T17.js", Description = "Equivalent to the expression RegExp.prototype.exec(string) != null")]
        [TestCase("S15.10.6.3_A1_T18.js", Description = "Equivalent to the expression RegExp.prototype.exec(string) != null")]
        [TestCase("S15.10.6.3_A1_T19.js", Description = "Equivalent to the expression RegExp.prototype.exec(string) != null")]
        [TestCase("S15.10.6.3_A1_T2.js", Description = "Equivalent to the expression RegExp.prototype.exec(string) != null")]
        [TestCase("S15.10.6.3_A1_T20.js", Description = "Equivalent to the expression RegExp.prototype.exec(string) != null")]
        [TestCase("S15.10.6.3_A1_T21.js", Description = "Equivalent to the expression RegExp.prototype.exec(string) != null")]
        [TestCase("S15.10.6.3_A1_T3.js", Description = "Equivalent to the expression RegExp.prototype.exec(string) != null")]
        [TestCase("S15.10.6.3_A1_T4.js", Description = "Equivalent to the expression RegExp.prototype.exec(string) != null")]
        [TestCase("S15.10.6.3_A1_T5.js", Description = "Equivalent to the expression RegExp.prototype.exec(string) != null")]
        [TestCase("S15.10.6.3_A1_T6.js", Description = "Equivalent to the expression RegExp.prototype.exec(string) != null")]
        [TestCase("S15.10.6.3_A1_T7.js", Description = "Equivalent to the expression RegExp.prototype.exec(string) != null")]
        [TestCase("S15.10.6.3_A1_T8.js", Description = "Equivalent to the expression RegExp.prototype.exec(string) != null")]
        [TestCase("S15.10.6.3_A1_T9.js", Description = "Equivalent to the expression RegExp.prototype.exec(string) != null")]
        public void EquivalentToTheExpressionRegExpPrototypeExecStringNull(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 15.10.6.3")]
        [TestCase("S15.10.6.3_A10.js", Description = "The RegExp.prototype.test.length property has the attribute ReadOnly")]
        public void TheRegExpPrototypeTestLengthPropertyHasTheAttributeReadOnly(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 15.10.6.3")]
        [TestCase("S15.10.6.3_A11.js", Description = "The length property of the test method is 1")]
        public void TheLengthPropertyOfTheTestMethodIs1(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 15.10.6.3")]
        [TestCase("S15.10.6.3_A2_T1.js", Description = "A TypeError exception is thrown if the this value is not an object for which the value of the internal [[Class]] property is \"RegExp\"")]
        [TestCase("S15.10.6.3_A2_T10.js", Description = "A TypeError exception is thrown if the this value is not an object for which the value of the internal [[Class]] property is \"RegExp\"")]
        [TestCase("S15.10.6.3_A2_T2.js", Description = "A TypeError exception is thrown if the this value is not an object for which the value of the internal [[Class]] property is \"RegExp\"")]
        [TestCase("S15.10.6.3_A2_T3.js", Description = "A TypeError exception is thrown if the this value is not an object for which the value of the internal [[Class]] property is \"RegExp\"")]
        [TestCase("S15.10.6.3_A2_T4.js", Description = "A TypeError exception is thrown if the this value is not an object for which the value of the internal [[Class]] property is \"RegExp\"")]
        [TestCase("S15.10.6.3_A2_T5.js", Description = "A TypeError exception is thrown if the this value is not an object for which the value of the internal [[Class]] property is \"RegExp\"")]
        [TestCase("S15.10.6.3_A2_T6.js", Description = "A TypeError exception is thrown if the this value is not an object for which the value of the internal [[Class]] property is \"RegExp\"")]
        [TestCase("S15.10.6.3_A2_T7.js", Description = "A TypeError exception is thrown if the this value is not an object for which the value of the internal [[Class]] property is \"RegExp\"")]
        [TestCase("S15.10.6.3_A2_T8.js", Description = "A TypeError exception is thrown if the this value is not an object for which the value of the internal [[Class]] property is \"RegExp\"")]
        [TestCase("S15.10.6.3_A2_T9.js", Description = "A TypeError exception is thrown if the this value is not an object for which the value of the internal [[Class]] property is \"RegExp\"")]
        public void ATypeErrorExceptionIsThrownIfTheThisValueIsNotAnObjectForWhichTheValueOfTheInternalClassPropertyIsRegExp(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 13.2")]
        [Category("ECMA 15.10.6.3")]
        [TestCase("S15.10.6.3_A6.js", Description = "RegExp.prototype.test has not prototype property")]
        public void RegExpPrototypeTestHasNotPrototypeProperty(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 13.2")]
        [Category("ECMA 15.10.6.3")]
        [TestCase("S15.10.6.3_A7.js", Description = "RegExp.prototype.test can\'t be used as constructor")]
        public void RegExpPrototypeTestCanTBeUsedAsConstructor(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 15.10.6.3")]
        [TestCase("S15.10.6.3_A8.js", Description = "The RegExp.prototype.test.length property has the attribute DontEnum")]
        public void TheRegExpPrototypeTestLengthPropertyHasTheAttributeDontEnum(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 15.10.6.3")]
        [TestCase("S15.10.6.3_A9.js", Description = "The RegExp.prototype.test.length property has the attribute DontDelete")]
        public void TheRegExpPrototypeTestLengthPropertyHasTheAttributeDontDelete(string file)
        {
            RunFile(file);
        }
    }
}