// <auto-generated />
namespace IronJS.Tests.UnitTests.Sputnik.Conformance.NativeECMAScriptObjects.TheMathObject.FunctionPropertiesOfTheMathObject
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class SinTests : SputnikTestFixture
    {
        public SinTests()
            : base(@"Conformance\15_Native_ECMA_Script_Objects\15.8_The_Math_Object\15.8.2_Function_Properties_of_the_Math_Object\15.8.2.16_sin")
        {
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 15.8.2.16")]
        [TestCase("S15.8.2.16_A1.js", Description = "If x is NaN, Math.sin(x) is NaN")]
        public void IfXIsNaNMathSinXIsNaN(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 15.8.2.16")]
        [TestCase("S15.8.2.16_A2.JS", Description = "If x is +0, Math.sin(x) is +0")]
        [TestCase("S15.8.2.16_A3.js", Description = "If x is -0, Math.sin(x) is -0")]
        public void IfXIs0MathSinXIs0(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 15.8.2.16")]
        [TestCase("S15.8.2.16_A4.js", Description = "If x is +Infinity, Math.sin(x) is NaN")]
        [TestCase("S15.8.2.16_A5.js", Description = "If x is -Infinity, Math.sin(x) is NaN")]
        public void IfXIsInfinityMathSinXIsNaN(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 15.8.2.16")]
        [TestCase("S15.8.2.16_A6.js", Description = "Sine is a periodic function with period 2*PI")]
        public void SineIsAPeriodicFunctionWithPeriod2PI(string file)
        {
            RunFile(file);
        }

        [Test]
        [Category("Sputnik Conformance")]
        [Category("ECMA 15.8.2.16")]
        [TestCase("S15.8.2.16_A7.js", Description = "Math.sin it is recommended that implementations use the approximation algorithms for IEEE 754 arithmetic contained in fdlibm")]
        public void MathSinItIsRecommendedThatImplementationsUseTheApproximationAlgorithmsForIEEE754ArithmeticContainedInFdlibm(string file)
        {
            RunFile(file);
        }
    }
}