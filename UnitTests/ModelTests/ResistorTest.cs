using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Numerics;
using NUnit.Framework;

namespace UnitTests.ModelTests
{
    [TestFixture]
    class ResistorTest
    {
        [TestCase(double.MinValue, double.MinValue, 0, 0, TestName = "Couple MinValue")]
        [TestCase(double.MaxValue, double.MaxValue, 0, 0, TestName = "Couple MaxValue")]
        [TestCase(double.NaN, double.NaN, 0, 0, TestName = "Couple NaN")]
        [TestCase(double.NegativeInfinity, double.NegativeInfinity, 0, 0, TestName = "Couple NegativeInfinity")]
        [TestCase(double.PositiveInfinity, double.PositiveInfinity, 0, 0, TestName = "Couple PositiveInfinity")]
        [TestCase(double.NegativeInfinity, double.PositiveInfinity, 0, 0, TestName = "NegativeInfinity frequency and PositiveInfinity value")]
        [TestCase(0, 0, 0, 0, TestName = "Couple 0")]
        [TestCase(10 / Math.PI, 10, 10, 0, TestName = "1 / Math.PI, 10")]
        [TestCase(100 / Math.PI, 100, 100, 0, TestName = "100 / Math.PI, 100,")]
        [TestCase(1000 / Math.PI, 1000, 1000, 0, TestName = "1000 / Math.PI, 1000")]
        [TestCase(50000 / Math.PI, 50000, 50000, 0, TestName = "50000 / Math.PI, 50000,")]
        public void InductorZ(double frequency, double rValue, double real, double imaginary)
        {
            Complex result = new Complex(real, imaginary);

            Factory f = Factory.GetFactory('R');
            Resistor resistor = (Resistor)f.CreateElement(rValue);

            Complex z = resistor.CalculateZ(frequency);

            Assert.AreEqual(result, z);
        }
    }
}
