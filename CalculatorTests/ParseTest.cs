using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalculatorTests
{
    [TestClass]
    public class ParseTest
    {
        [TestMethod]
        public void EnsureICanCreateAnInstance()
        {
            Parse aParse = new Parse();
            Assert.IsNotNull(aParse);
        }

        [TestMethod]
        public void EnsureICanRemoveWhiteSpace()
        {
            Parse aParse = new Parse();
            aParse.ParseInput("8          2     23210 7");
            string expected = "82232107";
            Assert.AreEqual(expected, aParse.ParsedData);
        }

        [TestMethod]
        public void EnsureICanExtractInputTerms()
        {
            // Arrange
            Parse aParse = new Parse();
            int firstTerm = 1;
            int secondTerm = 8;
            // Act
            aParse.ParseInput("1 + 8");
            //var parsedTerms = aParse.Terms;
            Assert.AreEqual(firstTerm.ToString(), aParse.Terms[0]);
            Assert.AreEqual(secondTerm.ToString(), aParse.Terms[1]);
        }

        [TestMethod]
        public void EnsureICanCreateAnInstance2()
        {
            Parse aParse1 = new Parse();
            Assert.IsNotNull(aParse1);
        }
    }
}
