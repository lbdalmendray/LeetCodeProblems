using System;
using System.Linq;

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        var valueIndexes = nums.Select((v, index) => new { v, index }).ToArray();
        Array.Sort(nums, valueIndexes);
        nums = valueIndexes.Select(e => e.v).ToArray();

        if (nums.Length <= 1)
            return new int[0];
        int minimum = nums[0] + nums[1];
        int maximum = nums[nums.Length-2] + nums[nums.Length-1];
        if (target < minimum || target > maximum)
            return new int[0];

        for (int i = 0; i < valueIndexes.Length-1; i++)
        {
            int dif = target - valueIndexes[i].v;
            int result = Array.BinarySearch(nums, i + 1, valueIndexes.Length - i - 1, dif);
            if (result > -1)
                return new int[] { valueIndexes[i].index, valueIndexes[result].index };
        }

        return new int[0];
    }

    static void Main(string[] args)
    {
    }
}