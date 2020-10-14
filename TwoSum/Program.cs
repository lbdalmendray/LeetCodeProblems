using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    /// <summary>
    /// O(N) Complexity Time 
    /// O(N) Complexity Space
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int value = nums[i];
            int diff = target - value;

            if ( dict.TryGetValue(diff, out var diffIndex))
            {
                return new int[] { diffIndex, i };
            }
            else
            {
                if (!dict.ContainsKey(value))
                    dict.Add(value, i);
            }            
        }

        return new int[0];
    }

    public int[] TwoSum1(int[] nums, int target)
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