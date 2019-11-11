using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIfItIsaGoodArray
{
    public class Solution
    {
        public bool IsGoodArray(int[] nums)
        {
            return GCD(nums) == 1;
        }

        static int GCD(int[] numbers)
        {
            return numbers.Aggregate(GCD);
        }

        static int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
    }
}
