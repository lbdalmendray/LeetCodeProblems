using LongestStringChain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LongestStringChainTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            int result = solution.LongestStrChain(new string[]
            {
                "a","b","ba","bca","bda","bdca"
            });

            Assert.AreEqual(result, 4);

        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();
            int result = solution.LongestStrChain(new string[]
            {
                "xbc","pcxbcf","xb","cxbc","pcxbc"
            });

            Assert.AreEqual(result, 5);

        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution solution = new Solution();
            int result = solution.LongestStrChain(new string[]
            {
                "abcd","dbqca"
            });

            Assert.AreEqual(result, 1);

        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution solution = new Solution();
            int result = solution.LongestStrChain(new string[]
            {
                "aaaaa","aaaaaa"
            });

            Assert.AreEqual(result, 2);

        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution solution = new Solution();
            int result = solution.LongestStrChain(new string[]
            {
                "asdf","asdfg","asdfgh"
                , "nasdf","nasdfg","nasdfgh"
            });

            Assert.AreEqual(result, 4);

        }

    }
}