using Solution = FaultyKeyboard.Solution2;
using FaultyKeyboard;

namespace FaultyKeyboardTest
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            var result = solution.FinalString("string");
            Assert.AreEqual(result, "rtsng");
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();
            var result = solution.FinalString("poiinter");
            Assert.AreEqual(result, "ponter");
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution solution = new Solution();
            var result = solution.FinalString("aaaaibbbbbicccciddddi");
            Assert.AreEqual(result, "ddddbbbbbaaaacccc");
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution solution = new Solution();
            var result = solution.FinalString("aaaaibbbbbiccccidddd");
            var reverse = "ddddbbbbbaaaacccc".Reverse();
            Assert.AreEqual(result, new string(reverse.ToArray()));
        }

        [TestMethod]
        public void TestMethod1000()
        {
            for (int i = 0; i < 100000; i++)
            {
                Solution solution = new Solution();
                var result = solution.FinalString("aaaaibbbbbiccccidddd");
                var reverse = "ddddbbbbbaaaacccc".Reverse();
                Assert.AreEqual(result, new string(reverse.ToArray()));
            }            
        }
    }
}
