using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MaximumPerformanceofaTeam
{
    public class Solution
    {
        public int MaxPerformance(int n, int[] speed, int[] efficiency, int k)
        {
            Array.Sort(efficiency, speed, Comparer<int>.Create((a, b) => b - a));
            SortedDictionary<int, int[]> counter = new SortedDictionary<int, int[]>();

            BigInteger result = 0;
            BigInteger speedSum = 0;
            int counterCount = 0;

            for (int i = 0; i < speed.Length; i++)
            {
                if( counterCount == k)
                {
                    var keyValue = counter.First();
                    speedSum -= keyValue.Key;
                    if( keyValue.Value[0] == 1)
                    {
                        counter.Remove(keyValue.Key);
                    }
                    else
                    {
                        keyValue.Value[0]--;
                    }
                    counterCount--;
                }

                if ( !counter.TryGetValue(speed[i],out var currentArray))
                {
                    currentArray = new int[1] { 1 };
                    counter.Add(speed[i], currentArray);
                }
                else
                {
                    currentArray[0]++;
                }
                counterCount++;

                speedSum += speed[i];
                var resultNew = speedSum * efficiency[i];
                if (resultNew > result)
                    result = resultNew;
            }

            return ((int)(result % 1000000007));
        }

    }
}
