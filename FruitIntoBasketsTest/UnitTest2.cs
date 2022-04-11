using FruitIntoBaskets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FruitIntoBasketsTest
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution2 s = new Solution2();
            var result = s.TotalFruit(new int[] { 1, 2, 1 });
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution2 s = new Solution2();
            var result = s.TotalFruit(new int[] { 0, 1, 2, 2 });
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution2 s = new Solution2();
            var result = s.TotalFruit(new int[] { 1, 2, 3, 2, 2 });
            Assert.AreEqual(result, 4);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution2 s = new Solution2();
            var result = s.TotalFruit(new int[] { 3, 3, 3, 1, 2, 1, 1, 2, 3, 3, 4 });
            Assert.AreEqual(result, 5);
        }
    }
}
