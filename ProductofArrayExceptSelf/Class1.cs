using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductofArrayExceptSelf
{
    public class Solution
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            int[] result = new int[nums.Length];
            result[0] = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                result[i] = result[i - 1] * nums[i-1]; 
            }

            int right = 1;
            for (int i = nums.Length - 2 ; i > -1 ; i -- )
            {
                right *= nums[i + 1];
                result[i] *= right;
            }

            return result;
        }
    }
}
