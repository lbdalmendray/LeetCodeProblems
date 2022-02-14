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
            Solution2 solution = new Solution2();
            var result = solution.OrangesRotting(new int[][]
            {
                new int[]{2, 1, 1 }
                ,new int[]{0, 1, 1 }
                , new int[]{1, 0, 1 }
            });
            Assert.AreEqual(result, 4);
        }
    }
}
