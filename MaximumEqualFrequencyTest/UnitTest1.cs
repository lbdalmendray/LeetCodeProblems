using System;
using MaximumEqualFrequency;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaximumEqualFrequencyTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            Assert.AreEqual(s.MaxEqualFreq(new int[] { 1,2,3,5,1} ), 5);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            Assert.AreEqual(s.MaxEqualFreq(new int[] { 1, 2, 3, 5, 1 ,1,1,1,1,1,1,1 }), 5);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            Assert.AreEqual(s.MaxEqualFreq(new int[] { 2, 2, 1, 1, 5, 3, 3, 5 }), 7);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            Assert.AreEqual(s.MaxEqualFreq(new int[] { 1, 1, 1, 2, 2, 2 }), 5);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            Assert.AreEqual(s.MaxEqualFreq(new int[] { 10, 2, 8, 9, 3, 8, 1, 5, 2, 3, 7, 6 }), 8);
        }

        [TestMethod]
        public void TestMethod6()
        {
            Solution s = new Solution();
            Assert.AreEqual(s.MaxEqualFreq(new int[] { 4,4,4,4,4,4,4,4 }), 8);
        }

        [TestMethod]
        public void TestMethod7()
        {
            Solution s = new Solution();
            Assert.AreEqual(s.MaxEqualFreq(new int[] { 1,2,3,4,5,5,4,3,2,1,6 }), 11);
        }

        [TestMethod]
        public void TestMethod8()
        {
            Solution s = new Solution();
            Assert.AreEqual(s.MaxEqualFreq(new int[] { 1, 2, 3, 4, 5, 6, 5, 4, 3, 2, 8 }), 7);
        }

        [TestMethod]
        public void TestMethod9()
        {
            Solution s = new Solution();
            Assert.AreEqual(s.MaxEqualFreq(new int[] { 1}), 1);
        }

        [TestMethod]
        public void TestMethod10()
        {
            Solution s = new Solution();
            Assert.AreEqual(s.MaxEqualFreq(new int[] {  }), 0);
        }

        /// 10,2,8,9,3,8,1,5,2,3,7,6
    }

}
