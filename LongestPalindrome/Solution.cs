using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestPalindrome
{
    public class Solution
    {
        public int LongestPalindrome(string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (var charValue in s)
            {
                if (dict.TryGetValue(charValue, out var value))
                {
                    dict[charValue] = value + 1;
                }
                else
                    dict[charValue] = 1;
            }

            int result = 0;
            bool one = false;

            foreach (var item in dict)
            {
                var cone = item.Value % 2 == 1;
                var v = item.Value;
                if (cone)
                {
                    one = cone;
                    v--;
                }
                result += v;
            }
            
            if (one)
            {
                result++;
            }

            return result;

        }

        public string LongestPalindromeString(string s)
        {
            int resultIndex = 0;
            int resultLength = 1;

            bool[,] isPalindrome = new bool[s.Length, s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                isPalindrome[i, i] = true;
            }

            for (int i = 0; i < s.Length-1; i++)
            {
                if (s[i] == s[i + 1])
                {
                    isPalindrome[i, i + 1] = true;
                    if (resultLength < 2)
                    {
                        resultIndex = i;
                        resultLength = 2;
                    }
                }                
            }

            for (int i = 0; i < s.Length-2; i++)
            {
                if (s[i] == s[i + 2])
                {
                    isPalindrome[i, i + 2] = true;
                    if (resultLength < 3)
                    {
                        resultIndex = i;
                        resultLength = 3;
                    }
                }                
            }

            for (int length = 4; length <= s.Length ; length++)
            {
                for (int i = 0; i < s.Length - (length - 1 ) ; i++)
                {
                    if( s[i] == s[i+length-1] && isPalindrome[i+1,i+length-2])
                    {
                        isPalindrome[i, i + length - 1] = true;
                        if (resultLength < length)
                        {
                            resultIndex = i;
                            resultLength = length;
                        }
                    }                    
                }                
            }

            return s.Substring(resultIndex, resultLength);
        }

        public string LongestPalindrome1String(string s)
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
