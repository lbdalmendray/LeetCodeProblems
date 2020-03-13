using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowManyNumbersAreSmallerThantheCurrentNumber
{
    public class Solution
    {
        public int[] SmallerNumbersThanCurrent(int[] nums)
        {
            SortedDictionary<int, LinkedList<int>> sorted = new SortedDictionary<int, LinkedList<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!sorted.TryGetValue(nums[i], out var linkedList))
                {
                    linkedList = new LinkedList<int>();
                    sorted.Add(nums[i], linkedList);
                }
                linkedList.AddLast(i);
            }
            int[] result = new int[nums.Length];
            var sortedArray =sorted.ToArray();
            int[] counter = new int[sortedArray.Length];
            counter[0] = sortedArray[0].Value.Count;
            for (int i = 1; i < sortedArray.Length; i++)
            {
                counter[i] = counter[i - 1] + sortedArray[i].Value.Count;
            }

            for (int i = 1; i < sortedArray.Length; i++)
            {
                foreach (var index in sortedArray[i].Value)
                {
                    result[index] = counter[i - 1];
                }
            }

            return result;
        }
    }
}
