using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumInsertionStepstoMakeaStringPalindrome
{
    public class Solution
    {
        public int MinInsertions(string s)
        {
            if (IsPalindrome(s))
                return 0;
            int?[,] infos = new int?[s.Length, s.Length];

            return Calculate(s, 0, s.Length - 1, infos);
        }

        private int Calculate(string s, int i, int j, int?[,] infos)
        {
            if (infos[i, j].HasValue)
                return infos[i, j].Value;
            int result = 0;

            if (i >= j)
            {
                result = 0;
            }
            else if (s[i] == s[j])
                result = Calculate(s, i+1, j-1, infos);
            else
            {
                var result1 = 1+ Calculate(s, i + 1, j, infos);
                var result2 = 1+ Calculate(s, i , j- 1, infos);
                result = Math.Min(result1, result2);
            }

            infos[i, j] = result;
            return result;
        }

        private bool IsPalindrome(string s)
        {
            if (s.Length == 0 || s.Length == 1)
                return true;
            int mid = s.Length / 2;
            for (int i = 0; i < mid; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                    return false;
            }
            return true;
        }
    }
}
