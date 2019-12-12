using System;
using System.Collections.Generic;
using System.Text;
using XUNITExample_1;
using Xunit;
using Xunit.Abstractions;
using System.IO;

namespace Calculation.Tests
{

    public class CalculatorFixture : IDisposable
    {
        public Calculator Calc => new Calculator();

        public void Dispose()
        {
            //could put disposable things here
        }
    }
    //IClassFixture allows us to pass a fixture into the interface and create a single instance 
    //of claculator for all tests
    public class CalculatorTests : IClassFixture<CalculatorFixture>, IDisposable
    {
        //helps by being able to write test outputs
        private readonly ITestOutputHelper _testOutputHelper;
        //instance of our calcualator helper
        private readonly CalculatorFixture _calculatorFixture;


        private readonly MemoryStream _memoryStream;


        //injects a singleton instance of calculator fixutre into 
        public CalculatorTests(ITestOutputHelper testOutputHelper, CalculatorFixture calculatorFixture)
        {
            this._calculatorFixture = calculatorFixture;
            this._testOutputHelper = testOutputHelper;
            testOutputHelper.WriteLine("Constructor");

            _memoryStream = new MemoryStream();
        }

        //xunit fact annotation
        //also used for traits to link tests together.
        [Fact]
        [Trait("Category", "BaseValueCheck")]

        public void Add_GivenTwoIntValues_ReturnsInt()
        {
            _testOutputHelper.WriteLine("in top of add_givetwoIntvalues");
            var calc = _calculatorFixture.Calc;
            var result = calc.Add(1, 2);
            Assert.Equal(3, result);
        }

        [Fact]
        [Trait("Category", "BaseValueCheck")]
        public void Add_GivenTwoDoubleValues_ReturnsDouble()
        {
            _testOutputHelper.WriteLine("in returns double");
            var doublecalc = new Calculator();
            var result = doublecalc.addDouble(1.23, 3.55);
            Assert.Equal(4.7, result, 0);
        }

        public void Dispose()
        {
            _memoryStream.Close();
        }
    }
}
