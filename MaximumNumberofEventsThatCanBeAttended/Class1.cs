using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MaximumNumberofEventsThatCanBeAttended;

public class Solution
{
    public int MaxEvents(int[][] events)
    {
        int result = 0;
        Array.Sort(events, Comparer<int[]>.Create((e1, e2) =>
        {
            return e1[0] - e2[0];
        }));
        SortedDictionary<int, int[]> sortedDict = new ();

        int start0 = events[0][0];
        int i = 0;

        int currentDay = events[i][0];
        i = AddAllEqualToIndexIbyStartReturnNextIndex(i, events, sortedDict);
        
        while( sortedDict.Count > 0 || i < events.Length)
        {
            if ( sortedDict.Count == 0)
            {
                currentDay = events[i][0];
                i = AddAllEqualToIndexIbyStartReturnNextIndex(i, events, sortedDict);
            }

            var kv = sortedDict.First();
            /// REMOVE THIS ONE ////
            kv.Value[0]--;
            if (kv.Value[0] == 0)
            {
                sortedDict.Remove(kv.Key);
            }
            //////////////////////

            if (kv.Key >= currentDay)
            {
                result++;
                currentDay++;

                if (i < events.Length && currentDay == events[i][0])
                {
                    i = AddAllEqualToIndexIbyStartReturnNextIndex(i, events, sortedDict);
                }
            }
        }

        return result;
    }

    public int AddAllEqualToIndexIbyStartReturnNextIndex(int firstIndex, int[][] events, SortedDictionary<int, int[]> sortedDict)
    {
        int start = events[firstIndex][0];
        for (; firstIndex < events.Length; firstIndex++)
        {
            if (events[firstIndex][0] == start)
            {
                if (!sortedDict.TryGetValue(events[firstIndex][1], out var counter))
                {
                    counter = [0];
                    sortedDict.Add(events[firstIndex][1], counter);
                }
                counter[0]++;
            }
            else
                break;
        }
        return firstIndex;
    }
}
