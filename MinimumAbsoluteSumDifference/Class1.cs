using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimumAbsoluteSumDifference
{
    public class Solution
    {
        public int MinAbsoluteSumDiff(int[] nums1, int[] nums2)
        {
            var nums1Sorted = nums1.Select(e => e).ToArray();
            nums1Sorted = ArraySort(nums1Sorted);
            List<Info2>[] array = new List<Info2>[100000 + 1];
            FillInfo2ToArray(nums1Sorted,array);
            FillInfo2ToArrayFromNums2(array, nums2);

            Info2[] v2Minimums = new Info2[nums2.Length];
            CalculateMinimums(v2Minimums, array);
            int value = GetTheMinimumMinimums(v2Minimums, nums1 , nums2);

            int result = 0;
            for (int i = 0; i < nums1.Length; i++)
            {
                result += Math.Abs(nums1[i] - nums2[i]);
                result = result % (1000000007);
            }

            result -= value;

            return result;

        }

        private int GetTheMinimumMinimums(Info2[] v2Minimums, int[] nums1, int[] nums2)
        {
            int result = int.MinValue;

            for (int i = 0; i < v2Minimums.Length; i++)
            {
                var cValue = Math.Abs(nums1[i] - nums2[i]);
                var cNewValueMin = Math.Abs(nums2[i] - v2Minimums[i].NewV1Min);
                var cNewValueMax = Math.Abs(nums2[i] - v2Minimums[i].NewV1Max);

                int min = Math.Min(cNewValueMax, cNewValueMin);
                if (min <= cValue)
                    result = Math.Max(result, cValue - min);                
            }

            return result;
        }

        private void CalculateMinimums(Info2[] v2Minimums, List<Info2>[] array)
        {
            LeftToRight( array);
            RightToLeft(v2Minimums, array);


        }

        private void RightToLeft(Info2[] v2Minimums, List<Info2>[] array)
        {
            int maxValue = int.MaxValue;

            for (int i = array.Length - 1 ; i >= 0 ; i--)
            {
                if (array[i] != null)
                    foreach (var item in array[i])
                    {
                        if (item.Type == Type.V1)
                            maxValue = i;
                        else
                        {
                            item.NewV1Max = maxValue;
                            v2Minimums[item.Index] = item;
                        }
                    }
            }
        }

        private void LeftToRight( List<Info2>[] array)
        {
            int minValue = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                    foreach (var item in array[i])
                    {
                        if (item.Type == Type.V1)
                            minValue = i;
                        else
                        {
                            item.NewV1Min = minValue;
                        }
                    }
            }
        }

        private void FillInfo2ToArrayFromNums2(List<Info2>[] array, int[] nums2)
        {
            for (int i = 0; i < nums2.Length; i++)
            {
                var value2 = nums2[i];
                if (array[value2] == null)
                    array[value2] = new List<Info2>();
                array[value2].Add(new Info2 { Type = Type.V2 , Index = i  });
            }
        }

        private void FillInfo2ToArray(int[] nums1Sorted, List<Info2>[] array)
        {
            foreach (var item in nums1Sorted)
            {
                array[item] = new List<Info2>(new Info2[] {
                new Info2
                {
                    Type = Type.V1
                }
                });
            }
        }

        public int MinAbsoluteSumDiff1(int[] nums1, int[] nums2)
        {
            var nums1Sorted = nums1.Select(e => e).ToArray();
            nums1Sorted = ArraySort(nums1Sorted);
            Dictionary<int, int> positions = new Dictionary<int, int>();
            for (int i = 0; i < nums1Sorted.Length; i++)
            {
                positions[nums1Sorted[i]] = i;
            }
            var values = GetValues(nums1, nums2, nums1Sorted , positions).ToArray();

            var max = values.First();

            foreach (var item in values.Skip(1))
            {
                if( max.Value(nums1,nums2) < item.Value(nums1, nums2))
                {
                    max = item;
                }
            }

            nums1[max.Index] = max.V1;
            int result = 0;
            for (int i = 0; i < nums1.Length; i++)
            {
                result += Math.Abs(nums1[i] - nums2[i]);
                result = result % (1000000007);
            }

            return result;
        }

        private int[] ArraySort(int[] nums1Sorted)
        {
            int[] result = new int[100000+1];
            
            foreach (var item in nums1Sorted)
            {
                result[item]++;
            }
            return result.Select((e, i) => new { e, i }).Where(e => e.e > 0).Select(e => e.i).ToArray();
        }

        private IEnumerable<Info> GetValues(int[] nums1, int[] nums2, int[] nums1Sorted, Dictionary<int, int> positions)
        {
            for (int i = 0; i < nums1.Length; i++)
            {
                yield return GenerateInfo(nums1[i], nums2[i], nums1Sorted, positions, i);
            }
        }

        private Info GenerateInfo(int v1, int v2, int[] nums1Sorted, Dictionary<int, int> positions , int index)
        {
            if (v1 < v2)
            {
                int v1Result1 = BiSearchMaxV1(v1,v2, nums1Sorted, positions);
                int v1Result2 = BiSearchMinV1(v2,nums1Sorted[nums1Sorted.Length-1], nums1Sorted, positions);
                int cResult = v1Result2;
                if (v2 - v1Result1 < v1Result2 - v2)
                    cResult = v1Result1;
                return new Info { V1 = cResult, Index = index };
            }
            else if (v1 > v2)
            {
                int v1Result1 = BiSearchMaxV1(nums1Sorted[0],v2, nums1Sorted, positions);
                int v1Result2 = BiSearchMinV1(v2, v1, nums1Sorted, positions);
                int cResult = v1Result2;
                if (v2 - v1Result1 < v1Result2 - v2)
                    cResult = v1Result1;
                return new Info { V1 = cResult, Index = index };
            }
            else
                return new Info { V1 = v1, Index = index };
        }

        private int BiSearchMaxV1(int v1, int v2, int[] nums1Sorted, Dictionary<int,int> positions)
        {
            if (positions.ContainsKey(v2))
                return v2;

            int minIndex = positions[v1];
            int maxIndex = nums1Sorted.Length - 1;
            int medIndex = (maxIndex + minIndex) / 2;

            while (maxIndex - minIndex > 3)
            {
                if( nums1Sorted[medIndex] <= v2)
                {
                    minIndex = medIndex;
                }
                else
                {
                    maxIndex = medIndex - 1;
                }
            }

            for (int i = maxIndex; i >= minIndex; i--)
            {
                if (nums1Sorted[i] <= v2)
                    return nums1Sorted[i];
            }
            return v1;
        }

        private int BiSearchMinV1(int v2, int v1, int[] nums1Sorted, Dictionary<int, int> positions)
        {
            if (positions.ContainsKey(v2))
                return v2;

            int maxIndex = positions[v1];
            int minIndex = 0;
            int medIndex = (maxIndex + minIndex) / 2;

            while (maxIndex - minIndex > 3)
            {
                if (nums1Sorted[medIndex] >= v2)
                {
                    maxIndex = medIndex;
                }
                else
                {
                    minIndex = medIndex + 1;
                }
            }

            for (int i = minIndex; i <= maxIndex; i++)
            {
                if (nums1Sorted[i] >= v2)
                    return nums1Sorted[i];
            }
            return v1;
        }
    }

    internal class Info2
    {
        public Type Type { get; internal set; }
        public int Index { get; internal set; }
        public int NewV1Max { get; internal set; }
        public int NewV1Min { get; internal set; }
    }

    internal class Info
    {
        public int V1 { get; internal set; }
        public int Index { get; internal set; }


        internal int Value(int[] nums1, int[] nums2)
        {
            return Math.Abs(nums1[Index] - nums2[Index]);
        }
    }

    internal enum Type
    {
        V1,
        V2
    }
}
