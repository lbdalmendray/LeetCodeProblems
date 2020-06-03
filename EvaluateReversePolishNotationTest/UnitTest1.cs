using System;
using EvaluateReversePolishNotation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvaluateReversePolishNotationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.EvalRPN(new string[] { "2", "1", "+", "3", "*" });
            Assert.AreEqual(result, 9);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.EvalRPN(new string[] { "4", "13", "5", "/", "+" });
            Assert.AreEqual(result, 6);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.EvalRPN(new string[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" });
            Assert.AreEqual(result, 22);
        }
    }

}
