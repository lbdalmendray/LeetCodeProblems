using System;
using System.Collections.Generic;
using System.Linq;

namespace FindingtheUsersActiveMinutes
{
    public class Solution
    {
        public int[] FindingUsersActiveMinutes(int[][] logs, int k)
        {
            Dictionary<int, HashSet<int>> info = new Dictionary<int, HashSet<int>>();

            foreach (var item in logs)
            {
                if ( !info.TryGetValue(item[0], out var set))
                {
                    set = new HashSet<int>();
                    info.Add(item[0],set);
                }
                set.Add(item[1]);
            }

            var result = new int[100000+1];

            foreach (var item in info)
            {
                result[item.Value.Count]++;
            }

            return result.Skip(1).Take(k).ToArray();
        }
    }
}
