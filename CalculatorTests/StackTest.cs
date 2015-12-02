using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace CalculatorTests
{
    [TestClass]
    public class StackTest
    {
        [TestMethod]
        public void EnsureICanCreateInstance()
        {
            Stack stack = new Stack();
            stack.Update(null, null);
            Assert.IsNotNull(stack);
        }

        [TestMethod]
        public void EnsureICanManuallyStoreLastIn()
        {
            string input = "8 * -2";
            Stack stack = new Stack();
            stack.Update(input, null);
            var actual = stack.LastIn;
            Assert.AreEqual(input, actual);
        }

        [TestMethod]
        public void EnsureICanManuallyStoreLastOut()
        {
            string result = "-12";
            Stack stack = new Stack();
            stack.Update(null, result);
            var actual = stack.LastOut;
            Assert.AreEqual(result, actual);
        }
    }

    [TestClass]
    public class EvaluateAndStackTest
    {
        [TestMethod]
        public void EnsureEvaluateCanReturnLastIn()
        {
            string expected = "-8 * 9";
            Evaluate evaluate = new Evaluate();
            evaluate.Input(expected);
            string actual = evaluate.LastIn;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EnsureEvaluateCanReturnLastOut()
        {
            string input = "-8 * 9";
            Evaluate evaluate = new Evaluate();
            evaluate.Input(input);
            string expected = evaluate.Result;
            string actual = evaluate.LastOut;
            Assert.AreEqual(expected, actual);
        }
    }
}