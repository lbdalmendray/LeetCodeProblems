using System;
using System.Linq;
using DiceRollSimulation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiceRollSimulationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // n = 2, rollMax = [1,1,2,2,2,3]
            Solution s = new Solution();
            Assert.AreEqual( s.DieSimulator(2, new int[] { 1, 1, 2, 2, 2, 3 }) , 34) ;
        }

        [TestMethod]
        public void TestMethod2()
        {
            //  n = 2, rollMax = [1,1,1,1,1,1]
            Solution s = new Solution();
            Assert.AreEqual(s.DieSimulator(2, new int[] { 1, 1, 1, 1,1,1 }), 30);
        }

        [TestMethod]
        public void TestMethod3()
        {
            //  n = 3, rollMax = [1,1,1,2,2,3]
            Solution s = new Solution();
            Assert.AreEqual(s.DieSimulator(3, new int[] { 1, 1, 1, 2, 2, 3 }), 181);
        }

        [TestMethod]
        public void TestMethod4()
        {
            //  n = 3, rollMax = [1,1,1,2,2,3]
            Solution s = new Solution();
            Assert.AreEqual(s.DieSimulator(5000, Enumerable.Repeat(15,6).ToArray()), 549903798);
        }

        [TestMethod]
        public void TestMethod5()
        {
            //  n = 3, rollMax = [13,3,12,14,11,11]
            Solution s = new Solution();
            Assert.AreEqual(s.DieSimulator(5000, new int[] { 13, 3, 12, 14, 11, 11 }), 538400505);
        }
    }
}
