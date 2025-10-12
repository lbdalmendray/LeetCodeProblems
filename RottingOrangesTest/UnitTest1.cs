using Microsoft.VisualStudio.TestTools.UnitTesting;
using RottingOranges;

namespace RottingOrangesTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            var result = solution.OrangesRotting(new int[][]
            {
                 new int[]{ 2, 1, 1}
                ,new int[]{ 1, 1, 0}
                ,new int[]{ 0, 1, 1}
            });
            Assert.AreEqual(result, 4);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();
            var result = solution.OrangesRotting(new int[][]
            {
                new int[]{2, 1, 1 }
                ,new int[]{0, 1, 1 }
                , new int[]{1, 0, 1 }
            });
            Assert.AreEqual(result, -1);
        }
        [TestMethod]
        public void TestMethod3()
        {
            Solution solution = new Solution();
            var result = solution.OrangesRotting(new int[][]
            {
                new int[]{0,2 }
            });
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution solution = new Solution();
            var result = solution.OrangesRotting(new int[][]
            {
                new int[]{2, 2, 2 }
                ,new int[]{0, 2, 2 }
                , new int[]{2, 0, 2 }
            });
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution solution = new Solution();
            var result = solution.OrangesRotting(new int[][]
            {
                new int[]{1, 1, 1 }
                ,new int[]{0, 1, 1 }
                , new int[]{1, 0, 1 }
            });
            Assert.AreEqual(result, -1);
        }
    }
}
