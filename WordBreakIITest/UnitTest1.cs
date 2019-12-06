using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils;
using WordBreakII;

namespace WordBreakIITest
{
    [TestClass]
    public class UnitTest1
    {
        EnumerableComparer<string> enumerableComparer = new EnumerableComparer<string>();

        [TestMethod]
        public void TestMyContainer()
        {
            MyContainer container = new MyContainer(new string[] { "a", "aaa", "aaaaa", "aba", "ababa", "bb", "bbbb", "bbbbbb" });
            var result = container.GetValidWordPositions("aaaaaa",0);
            Assert.IsTrue(result.All(e => e % 2 == 0));

            result = container.GetValidWordPositions("bbbbbb", 0);
            Assert.IsTrue(result.All(e => e % 2 == 1));

            result = container.GetValidWordPositions("tt", 0);
            Assert.IsTrue(result.All(e => e % 2 == 0));
        }

        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.WordBreak("catsanddog", new string[] { "cat", "cats", "and", "sand", "dog" });
            Assert.IsTrue(enumerableComparer.Equivalent(result.ToArray(), new string[] { "cats and dog", "cat sand dog" }));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.WordBreak("cat", new string[] { "cat", "cats", "and", "sand", "dog" });
            Assert.IsTrue(enumerableComparer.Equivalent(result.ToArray(), new string[] { "cat" }));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.WordBreak("pineapplepenapple", new string[] { "apple", "pen", "applepen", "pine", "pineapple" });
            Assert.IsTrue(enumerableComparer.Equivalent(result.ToArray(), new string[] { "pine apple pen apple",
                  "pineapple pen apple",
                  "pine applepen apple" }));
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            var result = s.WordBreak("catsandog", new string[] { "cats", "dog", "sand", "and", "cat" });
            Assert.IsTrue(enumerableComparer.Equivalent(result.ToArray(), new string[] {  }));
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            for (int letterCount = 4; letterCount < 18; letterCount++)
            {
                var fourLetters = CreateAllLettersList(2, letterCount);
                var twoLetters = CreateAllLettersList(4, letterCount);
                var bigList = Enumerable.Concat(fourLetters, twoLetters).ToArray();
               
                var result = s.WordBreak(CreateAllLetters(4, letterCount), bigList);
                Assert.AreEqual(result.Count, (int)Math.Pow(2, letterCount));
            }
            
        }

        private string CreateAllLetters(int length, int letterCount)
        {
            string result = "";
            for (int i = 0; i < letterCount; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    result += ((char)(i + 'a'));
                }
            }

            return result;
        }

        private LinkedList<string> CreateAllLettersList(int length, int letterCount)
        {
            LinkedList<string> result = new LinkedList<string>();
            for (int i = 0; i < letterCount; i++)
            {
                var resultString = "";
                for (int j = 0; j < length; j++)
                {
                    resultString += ((char)(i + 'a'));
                }
                result.AddLast(resultString);
            }

            return result;
        }
    }
}
