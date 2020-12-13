using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidTriangleNumber;

namespace ValidTriangleNumberTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result =  s.TriangleNumber(new int[] { 2, 2, 3, 4 });
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.TriangleNumber(new int[] { 1,2,3,4,5 });
            Assert.AreEqual(result, 1+1+1);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.TriangleNumber(new int[] { 1,1, 2, 3, 4, 5 });
            Assert.AreEqual(result, 1 + 1 + 1);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            var result = s.TriangleNumber(new int[] { 1, 1, 2, 3, 4, 5,5,5 });
            Assert.AreEqual(result, 1 + 3 + 3 + 1 + 3*(5));
        }
    }
}
