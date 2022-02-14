using System;
using System.Collections.Generic;
using System.Linq;

namespace KClosestPointstoOrigin
{
    public class Solution
    {
        public int[][] KClosest(int[][] points, int k)
        {
            SortedDictionary<int, int[]> dict = new SortedDictionary<int, int[]>(
                Comparer<int>.Create((a, b) => b - a));

            for (int i = 0; i < points.Length; i++)
            {
                var point = points[i];
                var distance = point[0] * point[0] + point[1] * point[1];
                if (dict.Count < k)
                {
                    dict.Add(distance, point);
                }
                else
                {
                    var first = dict.First();
                    if (first.Key > distance)
                    {
                        dict.Remove(first.Key);
                        dict.Add(distance, point);
                    }
                }
            }

            return dict.Select(kv => kv.Value).ToArray();
        }
    }
}
