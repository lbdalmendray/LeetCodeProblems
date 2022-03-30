using LongestSubstringofOneRepeatingCharacter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LongestSubstringofOneRepeatingCharacterTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            /*
             Input: s = "babacc", queryCharacters = "bcb", queryIndices = [1,3,3]
Output: [3,3,4]
             */

            Solution solution = new Solution();
            var result = solution.LongestRepeating("babacc", "bcb", new int[] { 1, 3, 3 });
            CollectionAssert.AreEquivalent(new int[] { 3, 3, 4 }, result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            /*
             Input: s = "abyzz", queryCharacters = "aa", queryIndices = [2,1]
Output: [2,3]
             */

            Solution solution = new Solution();
            var result = solution.LongestRepeating("abyzz", "aa", new int[] { 2,1 });
            CollectionAssert.AreEquivalent(new int[] { 2,3 }, result);
        }


        [TestMethod]
        public void TestMethod3()
        {
            /*
             Input: s = "a", queryCharacters = "bcdefg", queryIndices = [0,0,0,0,0,0]
Output: [2,3]
             */

            Solution solution = new Solution();
            var result = solution.LongestRepeating("a", "bcdefg", new int[] { 0, 0, 0, 0, 0, 0 });
            CollectionAssert.AreEquivalent(new int[] { 1,1,1,1,1,1 }, result);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var stringValue = "babacc";
            Tree tree = new Tree(stringValue);
            for (int i = 0; i < stringValue.Length; i++)
            {
                for (int j = i; j < stringValue.Length; j++)
                {
                    try
                    {
                        Console.WriteLine($"{i} - {j}");

                        int max = GetMaxStringValue(stringValue, i, j);
                        int treeMax = tree.GetMax(i, j);
                        Assert.AreEqual(max, treeMax, $"{i} - {j} : {stringValue.Substring(i, j - i + 1)}");
                    }
                    catch (System.Exception e)
                    {
                        throw;
                    }                    
                }
            }
        }

        [TestMethod]
        public void TestMethod5()
        {
            var stringValue = "aaaaaaaaa";
            Tree tree = new Tree(stringValue);
            for (int i = 0; i < stringValue.Length; i++)
            {
                for (int j = i; j < stringValue.Length; j++)
                {
                    int max = GetMaxStringValue(stringValue, i, j);
                    int treeMax = tree.GetMax(i, j);
                    Assert.AreEqual(max, treeMax, $"{i} - {j} : {stringValue.Substring(i, j - i + 1)}");
                }
            }
        }

        [TestMethod]
        public void TestMethod6()
        {
            var stringValue = "aaaabbbbcccccddddd";
            Tree tree = new Tree(stringValue);
            for (int i = 0; i < stringValue.Length; i++)
            {
                for (int j = i; j < stringValue.Length; j++)
                {
                    int max = GetMaxStringValue(stringValue, i, j);
                    int treeMax = tree.GetMax(i, j);
                    Assert.AreEqual(max, treeMax, $"{i} - {j} : {stringValue.Substring(i, j - i + 1)}");
                }
            }
        }

        private int GetMaxStringValue(string stringValue, int i, int j)
        {
            int result = 0;
            j++;
            for (; i < j; i++)
            {
                int counter = 0;
                int k = i;
                while (k < j && stringValue[k] == stringValue[i])
                {
                    counter++;
                    k++;
                }
                if (counter > result)
                    result = counter;
                i = k - 1;
            }

            return result;
        }
    }
}
