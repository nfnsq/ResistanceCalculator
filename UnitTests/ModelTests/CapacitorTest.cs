using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Model;
using System.Numerics;

namespace UnitTests.ModelTests
{
    [TestFixture]
    class CapacitorTest
    {
        [TestCase(double.MinValue, double.MinValue, double.NaN, double.NaN, TestName = "Couple MinValue")]
        [TestCase(double.MaxValue, double.MaxValue, double.NaN, double.NaN, TestName = "Couple MaxValue")]
        [TestCase(double.NaN, double.NaN, double.NaN, double.NaN, TestName = "Couple NaN")]
        [TestCase(double.NegativeInfinity, double.NegativeInfinity, double.NaN, double.NaN, TestName = "Couple NegativeInfinity")]
        [TestCase(double.PositiveInfinity, double.PositiveInfinity, double.NaN, double.NaN, TestName = "Couple PositiveInfinity")]
        [TestCase(double.NegativeInfinity, double.PositiveInfinity, double.NaN, double.NaN, TestName = "NegativeInfinity frequency and PositiveInfinity value")]
        [TestCase(0, 0, double.NaN, double.NegativeInfinity, TestName = "Couple 0")]
        [TestCase(10 / Math.PI, 10, 0, -0.005, TestName = "1 / Math.PI, 10")]
        [TestCase(100 / Math.PI, 100, 0, -0.00005, TestName = "100 / Math.PI, 100,")]
        [TestCase(1000 / Math.PI, 1000, 0, -0.0000005, TestName = "1000 / Math.PI, 1000")]
        [TestCase(50000 / Math.PI, 50000, 0, -0.0000000002, TestName = "Couple 50000")]
        public void CapacitorZ(double frequency, double cValue,  double real, double imaginary)
        {
            Complex result = new Complex(real, imaginary);

            Capacitor capacitor = new Capacitor("C", cValue);

            Complex z = capacitor.CalculateZ(frequency);

            Assert.AreEqual(result, z);
        }
    }
}
