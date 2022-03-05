using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KClosestPointstoOrigin
{
    public class Solution2
    {
        public int[][] KClosest(int[][] points, int k)
        {
            var pointDistanceList = points.Select(p => new PointDistancePair(p, Distance2(p)));

            SortedDictionary<int, LinkedList< PointDistancePair > > sortedSet
                = new SortedDictionary<int, LinkedList<PointDistancePair >>
                (
                   Comparer<int>.Create(
                       (a, b) => (b - a)
                       )
                    );

            int counter = 0;

            foreach (PointDistancePair pointDistance in pointDistanceList)
            {
                if (counter < k)
                {
                    if (!sortedSet.TryGetValue(pointDistance.Distance2, out var list))
                    {
                        list = new LinkedList<PointDistancePair>();
                        sortedSet.Add(pointDistance.Distance2, list);
                    }
                    list.AddLast(pointDistance);
                    counter++;
                }
                else
                {
                    var kv = sortedSet.First();
                    if ( pointDistance.Distance2 < kv.Key)
                    {
                        kv.Value.RemoveLast();
                        if( kv.Value.Count == 0)
                        {
                            sortedSet.Remove(kv.Key);
                        }

                        if (!sortedSet.TryGetValue(pointDistance.Distance2, out var list))
                        {
                            list = new LinkedList<PointDistancePair>();
                            sortedSet.Add(pointDistance.Distance2, list);
                        }
                        list.AddLast(pointDistance);
                    }
                }
            }

            List<int[]> result = new List<int[]>();
            foreach (var kv in sortedSet)
            {
                foreach (var item in kv.Value)
                {
                    result.Add(item.Point);
                }
            }

            return result.ToArray();
        }

        private int Distance2(int[] point)
        {
            return point[0] * point[0] + point[1] * point[1];
        }
    }

    internal class PointDistancePair
    {
        public int[] Point { get; }
        public int Distance2 { get; }
        internal PointDistancePair(int [] point, int distance2)
        {
            this.Point = point;
            this.Distance2 = distance2;
        }
    }
}
