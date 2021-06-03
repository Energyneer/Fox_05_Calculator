using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Task5;

namespace Task5test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSimpleExp()
        {
            Assert.AreEqual(-1M, MathParser.ParseSimpleExp("1+3-2*5/2"));
        }

        [TestMethod]
        public void TestSimpleExpWithSpaces()
        {
            Assert.AreEqual(6M, MathParser.ParseSimpleExp(" 9  + 7   - 5 * 8/    4"));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException), "")]
        public void TestIncorrect()
        {
            MathParser.ParseSimpleExp("2x + 3y");
        }

        [TestMethod]
        public void TestExtendedExp1()
        {
            Assert.AreEqual(5M, MathParser.ParseSimpleExp("1 + (20 * (5 - 2) / 15)"));
        }

        [TestMethod]
        public void TestExtendedExp2()
        {
            Assert.AreEqual(31M, MathParser.ParseSimpleExp("1 + (7 - 3) * (5 + (9 / 3) - 1) + 2"));
        }

        [TestMethod]
        public void TestExtendedExp3()
        {
            Assert.AreEqual(146.75M, MathParser.ParseSimpleExp("2,5 + 5 * ((7,25 * 2) / (0,8 - 0,3)) - 0,75"));
        }
    }
}
