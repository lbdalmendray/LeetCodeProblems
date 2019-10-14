using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitaStringinBalancedStrings
{
    public class Solution
    {
        public int BalancedStringSplit(string s)
        {
            if (s == null || s.Length == 0)
                return 0;
            int sum = 0;
            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'L')
                {
                    sum++;
                }
                else
                    sum--;

                if ( sum == 0 )
                {
                    result++;
                }                
            }
            return result; 
        }
    }
}
