using System;

namespace CountHillsandValleysinanArray
{
    public class Solution
    {
        public int CountHillValley(int[] nums)
        {
            int result = 0;

            int indexNotFirst = 0;

            for (; indexNotFirst < nums.Length; indexNotFirst++)
                if (nums[indexNotFirst] != nums[0])
                    break;

            for (int i = indexNotFirst; i < nums.Length; i++)
            {
                for (int j = i+1; j < nums.Length; j++)
                {
                    if( nums[i] != nums[j])
                    {
                        if( nums[i-1] < nums[i] && nums[j-1] > nums[j] )
                        {
                            result++;
                        }
                        else if (nums[i - 1] > nums[i] && nums[j - 1] < nums[j])
                        {
                            result++;
                        }
                        i = j-1;
                        break;
                    }
                }
            }

            return result;
        }
    }
}
