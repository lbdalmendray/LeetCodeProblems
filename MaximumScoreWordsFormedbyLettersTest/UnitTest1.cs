using System;
using System.Linq;
using MaximumScoreWordsFormedbyLetters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaximumScoreWordsFormedbyLettersTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            /*
      Input: words = ["dog","cat","dad","good"], letters = ["a","a","c","d","d","d","g","o","o"], score = [1,0,9,5,0,0,3,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0]
Output: 23       

    */
            var words = new string[] { "dog", "cat", "dad", "good" };
            var letters = new string[] { "a", "a", "c", "d", "d", "d", "g", "o", "o" }.Select(e=>e[0]).ToArray();
            var scores = new int[] { 1, 0, 9, 5, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            Solution s = new Solution();
            var result = s.MaxScoreWords(words, letters, scores);

            Assert.AreEqual(result, 23);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var words = new string[] { "aa" };
            var letters = new string[] { "a" , "a" }.Select(e => e[0]).ToArray();
            var scores = new int[] { 9, 0, 9, 5, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            Solution s = new Solution();
            var result = s.MaxScoreWords(words, letters, scores);

            Assert.AreEqual(result, 18);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var words = new string[] { "aa" , "bb" ,"bc" };
            var letters = new string[] { "a" , "c" ,"b" }.Select(e => e[0]).ToArray();
            var scores = new int[] { 9, 1, 9, 5, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            Solution s = new Solution();
            var result = s.MaxScoreWords(words, letters, scores);

            Assert.AreEqual(result, 10);
        }

        [TestMethod]
        public void TestMethod4()
        {
            /*
    
            words = ["xxxz","ax","bx","cx"], letters = ["z","a","b","c","x","x","x"], score = [4,4,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,10]

        */

            var words = new string[] { "xxxz", "ax", "bx", "cx" };
            var letters = new string[] { "z", "a", "b", "c", "x", "x", "x" }.Select(e => e[0]).ToArray();
            var scores = new int[] { 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 10 };
            Solution s = new Solution();
            var result = s.MaxScoreWords(words, letters, scores);

            Assert.AreEqual(result, 27);
        }

        [TestMethod]
        public void TestMethod5()
        {
            /*
    
            words = ["leetcode"], letters = ["l","e","t","c","o","d"], score = [0,0,1,1,1,0,0,0,0,0,0,1,0,0,1,0,0,0,0,1,0,0,0,0,0,0]
        */

            var words = new string[] { "leetcode" };
            var letters = new string[] { "l", "e", "t", "c", "o", "d" }.Select(e => e[0]).ToArray();
            var scores = new int[] { 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 };
            Solution s = new Solution();
            var result = s.MaxScoreWords(words, letters, scores);

            Assert.AreEqual(result, 0);
        }
    }
}
