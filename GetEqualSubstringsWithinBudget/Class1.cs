using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetEqualSubstringsWithinBudget
{
    public class Solution
    {
        public int EqualSubstring(string s, string t, int maxCost)
        {
            if (s.Length == 0)
                return 0;
            int[] diff = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                diff[i] = Math.Abs(s[i] - t[i]);
            }

            int[] result = new int[diff.Length];
            int sum = 0;

            if( diff [0] <= maxCost)
            {
                sum = diff[0];
                result[0] = 1;
            }

            for (int i = 1; i < diff.Length; i++)
            {
                sum += diff[i];
                result[i] = result[i - 1] + 1;
                int j = i - result[i - 1];
                while (sum > maxCost && j <= i)
                {
                    sum -= diff[j];
                    result[i]--;
                    j++;
                }
            }           

            return result.Max();
        }
    }
}
