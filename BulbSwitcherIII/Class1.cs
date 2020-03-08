using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulbSwitcherIII
{
    public class Solution
    {
        public int NumTimesAllBlue(int[] light)
        {
            int max = -1;
            int count = 0;
            int result = 0;
            for (int i = 0; i < light.Length; i++)
            {
                max = Math.Max(light[i], max);
                count++;
                if (max == count)
                    result++;
            }

            return result;
        }
    }
}
