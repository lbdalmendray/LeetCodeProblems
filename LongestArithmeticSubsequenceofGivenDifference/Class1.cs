using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestArithmeticSubsequenceofGivenDifference
{
    public class Solution
    {
        public int LongestSubsequence(int[] arr, int difference)
        {
            if (arr.Length == 0)
                return 0;

            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = arr.Length -1 ; i >  -1 ; i-- )
            {
                var value = arr[i];
                if( ! dict.ContainsKey(value) )
                {
                    if(dict.ContainsKey(value + difference))
                    {
                        dict[value] = 1 + dict[value + difference];
                    }
                    else
                    {
                        dict[value] = 1;
                    }
                }
                else
                {
                    if (dict.ContainsKey(value + difference))
                    {
                        dict[value] = Math.Max  ( 1 + dict[value + difference],dict[value]);
                    }                    
                }
            }

            return dict.Values.Max();
        }
    }
}
