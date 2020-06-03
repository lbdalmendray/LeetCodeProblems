using System;
using BasicCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasicCalculatorTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.Calculate("1 + 1");
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.Calculate(" 2-1 + 2 ");
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.Calculate("(1+(4+5+2)-3)+(6+8)");
            Assert.AreEqual(result, 23);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            var result = s.Calculate("-1+1");
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            var result = s.Calculate("-1+1");
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestMethod6()
        {
            Solution s = new Solution();
            var result = s.Calculate("(+1+(+4+5+2)-3)+(+6+8)");
            Assert.AreEqual(result, 23);
        }
    }
}
