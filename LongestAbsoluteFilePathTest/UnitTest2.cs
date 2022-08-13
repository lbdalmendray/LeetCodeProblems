using LongestAbsoluteFilePath;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LongestAbsoluteFilePathTest
{
    [TestClass]
    public class UnitTest2
    {
        /*
         Input: input = "dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext"
         Output: 20
         */

        [TestMethod]
        public void TestMethod1()
        {
            Solution2 solution = new Solution2();
            int result = solution.LengthLongestPath("dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext");
            Assert.AreEqual(result, 20);
        }

        [TestMethod]
        public void TestMethod2()
        {
            /*
             Input: input = "dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext"
             Output: 32
             */

            Solution2 solution = new Solution2();
            int result = solution.LengthLongestPath("dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext");
            Assert.AreEqual(result, 32);
        }

        [TestMethod]
        public void TestMethod3()
        {
            /*
             Input: input = "a"
             Output: 0
             */

            Solution2 solution = new Solution2();
            int result = solution.LengthLongestPath("a");
            Assert.AreEqual(result, 0);
        }
    }
}
