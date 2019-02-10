using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestPalindrome
{
    class Solution
    {
        public string LongestPalindrome(string s)
        {
            bool[,] existPalindrome = new bool[s.Length, s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                existPalindrome[i, i] = true;
            }
            int maxIndex1 = 0;
            int maxIndex2 = 0;

            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] == s[i + 1])
                {
                    existPalindrome[i, i + 1] = true;
                    if (maxIndex2 - maxIndex1 < 1)
                    {
                        maxIndex2 = i + 1;
                        maxIndex1 = i;
                    }
                }
            }

            for (int i = 1; i < s.Length; i++)
            {
                for (int j = 0; j + i < s.Length; j++)
                {
                    if (existPalindrome[j + 1, j + i - 1] && s[j] == s[j + i])
                    {
                        existPalindrome[j, j + i] = true;
                        if (maxIndex2 - maxIndex1 < i)
                        {
                            maxIndex2 = j + i;
                            maxIndex1 = j;
                        }
                    }
                }
            }

            return s.Substring(maxIndex1, maxIndex2 - maxIndex1 + 1);
        }
    }
}
