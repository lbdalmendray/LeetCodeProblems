using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MaxPointsOnALine
{
    public class Solution
    {
        public int MaxPoints(int[][] points)
        {
            if (points == null || points.Length == 0)
                return 0;

            var pointAmounts = GetDifferentPointsAndAmount(points);

            int result = pointAmounts.Max(array => array[2]);

            Dictionary<decimal, List<int>>[] relations = new Dictionary<decimal, List<int>>[pointAmounts.Length];
            for (int i = 0; i < relations.Length; i++)
            {
                relations[i] = new Dictionary<decimal, List<int>>(pointAmounts.Length - i - 1);
            }

            for (int i = 0; i < pointAmounts.Length-1 ; i++)
            {
                for (int j = i+1 ; j < pointAmounts.Length ; j++)
                {
                    decimal angle = GetAngle(pointAmounts[i], pointAmounts[j]);
                    if( !relations[i].ContainsKey(angle))
                    {
                        relations[i].Add(angle, new List<int>(pointAmounts.Length - i - 1));
                    }
                    relations[i][angle].Add(j);
                }
            }

            for (int i = 0; i < relations.Length; i++)
            {
                var keys = relations[i].Keys.ToArray();
                for (int j = 0; j < keys.Length; j++)
                {
                    var key = keys[j];

                    var list = relations[i][key];
                    var count = GetCount(list, pointAmounts, pointAmounts[i]);
                    if (count > result)
                        result = count;
                    foreach (var index in list)
                    {
                        relations[index].Remove(key);
                    }

                    relations[i].Remove(key);
                }
            }

            return result;             
        }

        public int MaxPoints2(int[][] points) /// SOLUTION ALL POINTS DIFFERENTS  
        {
            if (points == null || points.Length == 0)
                return 0;

            //var pointAmounts = GetDifferentPointsAndAmount(points);

            int result = 1;

            Dictionary<decimal, List<int>>[] relations = new Dictionary<decimal, List<int>>[points.Length];
            for (int i = 0; i < relations.Length; i++)
            {
                relations[i] = new Dictionary<decimal, List<int>>(points.Length - i - 1);
            }

            for (int i = 0; i < points.Length - 1; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    decimal angle = GetAngle(points[i], points[j]);
                    if (!relations[i].ContainsKey(angle))
                    {
                        relations[i].Add(angle, new List<int>(points.Length - i - 1));
                    }
                    relations[i][angle].Add(j);
                }
            }

            for (int i = 0; i < relations.Length; i++)
            {
                var keys = relations[i].Keys.ToArray();
                for (int j = 0; j < keys.Length; j++)
                {
                    var key = keys[j];

                    var list = relations[i][key];
                    var count = 1 + list.Count;
                    if (count > result)
                        result = count;
                    foreach (var index in list)
                    {
                        relations[index].Remove(key);
                    }

                    relations[i].Remove(key);
                }
            }

            return result;
        }

        private int GetCount(List<int> list, int[][] pointAmounts, int[] pointValue)
        {
            int result = pointValue[2];

            foreach (var index in list)
            {
                result += pointAmounts[index][2];
            }

            return result;
        }

        private int[][] GetDifferentPointsAndAmount(int[][] points)
        {
            Dictionary<int, Dictionary<int, int>> counter = new Dictionary<int, Dictionary<int, int>>();
            for (int i = 0; i < points.Length; i++)
            {
                if (!counter.ContainsKey( points[i][0]))
                {
                    counter.Add(points[i][0], new Dictionary<int, int>());
                }
                if(! counter[points[i][0]].ContainsKey(points[i][1]))
                {
                    counter[points[i][0]].Add(points[i][1], 1);
                }
                else
                    counter[points[i][0]][points[i][1]]++;
            }
            List<int[]> result = new List<int[]>();

            foreach (var key1 in counter.Keys)
            {
                foreach (var key2 in counter[key1].Keys)
                {
                    result.Add(new int[] { key1 , key2 , counter[key1][key2] });
                }
            }

            return result.ToArray();
        }

        private decimal GetAngle(int[] point1, int[] point2)
        {
            if (point1[0] == point2[0])
                return (decimal)(Math.PI / 2);

            int[] pointMin; 
            int[] pointMax;

            if( point1[1] < point2[1] )
            {
                pointMin = point1;
                pointMax = point2;
            }
            else if( point2[1] < point1[1])
            {
                pointMin = point2;
                pointMax = point1;
            }
            else
            {
                return 0;
            }

            return ((decimal)(pointMax[1] - pointMin[1]) )/ ((decimal)(pointMax[0] - pointMin[0]));
        }
    }
}
