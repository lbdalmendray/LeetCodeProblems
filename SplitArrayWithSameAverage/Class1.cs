using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitArrayWithSameAverage
{
    public class Solution
    {
        public bool SplitArraySameAverage(int[] A)
        {
            var average = A.Average();
            if (A.Any(e => e == average))
                return true;
            var deltas = A.Select(e => e - average);
            var bigDeltas = deltas.Where(e => e > 0).ToArray();
            var lowDeltas = deltas.Where(e => e < 0).ToArray();

            bool bigDeltasIsMin = bigDeltas.Length < lowDeltas.Length;
            uint Max = 0;
            Dictionary<double,int> hashset = null;
            if (bigDeltasIsMin)
            {
                Max = (uint)Math.Pow(2, bigDeltas.Length);
                hashset = new Dictionary<double,int>((int)Max - bigDeltas.Length);
                for (UInt32 i = 1; i <= Max; i++)
                {
                    var bitarrayIndexes = GetTrueIndexes(new BitArray(BitConverter.GetBytes(i)), bigDeltas.Length);
                    if (bitarrayIndexes.Count() == 0)
                    {
                        continue;
                    }

                    var sum = bitarrayIndexes.Select(index => bigDeltas[index]).Sum();
                    sum = Math.Round(sum, 4);
                    if (!hashset.ContainsKey(sum))
                    {
                        hashset.Add(sum,bitarrayIndexes.Count());
                    }
                }

                Max = (uint)Math.Pow(2, lowDeltas.Length);

                for (int i = 3; i <= Max; i++)
                {
                    var bitarrayIndexes = GetTrueIndexes(new BitArray(BitConverter.GetBytes(i)), lowDeltas.Length);
                    if (bitarrayIndexes.Count() == 0)
                    {
                        continue;
                    }

                    var sum = -bitarrayIndexes.Select(index => lowDeltas[index]).Sum();
                    sum = Math.Round(sum, 4);
                    if (hashset.ContainsKey(sum) && bitarrayIndexes.Count() + hashset[sum] < A.Length)
                    {
                        return true;
                    }
                }
            }
            else
            {
                Max = (uint)Math.Pow(2, lowDeltas.Length);
                hashset = new Dictionary<double, int>((int)Max - lowDeltas.Length);
                for (UInt32 i = 1; i <= Max; i++)
                {
                    var bitarrayIndexes = GetTrueIndexes(new BitArray(BitConverter.GetBytes(i)),lowDeltas.Length);
                    if(bitarrayIndexes.Count()==0)
                    {
                        continue;
                    }

                    var sum = -bitarrayIndexes.Select(index => lowDeltas[index]).Sum();
                    sum = Math.Round(sum, 4);
                    if (!hashset.ContainsKey(sum))
                    {
                        hashset.Add(sum,bitarrayIndexes.Count());
                    }                                       
                }

                Max = (uint)Math.Pow(2, bigDeltas.Length);

                for (int i = 1; i <= Max; i++)
                {
                    var bitarrayIndexes = GetTrueIndexes(new BitArray(BitConverter.GetBytes(i)), bigDeltas.Length);
                    if (bitarrayIndexes.Count() == 0)
                    {
                        continue;
                    }

                    var sum = bitarrayIndexes.Select(index => bigDeltas[index]).Sum();
                    sum = Math.Round(sum, 4);
                    if (hashset.ContainsKey(sum) && hashset[sum] + bitarrayIndexes.Count() < A.Length)
                    {
                        return true;
                    }
                }
            }     

            return false;
        }

        private IEnumerable<int> GetTrueIndexes(BitArray bitArray, int takeLength)
        {
            LinkedList<int> result = new LinkedList<int>();

            for (int i = 0; i < takeLength; i++)
            {
                if(bitArray[i])
                {
                    result.AddLast(i);
                }
            }

            return result;
        }

        public long GetMaximumCountPosibility()
        {
            for (int i = 0; i < 100; i++)
            {
                var bytes = BitConverter.GetBytes(i);
                BitArray bitarray = new BitArray(BitConverter.GetBytes(i));
            }

            long result = 0;
            int nValue = 0;
            int iValue = 0;
            for (int count = 4; count <= 30-2; count++)
            {
                for (int n = 2; n <= count-2 ; n++)
                {
                    for (int i = 2; i <= count - n; i++)
                    {
                        var resultAux = result;
                        result = (long)Math.Max(result, Math.Pow(2, n + i) - Math.Pow(2, n) * i - Math.Pow(2, i) * n + n * i);
                        /*
                        if(result != resultAux)
                        {
                            nValue = n;
                            iValue = i;
                        }
                        */
                    }
                }
            }

            return result;
        }
    }
}
