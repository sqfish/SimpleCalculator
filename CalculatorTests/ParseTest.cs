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
        public void EnsureICanRemoveInappropriateWhiteSpace()
        {
            Parse aParse = new Parse();
            aParse.ParseInput("8          2     +23210 7     ");
            string expected = "82 + 232107";
            Assert.AreEqual(expected, aParse.Expression);
        }

        [TestMethod]
        public void EnsureICanExtractInputTerms()
        {
            // Arrange
            Parse aParse = new Parse();
            string firstTerm = "1";
            string secondTerm = "8";
            // Act
            aParse.ParseInput("1 + 8");
            // Assert
            Assert.AreEqual(firstTerm, aParse.Terms[0]);
            Assert.AreEqual(secondTerm, aParse.Terms[1]);
        }

        [TestMethod]
        public void EnsureICanExtractOperator()
        {
            // Arrange
            Parse aParse = new Parse();
            string anOperator = "*";
            // Act
            aParse.ParseInput("5 * 2");
            // Assert
            Assert.AreEqual(anOperator, aParse.Operator);
        }

        [TestMethod]
        public void EnsureICanParseInputWithFirstTermNegative()
        {
            // Arrange
            Parse aParse = new Parse();
            string anInput = "-1 + 1";
            int firstTermExpected = -1;
            int secondTermExpected = 1;
            string operatorExpected = "+";
            int firstTermActual;
            int secondTermActual;
            // Act
            aParse.ParseInput(anInput);
            int.TryParse(aParse.Terms[0], out firstTermActual);
            int.TryParse(aParse.Terms[1], out secondTermActual);
            // Assert
            Assert.AreEqual(firstTermExpected, firstTermActual);
            Assert.AreEqual(secondTermExpected, secondTermActual);
            Assert.AreEqual(operatorExpected, aParse.Operator);
        }

        [TestMethod]
        public void EnsureICanParseInputWithSecondTermNegative()
        {
            // Arrange
            Parse aParse = new Parse();
            string anInput = "1 + -1";
            int firstTermExpected = 1;
            int secondTermExpected = -1;
            string operatorExpected = "+";
            int firstTermActual;
            int secondTermActual;
            // Act
            aParse.ParseInput(anInput);
            int.TryParse(aParse.Terms[0], out firstTermActual);
            int.TryParse(aParse.Terms[1], out secondTermActual);
            // Assert
            Assert.AreEqual(firstTermExpected, firstTermActual);
            Assert.AreEqual(secondTermExpected, secondTermActual);
            Assert.AreEqual(operatorExpected, aParse.Operator);
        }

        [TestMethod]
        public void EnsureValidInputIsValidated()
        {
            Parse aParse = new Parse();
            Assert.AreEqual(true, aParse.ValidateInput("11 + 3"));
            Assert.AreEqual(true, aParse.ValidateInput("3 - 23"));
            Assert.AreEqual(true, aParse.ValidateInput("3 + -2"));
            Assert.AreEqual(true, aParse.ValidateInput("3 + +2"));
            Assert.AreEqual(true, aParse.ValidateInput("-13 + 3"));
            Assert.AreEqual(true, aParse.ValidateInput("3 - 20"));
            Assert.AreEqual(true, aParse.ValidateInput("-3 - 3"));
            Assert.AreEqual(true, aParse.ValidateInput("-3 - -3"));
            Assert.AreEqual(true, aParse.ValidateInput("1 * 3"));
            Assert.AreEqual(true, aParse.ValidateInput("3-2"));
            Assert.AreEqual(true, aParse.ValidateInput("3 + -2"));
            Assert.AreEqual(true, aParse.ValidateInput("3 + +2"));
            Assert.AreEqual(true, aParse.ValidateInput("-1 + 3"));
            Assert.AreEqual(true, aParse.ValidateInput("3 / 0"));
            Assert.AreEqual(true, aParse.ValidateInput("-3 - 3"));
            Assert.AreEqual(true, aParse.ValidateInput("-3 * -3"));
        }

        [TestMethod]
        public void EnsureInvalidInputIsInvalidated()
        {
            Parse aParse = new Parse();
            Assert.AreEqual(false, aParse.ValidateInput("13 + - 3"));
            Assert.AreEqual(false, aParse.ValidateInput("2 - - 3"));
            Assert.AreEqual(false, aParse.ValidateInput("-2 +- 3"));
            Assert.AreEqual(false, aParse.ValidateInput("- 1*3"));
            Assert.AreEqual(false, aParse.ValidateInput("2- - 1"));
            Assert.AreEqual(false, aParse.ValidateInput("+1+ - 2"));
            Assert.AreEqual(false, aParse.ValidateInput("-3/- 32"));
            Assert.AreEqual(false, aParse.ValidateInput("3 + - 3"));
            Assert.AreEqual(false, aParse.ValidateInput("20 - - 32"));
            //Assert.AreEqual(false, aParse.ValidateInput("-2 +/ 3"));
            Assert.AreEqual(false, aParse.ValidateInput("- 1*3"));
            Assert.AreEqual(false, aParse.ValidateInput("2- - 1"));
            Assert.AreEqual(false, aParse.ValidateInput("+1+ - 2"));
            Assert.AreEqual(false, aParse.ValidateInput("-3/- 2"));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void EnsureInvalidInputThrowsAnError()
        {
            // Arrange
            Parse aParse = new Parse();
            string anInput = "1 + - 1";
            aParse.ParseInput(anInput);
        }
    }
}
