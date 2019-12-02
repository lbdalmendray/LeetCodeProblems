using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubstringwithConcatenationofAllWords;

namespace SubstringwithConcatenationofAllWordsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.FindSubstring("barfoothefoobarman", new string[] { "foo", "bar" }).ToArray();
            Array.Sort(result);

            CollectionAssert.AreEqual(result, new int[] { 0, 9 });
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.FindSubstring("wordgoodgoodgoodbestword", new string[] { "word", "good", "best", "word" }).ToArray();
            Array.Sort(result);

            CollectionAssert.AreEqual(result, new int[0]);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.FindSubstring("aaaeee", new string[] {  "aaa" ,"eee"  }).ToArray();
            Array.Sort(result);

            CollectionAssert.AreEqual(result, new int[] { 0 });
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            var result = s.FindSubstring("", new string[] { "aaa", "eee" }).ToArray();
            Array.Sort(result);

            CollectionAssert.AreEqual(result, new int[] {});
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            var result = s.FindSubstring("0123456789aaeaaea", new string[] { "a", "a" , "e" }).ToArray();
            Array.Sort(result);

            CollectionAssert.AreEqual(result, new int[] { 10,11,12,13,14 });
        }

        [TestMethod]
        public void TestMethod6()
        {
            Solution s = new Solution();
            var result = s.FindSubstring("aaeaaea", new string[] { "a", "a", "e" }).ToArray();
            Array.Sort(result);

            CollectionAssert.AreEqual(result, new int[] { 0, 1, 2, 3, 4 });
        }

        [TestMethod]
        public void TestMethod7()
        {
            Solution s = new Solution();
            var result = s.FindSubstring("word1word2word3aaaword2word1word3aaaword3word1word2", new string[] { "word1", "word2", "word3" }).ToArray();
            Array.Sort(result);

            CollectionAssert.AreEqual(result, new int[] { 0,18, 36 });
        }

        [TestMethod]
        public void TestMethod8()
        {
            Solution s = new Solution();
            var result = s.FindSubstring("aaaaaaword1word2word3aaaword2word1word3aaaword3word1word2", new string[] { "word1", "word2", "word3" }).ToArray();
            Array.Sort(result);

            CollectionAssert.AreEqual(result, new int[] { 6+0, 6+18, 6+36 });
        }

        [TestMethod]
        public void TestMethod9()
        {
            Solution s = new Solution();
            var result = s.FindSubstring("aaaeeeaeaea", new string[] { "a","a","a","e","e","e" }).ToArray();
            Array.Sort(result);

            CollectionAssert.AreEqual(result, new int[] { 0,1,5 });
        }

        [TestMethod]
        public void TestMethod10()
        {
            var count = 500000;
            Solution s = new Solution();
            var result = s.FindSubstring(new string(Enumerable.Range(0, count).Select(e=>'n').ToArray())+ "aaaeeeaeaea", new string[] { "a", "a", "a", "e", "e", "e" }).ToArray();
            Array.Sort(result);

            CollectionAssert.AreEqual(result, new int[] { count + 0, count + 1, count + 5 });
        }

        [TestMethod]
        public void TestMethod11()
        {
            var count = 500000;
            Solution s = new Solution();
            var result = s.FindSubstring(new string(Enumerable.Range(0, count).Select(e => 'a').ToArray()) , new string[] { "a", "a", "a" }).ToArray();
            Array.Sort(result);

            CollectionAssert.AreEqual(result, Enumerable.Range(0, count - 2).ToArray());
        }
    }
}
