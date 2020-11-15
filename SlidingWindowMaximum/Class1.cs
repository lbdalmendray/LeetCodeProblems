using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlidingWindowMaximum
{
    public class Solution
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            int[] leftMax = new int[nums.Length];
            int[] rightMax = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                if (i % k == 0)
                    leftMax[i] = nums[i];
                else
                {
                    leftMax[i] = Math.Max(leftMax[i - 1], nums[i]);
                }    
            }

            rightMax[rightMax.Length - 1] = nums[nums.Length - 1];

            for (int i = rightMax.Length - 2; i > -1; i--)
            {
                if ( (i+1) % k == 0 )
                {
                    rightMax[i] = nums[i];
                }
                else
                {
                    rightMax[i] = Math.Max(rightMax[i + 1], nums[i]);
                }
            }
            int length = nums.Length - (k - 1);
            int[] result = new int[length];

            for (int i = 0; i < length; i++)
            {
                int rightPart = rightMax[i];
                int leftPart = leftMax[i + k - 1];
                int max = Math.Max(rightPart, leftPart);
                result[i] = max;
            }

            return result;            
        }
    }
}
