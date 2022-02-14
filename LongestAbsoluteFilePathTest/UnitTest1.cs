using LongestAbsoluteFilePath;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LongestAbsoluteFilePathTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            int result = solution.LengthLongestPath("dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext");
            Assert.AreEqual(result, 20);
        }
    }
}
