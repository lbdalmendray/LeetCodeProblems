using System;
using System.Linq;
using DecodeWaysII;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DecodeWaysIITest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.NumDecodings("*");
            Assert.AreEqual(result, 9);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.NumDecodings("1*");
            Assert.AreEqual(result, 18);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            for (int i = 1; i < 10; i++)
            {
                var result = s.NumDecodings(i.ToString());
                Assert.AreEqual(result, 1);
            }            
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            for (int i = 1; i < 7; i++)
            {
                var result = s.NumDecodings("*" + i.ToString());
                Assert.AreEqual(result, 11);
            }
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            var result = s.NumDecodings("**");
            Assert.AreEqual(result, 96);
        }

        [TestMethod]
        public void TestMethod6()
        {
            Solution s = new Solution();
            var result = s.NumDecodings("***");
            Assert.AreEqual(result, 9*96 + (9+6)*9);
        }

        [TestMethod]
        public void TestMethod7()
        {
            Solution s = new Solution();
            var result = s.NumDecodings(new string(Enumerable.Repeat('1',100000).ToArray()));
            Assert.AreEqual(result, 967618232);
        }

        [TestMethod]
        public void TestMethod8()
        {
            Solution s = new Solution();
            var result = s.NumDecodings(new string(Enumerable.Repeat('*', 100000).ToArray()));
            Assert.AreEqual(result, 81890275);
        }

        [TestMethod]
        public void TestMethod9()
        {
            Solution s = new Solution();
            var result = s.NumDecodings("10");
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod10()
        {
            Solution s = new Solution();
            var result = s.NumDecodings("101010100000010");
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestMethod11()
        {
            Solution s = new Solution();
            var result = s.NumDecodings("00000000000");
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestMethod12()
        {
            Solution s = new Solution();
            var result = s.NumDecodings("10101010101010");
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod13()
        {
            Solution s = new Solution();
            var result = s.NumDecodings("010101010101010");
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestMethod14()
        {
            Solution s = new Solution();
            var result = s.NumDecodings("204");
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod15()
        {
            Solution s = new Solution();
            var result = s.NumDecodings("10101010301010");
            Assert.AreEqual(result, 0);
        }
    }
}
