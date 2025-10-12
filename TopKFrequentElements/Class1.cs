using System.Runtime.InteropServices;

namespace TopKFrequentElements;

public class Solution
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        Dictionary<int, int[]> counterDict = new();
        for (int i = 0; i < nums.Length; i++)
        {
            int num = nums[i];
            if ( counterDict.TryGetValue(num, out var counterArray))
            {
                counterArray[0]++;
            }
            else
            {
                counterArray = new int[1] { 1 };
                counterDict.Add(num, counterArray);
            }
        }

        List<int>[] CounterGroups = new List<int>[(nums.Length + 1)];


        foreach (var counterKV in counterDict)
        {
            if (CounterGroups[counterKV.Value[0]] == null)
                CounterGroups[counterKV.Value[0]] = new();
            CounterGroups[counterKV.Value[0]].Add(counterKV.Key); 
        }

        List<int> result = new List<int>();

        for (int i = CounterGroups.Length - 1;
            i > -1 && result.Count < k; i--)
        {
            if (CounterGroups[i] != null)
                result.AddRange(CounterGroups[i]);
        }

        return result
            // .Take(k) // IT IS NOT NECESSARY BECAUSE THERE IS ONLY ONE SOLUTION,
                        // SO IT IS NOT POSSIBLE TO ADD X AMOUNT OF VALUES TO result
                        // THAT EXCEEDS k WHEM result HAD Y ELEMENTS BECAUSE THAT MEANS
                        // THAT THERE WOULD SOME ELEMENTS IN X, LET SAY X1 ELEMENTS
                        // ( WHERE X1 < X ) THAT CAN BE ADDED TO Y SO X1 + Y = K BUT IF WE
                        // TAKE ANY ELEMENT OF X - X1 AND REPLACE ANY ELEMENT OF X1 THEN 
                        // WE CAN CREATE ANOTHER SOLUTION X1REPLACED + Y, AND IT IS
                        // NOT POSSIBLE.
            .ToArray();

    }

    public int[] TopKFrequent1(int[] nums, int k)
    {
        Dictionary<int, int[]> dictCounter = new();


        /// O(N)
        for (int i = 0; i < nums.Length; i++)
        {
            int num = nums[i];
            if (dictCounter.TryGetValue(num, out var counterArray))
            {
                counterArray[0]++;
            }
            else
            {
                counterArray = new int[1] { 1 };
                dictCounter[num] = counterArray;
            }                
        }

        HashSet<int> assignedNumbers = new HashSet<int>(k);
        SortedDictionary<int, List<int>> sortedDict = new();

        //// O(N*LOG(K))
        for (int i = 0; i < nums.Length; i++)
        {
            var num = nums[i];

            if (assignedNumbers.Count < k)
            {
                if (assignedNumbers.Add(num))
                {
                    int counter = dictCounter[num][0];

                    if (!sortedDict.TryGetValue(counter, out var set))
                    {
                        set = new List<int>();
                        sortedDict.Add(counter, set);
                    }
                    set.Add(num);
                }
            }
            else if (assignedNumbers.Contains(num))
                continue;
            else
            {
                int counter = dictCounter[num][0];

                var firstKV = sortedDict.First();
                if ( firstKV.Key < counter)
                {
                    var toRemove = firstKV.Value[firstKV.Value.Count-1];
                    assignedNumbers.Remove(toRemove);
                    firstKV.Value.RemoveAt(firstKV.Value.Count - 1);
                    if ( firstKV.Value.Count == 0)
                    {
                        sortedDict.Remove(firstKV.Key);
                    }

                    if (!sortedDict.TryGetValue(counter, out var set))
                    {
                        set = new List<int>();
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
