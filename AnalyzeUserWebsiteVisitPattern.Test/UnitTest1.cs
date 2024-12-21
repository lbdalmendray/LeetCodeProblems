namespace AnalyzeUserWebsiteVisitPattern.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            var result = solution.MostVisitedPattern(
                    ["joe", "joe", "joe", "james", "james", "james", "james", "mary", "mary", "mary"]
                ,   [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                ,   ["home", "about", "career", "home", "cart", "maps", "home", "home", "about", "career"]);

            CollectionAssert.AreEquivalent(result.ToList(), new List<string> { "home", "about", "career" });
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();
            var result = solution.MostVisitedPattern(
                    ["ua", "ua", "ua", "ub", "ub", "ub"]
                ,   [1, 2, 3, 4, 5, 6]
                ,   ["a", "b", "a", "a", "b", "c"]);

            CollectionAssert.AreEquivalent(result.ToList(), new List<string> { "a", "b", "a" });
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution solution = new Solution();
            var result = solution.MostVisitedPattern(
                    ["joe", "joe", "joe", "joe", "joee", "joee", "joee"]
                , [1, 2, 3, 4, 5, 6, 7]
                , ["home", "home", "about", "career", "haome", "aabout", "acareer"]);

            CollectionAssert.AreEquivalent(result.ToList(), new List<string> { "haome", "aabout", "acareer" });
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution solution = new Solution();
            var result = solution.MostVisitedPattern(
                    ["him", "mxcmo", "jejuvvtye", "wphmqzn", "uwlblbrkqv", "flntc", "esdtyvfs", "nig", "jejuvvtye", "nig", "mxcmo", "flntc", "nig", "jejuvvtye", "odmspeq", "jiufvjy", "esdtyvfs", "mfieoxff", "nig", "flntc", "mxcmo", "qxbrmo"]
                , [113355592, 304993712, 80831183, 751306572, 34485202, 414560488, 667775008, 951168362, 794457022, 813255204, 922111713, 127547164, 906590066, 685654550, 430221607, 699844334, 358754380, 301537469, 561750506, 612256123, 396990840, 60109482]
                , ["k", "o", "o", "nxpvmh", "dssdnkv", "kiuorlwdcw", "twwginujc", "evenodb", "qqlw", "mhpzoaiw", "jukowcnnaz", "m", "ep", "qn", "wxeffbcy", "ggwzd", "tawp", "gxm", "pop", "xipfkhac", "weiujzjcy", "x"]);

            CollectionAssert.AreEquivalent(result.ToList(), new List<string> { "m", "kiuorlwdcw", "xipfkhac" });
        }
    }
}