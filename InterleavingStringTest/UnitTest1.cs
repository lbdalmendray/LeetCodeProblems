using System;
using System.Collections.Generic;
using System.Linq;
using InterleavingString;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils;

namespace InterleavingStringTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Solution s = new Solution();
            var result = s.IsInterleave("aabcc", "dbbca", "aadbbcbcac");
                                                        //"aa b c c     " 2-1
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            var result = s.IsInterleave("a", "b", "ab");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            var result = s.IsInterleave("aa", "bb", "aabb");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            var result = s.IsInterleave("aa", "b", "aab");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            var result = s.IsInterleave("a", "bb", "abb");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod6()
        {
            Solution s = new Solution();
            var result = s.IsInterleave("ac", "b", "abc");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestMethod7()
        {
            Solution s = new Solution();
            var result = s.IsInterleave("ac", "ab", "aabc");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod8()
        {
            Solution s = new Solution();
            var result = s.IsInterleave("aabcc", "dbbca", "aadbbbaccc");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethod9()
        {
            Solution s = new Solution();
            var result = s.IsInterleave("", "", "");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod10()
        {
            Solution s = new Solution();
            var result = s.IsInterleave("", "aa", "aa");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod11()
        {
            Solution s = new Solution();
            var result = s.IsInterleave("", "aa", "aaa");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethod12()
        {
            Solution s = new Solution();
            var result = s.IsInterleave("aabd","abdc","aabdabcd");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod13()
        {
            Solution s = new Solution();
            var result = s.IsInterleave("a", "b", "ab");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethodMany()
        {
            Solution s = new Solution();
            string chars = "abcd";
            int length = 4;
            for (int i = 0; i < length; i++)
            {            
                foreach (string s1 in GenerateAllString(chars, i))
                {
                    for (int j = 0; j < length; j++)
                    {
                        foreach (string s2 in GenerateAllString(chars, j))
                        {
                            foreach (var s3 in GenerateAllMix(s1, s2))
                            {
                                var result = s.IsInterleave(s1, s2, s3);
                                Assert.IsTrue(result, "s1:" + s1 + " s2:" + s2 + " s3:" + s3 + " Length:" + length);
                            }
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void TestMethodMany2()
        {
            Solution s = new Solution();
            string chars = "abc";
            int length = 4;
            foreach (string s1 in GenerateAllString(chars, length))
            {
                foreach (string s2 in GenerateAllString(chars, length))
                {
                    foreach (var s3 in GenerateAllMix(s1, s2))
                    {
                        var result = s.IsInterleave(s1, s2, s3);
                        Assert.IsTrue(result,"s1:" + s1 + " s2:" + s2+ " s3:" + s3);
                    }
                }
            }
        }

        [TestMethod]
        public void TestMethod14()
        {
            Solution s = new Solution();
            var result = s.IsInterleave("aaaaba", "aaaabb", "aaaabaaababa");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod15()
        {
            Solution s = new Solution();
            var result = s.IsInterleave("abbb", "bbbc", "abbbcbbb");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod16()
        {
            Solution s = new Solution();
            var result = s.IsInterleave("a", "aaa", "aa");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethod17()
        {
            Solution s = new Solution();
            var result = s.IsInterleave("a", "aaa", "aaaaa");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestMethod18()
        {
            Solution s = new Solution();
            var s1 = new string(Enumerable.Repeat('a', 1000).ToArray());
            var s2 = new string(Enumerable.Repeat('b', 1000).ToArray());
            var s3 = s1 + s2;
            var result = s.IsInterleave(s1, s2, s3);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMethod19()
        {
            Solution s = new Solution();
            var s1 = "bbcbaba";
            var s2 = "aaccc";
            var s3 = "baccbaabbcca";
            var result = s.IsInterleave(s1, s2, s3);
            Assert.IsFalse(result);
        }

        /*
         "bbcbaba"
"aaccc"
"baccbaabbcca"
         * */

        [TestMethod]
        public void TestMethodManyFalse()
        {
            Solution s = new Solution();
            string chars = "abcd";
            int length = 4;
            for (int i = 0; i < length; i++)
            {
                foreach (string s1 in GenerateAllString(chars, i))
                {
                    for (int j = 1; j < length; j++)
                    {
                        foreach (string s2 in GenerateAllString(chars, j))
                        {
                            foreach (var s3 in GenerateAllMix(s1, s2.Substring(0,s2.Length-1)) )
                            {
                                var result = s.IsInterleave(s1, s2, s3);
                                Assert.IsFalse(result, "s1:" + s1 + " s2:" + s2 + " s3:" + s3 + " Length:" + length);
                            }
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void TestMethodManyFalse2()
        {
            Solution s = new Solution();
            string chars = "abcd";
            int length = 4;
            for (int i = 0; i < length; i++)
            {
                foreach (string s1 in GenerateAllString(chars, i))
                {
                    for (int j = 1; j < length; j++)
                    {
                        foreach (string s2 in GenerateAllString(chars, j))
                        {
                            foreach (var s3 in GenerateAllMix(s1, s2+"a" ))
                            {
                                var result = s.IsInterleave(s1, s2, s3);
                                Assert.IsFalse(result, "s1:" + s1 + " s2:" + s2 + " s3:" + s3 + " Length:" + length);
                            }
                        }
                    }
                }
            }
        }

        /// s1:abbb s2:bbbc s3:abbbcbbb

        private IEnumerable<string> GenerateAllMix(string s1, string s2)
        {
            char[] result = new char[s1.Length + s2.Length];
            
            var posibilities = Utils.Utils.GetAllSelections(s1.Length + s2.Length).Where(e => e.Sum(e1 => e1 ? 1 : 0) == s1.Length);
            foreach (var posibility in posibilities)
            {
                int s1I = 0;
                int s2I = 0;
                for (int i = 0; i < posibility.Length; i++)
                {
                    if (posibility[i])
                    {
                        result[i] = s1[s1I];
                        s1I++;
                    }
                    else
                    {
                        result[i] = s2[s2I];
                        s2I++;
                    }
                }

                yield return new string(result);
            }
        }

        private IEnumerable<string> GenerateAllString(string chars, int Length)
        {
            if (Length == 0)
                yield return "";
            else
            {
                LinkedList<char> result = new LinkedList<char>();
                for (int i = 0; i < chars.Length; i++)
                {
                    result.AddLast(chars[i]);

                    foreach (var item in GenerateAllString(chars, Length, 1, result))
                    {
                        yield return item;
                    }

                    result.RemoveLast();
                }
            }
        }

        private IEnumerable<string> GenerateAllString(string chars, int length ,int index, LinkedList<char> result)
        {
            if (index == length)
            {
                yield return new string(result.ToArray());
            }
            else
            {
                for (int i = 0; i < chars.Length; i++)
                {
                    result.AddLast(chars[i]);

                    foreach (var item in GenerateAllString(chars, length, index + 1, result))
                    {
                        yield return item;
                    }

                    result.RemoveLast();
                }
            }
        }
    }

}
