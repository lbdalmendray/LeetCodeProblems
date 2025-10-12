using GroupAnagrams;

namespace GroupAnagramsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution solution = new Solution();
            var result = solution.GroupAnagrams(["eat", "tea", "tan", "ate", "nat", "bat"]);
            AreEquivalent(result,
                 new List<List<string>>

                {
                    new List<string>() { "bat" }
                , new List<string>() { "nat", "tan" }
                , new List<string>() { "ate", "eat", "tea" }
                }.Select(e => (IList<string>)e)
                .ToList());
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution solution = new Solution();
            var result = solution.GroupAnagrams(["eaaaaaaaaat", "teaaaaaaaaa", "tannnnnnnnnnnnnnnn", "aaaaaaaaate", "nnnnnnnnnnnnnnnnat", "bbbbbbbbbbbbbbbbat"]);
            AreEquivalent(result,
                 new List<List<string>>

                {
                    new List<string>() { "bbbbbbbbbbbbbbbbat" }
                , new List<string>() { "nnnnnnnnnnnnnnnnat", "tannnnnnnnnnnnnnnn" }
                , new List<string>() { "aaaaaaaaate", "eaaaaaaaaat", "teaaaaaaaaa" }
                }.Select(e => (IList<string>)e)
                .ToList());
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution solution = new Solution();
            var result = solution.GroupAnagrams(["ddddddddddg", "dgggggggggg"]);
            AreEquivalent(result,
                 new List<List<string>>

                {
                    new List<string>() { "dgggggggggg" }
                    ,new List<string>() { "ddddddddddg" }
                }.Select(e => (IList<string>)e)
                .ToList());
        }

        private void AreEquivalent(IList<IList<string>> ListList1, List<IList<string>> ListList2)
        {
            for (int i = 0; i < ListList1.Count; i++)
            {
                var list1 = ListList1[i].ToList();
                var firstElement1 = list1.First();

                bool isThere = false;
                List<string> isTherList = null;
                foreach (var list2 in ListList2)
                {
                    if ( list2.Contains(firstElement1))
                    {
                        isThere = true;
                        isTherList = list2.ToList();
                        break;
                    }
                }

                if ( isThere)
                {
                    ListList2.Remove(isTherList);
                    isTherList.Sort();
                    list1.Sort();
                    CollectionAssert.AreEquivalent(isTherList, list1);
                }
                else
                {
                    Assert.AreEqual(0, 1);
                }
            }
        }
    }
}