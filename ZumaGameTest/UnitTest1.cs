using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZumaGame;

namespace ZumaGameTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.FindMinStep("WRRBBW", "RB");

            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.FindMinStep("WWRRBBWW", "WRBRW");
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.FindMinStep("G", "GGGGG");
            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            var result = s.FindMinStep("RBYYBBRRB", "YRBGB");
            Assert.AreEqual(result, 3);
        }

        
       /* [TestMethod]
        public void TestMethodLong()
        {
            Solution s = new Solution();
            var result = s.FindMinStep("RWGBYRWGBYRWGBYRWGBY", "RRRRRRRRWWWWWWWWGGGGGGGGBBBBBBBBYYYYYYYY");
            Assert.AreEqual(result, 40);
        }
        */
        

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            var result = s.FindMinStep("WYRWBRWWRRBBWWRRYYWW", "RW");
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod6()
        {
            Solution s = new Solution();
            var result = s.FindMinStep("WWBBW", "B");
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod7()
        {
            Solution s = new Solution();
            var result = s.FindMinStep("WWBBW", "YWRB");
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod8()
        {
            Solution s = new Solution();
            var result = s.FindMinStep("RWWRR", "RW");
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod9()
        {
            Solution s = new Solution();
            var result = s.FindMinStep("BWRRWWBB", "WR");
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod10()
        {
            Solution s = new Solution();
            var result = s.FindMinStep("RWGBYRWGBYRWGBYRWGBY", "RWBGY");
            Assert.AreEqual(result, -1);
        }

        [TestMethod]
        public void TestMethod11()
        {
            Solution s = new Solution();
            var result = s.FindMinStep("RRBBGGWWY", "RWBGY");
            Assert.AreEqual(result, -1);
        }
        [TestMethod]
        public void TestMethod12()
        {
            Solution s = new Solution();
            var result = s.FindMinStep("RRBBGGWWYY", "RWBGY");
            Assert.AreEqual(result, 5);
        }

        [TestMethod]
        public void TestMethod13()
        {
            Solution s = new Solution();
            var result = s.FindMinStep("WYRWBRWWRRBBWWRRYYWW", "RYGBW");
            Assert.AreEqual(result, 1);
        }
        [TestMethod]
        public void TestMethod14()
        {
            Solution s = new Solution();
            var result = s.FindMinStep("WYRWBRRWWRRBBWWRRYYWW", "RYGBW");
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestMethod15()
        {
            Solution s = new Solution();
            var result = s.FindMinStep("WYWBRBWYYW", "BRRWW");
            Assert.AreEqual(result, 5);
        }
    }
}
