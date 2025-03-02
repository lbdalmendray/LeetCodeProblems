using System.Runtime.InteropServices;

namespace TopKFrequentElements;

public class Solution
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        /// CONSTANT OPERATIONS 
        int[] positiveIntCounterArray = new int[10_000];
        int[] negativeIntCounterArray = new int[10_000];
        ////////////////////////////////////////////////

        /// O(N)
        for (int i = 0; i < nums.Length; i++)
        {
            int num = nums[i];
            if (num >= 0)
                positiveIntCounterArray[num]++;
            else
            {
                negativeIntCounterArray[Math.Abs(num)]++;
            }
        }

        HashSet<int> assignedNumbers = new HashSet<int>(k);
        SortedDictionary<int, HashSet<int>> sortedDict = new();

        //// O(N*LOG(K))
        for (int i = 0; i < nums.Length; i++)
        {
            var num = nums[i];

            if (assignedNumbers.Count < k)
            {
                assignedNumbers.Add(num);
                int counter = num >= 0 ? positiveIntCounterArray[num]
                                        : negativeIntCounterArray[Math.Abs(num)];

                if ( !sortedDict.TryGetValue(counter, out var set))
                {
                    set = new HashSet<int>();
                    sortedDict.Add(counter, set);
                }
                set.Add(num);
            }
            else if (assignedNumbers.Contains(num))
                continue;
            else
            {
                int counter = num >= 0 ? positiveIntCounterArray[num] 
                                       : negativeIntCounterArray[Math.Abs(num)];

                var firstKV = sortedDict.First();
                if ( firstKV.Key < counter)
                {
                    var toRemove = firstKV.Value.First();
                    assignedNumbers.Remove(toRemove);
                    firstKV.Value.Remove(toRemove);
                    if ( firstKV.Value.Count == 0)
                    {
                        sortedDict.Remove(firstKV.Key);
                    }

                    if (!sortedDict.TryGetValue(counter, out var set))
                    {
                        set = new HashSet<int>();
                        sortedDict.Add(counter, set);
                    }
                    set.Add(num);
                    assignedNumbers.Add(num);
                }
            }
        }

        return assignedNumbers.ToArray();
    }
}
