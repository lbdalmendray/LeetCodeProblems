using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertIntegertotheSumofTwoNo_ZeroIntegers
{
    public class Solution
    {
        public int[] GetNoZeroIntegers(int n)
        {
            for (int i = 1; i < n; i++)
            {
                if (IsNoZero(i) && IsNoZero(n - i))
                    return new int[] { i, n - i };
            }
            return null;
        }

        private bool IsNoZero(int i)
        {
            return i.ToString().All(e => e != '0');
        }
    }
}
