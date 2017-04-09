using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using NUnit.Framework;
using Model;

namespace UnitTests.ModelTests
{
    class InductorTest
    {
        [TestCase(double.MinValue, double.MinValue, double.NaN, double.NaN, TestName = "Couple MinValue")]
        [TestCase(double.MaxValue, double.MaxValue, double.NaN, double.NaN, TestName = "Couple MaxValue")]
        [TestCase(double.NaN, double.NaN, double.NaN, double.NaN, TestName = "Couple NaN")]
        [TestCase(double.NegativeInfinity, double.NegativeInfinity, double.NaN, double.NaN, TestName = "Couple NegativeInfinity")]
        [TestCase(double.PositiveInfinity, double.PositiveInfinity, double.NaN, double.NaN, TestName = "Couple PositiveInfinity")]
        [TestCase(double.NegativeInfinity, double.PositiveInfinity, double.NaN, double.NaN, TestName = "NegativeInfinity frequency and PositiveInfinity value")]
        [TestCase(0, 0, 0, 0, TestName = "Couple 0")]
        [TestCase(10 / Math.PI, 10, 0, 200, TestName = "1 / Math.PI, 10")]
        [TestCase(100 / Math.PI, 100, 0, 20000, TestName = "100 / Math.PI, 100,")]
        [TestCase(1000 / Math.PI, 1000, 0, 2000000, TestName = "1000 / Math.PI, 1000")]
        [TestCase(50000 / Math.PI, 50000, 0, 5000000000, TestName = "Couple 50000")]
        public void InductorZ(double frequency, double iValue, double real, double imaginary)
        {
            Complex result = new Complex(real, imaginary);

            Inductor capacitor = new Inductor("L", iValue);

            Complex z = capacitor.CalculateZ(frequency);

            Assert.AreEqual(result, z);
        }
    }
}
