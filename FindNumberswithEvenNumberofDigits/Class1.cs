using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindNumberswithEvenNumberofDigits
{
    public class Solution
    {
        public int FindNumbers(int[] nums)
        {
            return nums.Where(e => e.ToString().Length % 2 == 0).Count();
        }
    }
}
