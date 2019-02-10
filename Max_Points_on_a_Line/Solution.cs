using System;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max_Points_on_a_Line
{
    /**
 * Definition for a point.
 * public class Point {
 *     public int x;
 *     public int y;
 *     public Point() { x = 0; y = 0; }
 *     public Point(int a, int b) { x = a; y = b; }
 * }
 */
    public class Solution
    {
        public int MaxPoints(Point[] points)
        {
            if (points.Length == 0)
                return 0;
            else if (points.Length == 1)
                return 1;

            var pointRepeted = SortPoints(points);
            int max = 0;
            for (int i = 0; i < pointRepeted.Length - 1; i++)
            {
                var rest = pointRepeted.Skip(i + 1).ToArray();
                var maxCurrent = PendentRepetition(pointRepeted[i], rest).Max(v => v.Value);
                if (maxCurrent > max)
                    max = maxCurrent;
            }

            var maxCurrent2 = pointRepeted[pointRepeted.Length - 1].Item2;
            if (maxCurrent2 > max)
                max = maxCurrent2;


            return max;
        }

        public IEnumerable<KeyValuePair<double?, int>> PendentRepetition(Tuple<Point, int> point, Tuple<Point, int>[] points)
        {
            SortedDictionary<double?, int> dictPendent = new SortedDictionary<double?, int>();
            dictPendent.Add(double.PositiveInfinity, point.Item2);
            foreach (var pointCurrentTuple in points)
            {
                double? m = double.NaN;
                Point pointCurrent = pointCurrentTuple.Item1;
                if (pointCurrent.x - point.Item1.x != 0)
                    m = ((double)(pointCurrent.y - point.Item1.y)) / ((double)(pointCurrent.x - point.Item1.x));

                if (!dictPendent.ContainsKey(m))
                {
                    dictPendent.Add(m, point.Item2);
                }

                dictPendent[m] += pointCurrentTuple.Item2;
            }
            return dictPendent.AsEnumerable();
        }

        public Tuple<Point, int>[] SortPoints(Point[] points)
        {
            LinkedList<Tuple<Point, int>> result = new LinkedList<Tuple<Point, int>>();

            SortedDictionary<int, SortedDictionary<int, int>> dictPoints = new SortedDictionary<int, SortedDictionary<int, int>>();
            foreach (var point in points)
            {
                if (!dictPoints.ContainsKey(point.x))
                {
                    dictPoints.Add(point.x, new SortedDictionary<int, int>());
                }
                var dictLevel2 = dictPoints[point.x];

                if (!dictLevel2.ContainsKey(point.y))
                {
                    dictLevel2.Add(point.y, 0);
                }

                dictLevel2[point.y]++;
            }

            foreach (var dictLevelTwo in dictPoints)
            {
                foreach (var keyValue in dictLevelTwo.Value)
                {
                    result.AddLast(new Tuple<Point, int>(new Point(dictLevelTwo.Key, keyValue.Key), keyValue.Value));
                }
            }

            return result.ToArray();
        }
    }

    public class Point
    {
        public int x;
        public int y;
        public Point ( int x , int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
