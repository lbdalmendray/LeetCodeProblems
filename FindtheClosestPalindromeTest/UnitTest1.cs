using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using FindtheClosestPalindrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FindtheClosestPalindromeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            BigInteger[] nines = new BigInteger[] { 9, 99, 999, 9999, 99999, 999999, 9999999, 99999999, 999999999, 9999999999, 99999999999, 999999999999, 9999999999999, 99999999999999, 999999999999999, 9999999999999999, 99999999999999999, 999999999999999999, 9999999999999999999 };
            BigInteger[] tenPotences = new BigInteger[] { 1, 10, 100, 1000, 10000, 100000, 1000000, 10000000, 100000000, 1000000000, 10000000000, 100000000000, 1000000000000, 10000000000000, 100000000000000, 1000000000000000, 10000000000000000, 100000000000000000, 1000000000000000000 };

            for (int i = 0; i < nines.Length - 1 ; i++)
            {
                Assert.AreEqual(nines[i] * 10 + 9, nines[i + 1]);
                Assert.AreEqual(tenPotences[i] * 10 , tenPotences[i + 1]);
            }

            Solution s = new Solution();
            Assert.AreEqual(s.NearestPalindromic("433"), "434");
        }

        [TestMethod]
        public void TestMethod2()
        {
            Solution s = new Solution();
            Assert.AreEqual(s.NearestPalindromic("999"), "1001");
        }


        [TestMethod]
        public void TestMethod3()
        {
            Solution s = new Solution();
            ulong[] nines = new ulong[] { 999, 9999, 99999, 999999, 9999999, 99999999, 999999999, 9999999999, 99999999999, 999999999999, 9999999999999, 99999999999999, 999999999999999, 9999999999999999, 99999999999999999, 999999999999999999, 9999999999999999999 };
            foreach (var item in nines)
            {
                Assert.AreEqual(s.NearestPalindromic(item.ToString()), (item + 2).ToString());
            }
        }

        [TestMethod]
        public void TestMethod4()
        {
            Solution s = new Solution();
            ulong[] nines = new ulong[] { 9999 };
            foreach (var item in nines)
            {
                Assert.AreEqual(s.NearestPalindromic(item.ToString()), (item + 2).ToString());
            }
        }

        [TestMethod]
        public void TestMethod5()
        {
            Solution s = new Solution();
            //for (int i = 1; i < 10000000; i++)
            for (int i = 1; i < 50000; i++)
            {
                for (int j = 1; j < 20000; j++)
                {
                    int newNumber = i - j;
                    string newNumberString = newNumber.ToString();
                    if (newNumber >= 0 && s.isPalindrome(newNumberString))
                    {
                        var result = s.NearestPalindromic(i.ToString());
                        Assert.AreEqual(result, newNumberString);
                        break;
                    }

                    newNumber = i + j;
                    newNumberString = newNumber.ToString();

                    if (s.isPalindrome(newNumberString))
                    {
                        var result = s.NearestPalindromic(i.ToString());
                        Assert.AreEqual(result, newNumberString);
                        break;
                    }
                }
            }
        }


        [TestMethod]
        public void TestMethod6()
        {
            Solution s = new Solution();
            ulong[] nines = new ulong[] { 107 };
            foreach (var item in nines)
            {
                Assert.AreEqual(s.NearestPalindromic(item.ToString()), 111.ToString());
            }
        }

        [TestMethod]
        public void TestMethod7()
        {
            Solution s = new Solution();
            ulong[] nines = new ulong[] { 111 };
            foreach (var item in nines)
            {
                Assert.AreEqual(s.NearestPalindromic(item.ToString()), 101.ToString());
            }
        }

        [TestMethod]
        public void TestMethod8()
        {
            Solution s = new Solution();
            ulong[] nines = new ulong[] { 197 };
            foreach (var item in nines)
            {
                Assert.AreEqual(s.NearestPalindromic(item.ToString()), 202.ToString());
            }
        }

        [TestMethod]
        public void TestMethod9()
        {
            Solution s = new Solution();
            ulong[] nines = new ulong[] { 510 };
            foreach (var item in nines)
            {
                Assert.AreEqual(s.NearestPalindromic(item.ToString()), 505.ToString());
            }
        }

        [TestMethod]
        public void TestMethod10()
        {
            Solution s = new Solution();
            ulong[] nines = new ulong[] { 600 };
            foreach (var item in nines)
            {
                Assert.AreEqual(s.NearestPalindromic(item.ToString()), 595.ToString());
            }
        }

        [TestMethod]
        public void TestMethod11()
        {
            Solution s = new Solution();
            ulong[] nines = new ulong[] { 1057 };
            foreach (var item in nines)
            {
                Assert.AreEqual(s.NearestPalindromic(item.ToString()), 1111.ToString());
            }
        }

        [TestMethod]
        public void TestMethod12()
        {
            Solution s = new Solution();
            ulong[] nines = new ulong[] { 1056 };
            foreach (var item in nines)
            {
                Assert.AreEqual(s.NearestPalindromic(item.ToString()), 1001.ToString());
            }
        }

        [TestMethod]
        public void TestMethod13()
        {
            Solution s = new Solution();
            ulong[] nines = new ulong[] { 151 };
            foreach (var item in nines)
            {
                Assert.AreEqual(s.NearestPalindromic(item.ToString()), 141.ToString());
            }
        }

        [TestMethod]
        public void TestMethod14()
        {
            Solution s = new Solution();
            ulong[] nines = new ulong[] { 1100 };
            foreach (var item in nines)
            {
                Assert.AreEqual(s.NearestPalindromic(item.ToString()), 1111.ToString());
            }
        }

        [TestMethod]
        public void TestMethod15()
        {
            Solution s = new Solution();
            ulong[] nines = new ulong[] { 1200 };
            foreach (var item in nines)
            {
                Assert.AreEqual(s.NearestPalindromic(item.ToString()), 1221.ToString());
            }
        }

        [TestMethod]
        public void TestMethod16()
        {
            Solution s = new Solution();
            ulong[] nines = new ulong[] { 2002 };
            foreach (var item in nines)
            {
                Assert.AreEqual(s.NearestPalindromic(item.ToString()), 1991.ToString());
            }
        }

        [TestMethod]
        public void TestMethod17()
        {
            Solution s = new Solution();
            ulong[] nines = new ulong[] { 10100 };
            foreach (var item in nines)
            {
                Assert.AreEqual(s.NearestPalindromic(item.ToString()), 10101.ToString());
            }
        }

        [TestMethod]
        public void TestMethod18()
        {
            Solution s = new Solution();
            ulong[] nines = new ulong[] { 11000 };
            foreach (var item in nines)
            {
                Assert.AreEqual(s.NearestPalindromic(item.ToString()), 11011.ToString());
            }
        }

        /*
         
        [TestMethod]
        public void TestMethod19()
        {
            Solution s = new Solution();
            int length = 4;
            int max = (int)Math.Pow(10, length+2);
            foreach (var i in GetAllPalindromes(length))
            {                
                for (BigInteger j = 1; j < max; j++)
                {
                    BigInteger newNumber = i - j;
                    string newNumberString = newNumber.ToString();
                    if (newNumber >= 0 && s.isPalindrome(newNumberString))
                    {
                        var result = s.NearestPalindromic(i.ToString());
                        Assert.AreEqual(result, newNumberString);
                        break;
                    }

                    newNumber = i + j;
                    newNumberString = newNumber.ToString();

                    if (s.isPalindrome(newNumberString))
                    {
                        var result = s.NearestPalindromic(i.ToString());
                        Assert.AreEqual(result, newNumberString);
                        break;
                    }
                }                
            }

        }
        
        */

        private IEnumerable<BigInteger> GetAllPalindromes(int count = 9)
        {
            int firstNoDigi = count;
            int[] indexes = Enumerable.Repeat(-1,count).ToArray();
            indexes[0]++;
            int currentIndex = 0;
            BigInteger[] tenPotences = new BigInteger[] { 1, 10, 100, 1000, 10000, 100000, 1000000, 10000000, 100000000, 1000000000, 10000000000, 100000000000, 1000000000000, 10000000000000, 100000000000000, 1000000000000000, 10000000000000000, 100000000000000000, 1000000000000000000 };

            while (true)
            {
                if( currentIndex == firstNoDigi)
                {
                    currentIndex--;
                    yield return GetNumber(indexes, tenPotences, count);
                }
                else
                {
                    if (indexes[currentIndex] < 9)
                        indexes[currentIndex]++;
                    else
                        indexes[currentIndex] = 0;

                    if (indexes[currentIndex] == 10)
                    {
                        indexes[currentIndex] = 0;
                        currentIndex--;
                    }
                    else
                    {
                        currentIndex++;
                    }
                }
            }

        }

        private BigInteger GetNumber(int[] indexes, BigInteger[] tenPotences, int count)
        {
            BigInteger result = 0;
            for (int i = 0; i < indexes.Length; i++)
            {
                result += indexes[i] * tenPotences[i];
            }

            int countDouble = count * 2 - 1;

            for (int i = countDouble; i >= indexes.Length; i--)
            {
                result += indexes[countDouble- i] * tenPotences[i];
            }

            return result;
        }
    }
}
