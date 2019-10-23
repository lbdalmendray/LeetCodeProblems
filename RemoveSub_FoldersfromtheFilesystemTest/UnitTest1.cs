using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemoveSub_FoldersfromtheFilesystem;

namespace RemoveSub_FoldersfromtheFilesystemTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.RemoveSubfolders(new string[] { "/a", "/a/b", "/c/d", "/c/d/e", "/c/f" });
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.RemoveSubfolders(new string[] { "/a", "/a/b/c", "/a/b/d" });
        }
    }
}
