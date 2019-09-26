using System;
using IsNumber;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ValidNumberTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            Assert.IsTrue(solution.IsNumber("0"));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();
            Assert.IsTrue(solution.IsNumber(" 0.1 "));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution solution = new Solution();
            Assert.IsFalse(solution.IsNumber("abc"));
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution solution = new Solution();
            Assert.IsFalse(solution.IsNumber("1 a"));
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution solution = new Solution();
            Assert.IsTrue(solution.IsNumber("2e10"));
        }

        [TestMethod]
        public void TestMethod6()
        {
            Solution solution = new Solution();
            Assert.IsTrue(solution.IsNumber(" -90e3   "));
        }

        [TestMethod]
        public void TestMethod7()
        {
            Solution solution = new Solution();
            Assert.IsFalse(solution.IsNumber(" 1e"));
        }

        [TestMethod]
        public void TestMethod8()
        {
            Solution solution = new Solution();
            Assert.IsFalse(solution.IsNumber("e3"));
        }

        [TestMethod]
        public void TestMethod9()
        {
            Solution solution = new Solution();
            Assert.IsTrue(solution.IsNumber(" 6e-1"));
        }

        [TestMethod]
        public void TestMethod10()
        {
            Solution solution = new Solution();
            Assert.IsFalse(solution.IsNumber(" 99e2.5 "));
        }

        [TestMethod]
        public void TestMethod11()
        {
            Solution solution = new Solution();
            Assert.IsTrue(solution.IsNumber("53.5e93"));
        }

        [TestMethod]
        public void TestMethod12()
        {
            Solution solution = new Solution();
            Assert.IsFalse(solution.IsNumber(" --6 "));
        }

        [TestMethod]
        public void TestMethod13()
        {
            Solution solution = new Solution();
            Assert.IsFalse(solution.IsNumber("-+3"));
        }

        [TestMethod]
        public void TestMethod14()
        {
            Solution solution = new Solution();
            Assert.IsFalse(solution.IsNumber("95a54e53"));
        }

        [TestMethod]
        public void TestMethod15()
        {
            Solution solution = new Solution();
            Assert.IsTrue(solution.IsNumber("-.15e-40"));
        }

        [TestMethod]
        public void TestMethod16()
        {
            Solution solution = new Solution();
            Assert.IsTrue(solution.IsNumber("+1.e+40"));
        }
    }
}
