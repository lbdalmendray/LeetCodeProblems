using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxNumberofKSumPairs
{
    public class Solution
    {
        public int MaxOperations(int[] nums, int k)
        {
            int result = 0;
            Dictionary<int, int[]> dict = new Dictionary<int, int[]>(100000);
            foreach (var item in nums)
            {
                int second = k - item;

                if (dict.TryGetValue(second, out var counter))
                {
                    counter[0]--;
                    result++;
                    if (counter[0] == 0)
                        dict.Remove(second);
                }
                else
                {
                    if( dict.TryGetValue(item, out counter))
                    {
                        counter[0]++;
                    }
                    else
                    {
                        dict[item] = new int[] { 1 };
                    }
                }
            }


            return result;
        }

        public int MaxOperations1(int[] nums, int k)
        {
            int result = 0;
            Dictionary<int, int[]> dict = new Dictionary<int, int[]>(100000);
            foreach (var item in nums)
            {
                if (dict.TryGetValue(item, out int[] counter))
                {
                    counter[0]++;
                }
                else
                {
                    counter = new int[] { 1 };
                    dict[item] = counter;
                }
            }

            while (dict.Count != 0)
            {
                var keyValue = dict.First();
                int first = keyValue.Key;
                int second = k - first;

                if (first == second)
                {
                    int count = keyValue.Value[0] / 2;
                    if (count > 0)
                    {
                        result += count;
                    }
                    dict.Remove(keyValue.Key);
                }
                else
                {
                    if (!dict.TryGetValue(second, out int[] count2))
                    {
                        dict.Remove(keyValue.Key);
                    }
                    else
                    {
                        int count1 = keyValue.Value[0];
                        int count = Math.Min(count1, count2[0]);
                        if (count > 0)
                        {
                            result += count;
                        }
                        dict.Remove(keyValue.Key);
                        dict.Remove(second);
                    }
                }

            }

            return result;
        }
    }
}
