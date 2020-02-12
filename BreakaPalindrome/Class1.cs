using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakaPalindrome
{
    public class Solution
    {
        public string BreakPalindrome(string palindrome)
        {
            if (palindrome.Length == 1)
                return "";
            StringBuilder result = new StringBuilder(palindrome);
            int lastNotIndexToCheck = palindrome.Length / 2;

            for (int i = 0; i < lastNotIndexToCheck; i++)
            {
                if (result[i] != 'a')
                {
                    result[i] = 'a';
                    return result.ToString();
                }
            }

            result[result.Length - 1] = 'b';
            return result.ToString();
        }
    }
}
