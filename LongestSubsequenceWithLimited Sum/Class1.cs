using System.Diagnostics.Contracts;
using System.Reflection.Metadata.Ecma335;

namespace LongestSubsequenceWithLimited_Sum
{
    public class Solution
    {
        /*
         Constraints:
                n == nums.length
                m == queries.length
                1 <= n, m <= 1000
                1 <= nums[i], queries[i] <= 10^6


         O(n*log(n))
         
         */
        public int[] AnswerQueries(int[] nums, int[] queries)
        {
            Array.Sort(nums);
            var queryTuples = queries
                .Select((e, i) => new { e = e, i = i })
                .ToArray();
            Array.Sort(queries, queryTuples);
            int numsSum = nums.Sum();
            int counter = nums.Length;
            int[] result = new int[queries.Length];
            int numsIndex = nums.Length - 1;

            for (int i = queryTuples.Length-1; i > -1; i--)
            //foreach (var tuple in queryTuples.Reverse())
            {
                var tuple = queryTuples[i];
                while (numsSum > 0 && numsSum > tuple.e)
                {
                    numsSum -= nums[numsIndex--];
                    counter--;
                }
                if (numsSum == 0)
                    return result;
                else
                {
                    result[tuple.i] = counter;
                }
            }
            return result;
        }

        private readonly int maxLength = 1000_000 + 1;
        /*
         Constraints:
                n == nums.length
                m == queries.length
                1 <= n, m <= 1000
                1 <= nums[i], queries[i] <= 10^6
        O(N)
         */
        public int[] AnswerQueries2(int[] nums, int[] queries)
        {
            int[] result = new int[queries.Length];
            /// SORTING THE NUMS
            int[] numCounterArray = new int[maxLength];
            foreach (var num in nums)
            {
                numCounterArray[num]++;
            }
            /// SORTING THE QUERIES
            List<int>[] queryListArray = new List<int>[maxLength];
            for (int i = 0; i < queries.Length; i++)
            {
                if (queryListArray[queries[i]] == null)
                    queryListArray[queries[i]] = new List<int>();
                queryListArray[queries[i]].Add(i);
            }

            int counter = nums.Length;
            int numsSum = nums.Sum();
            int numCounterArrayIndex = numCounterArray.Length - 1;
            numCounterArray[numCounterArrayIndex]++;
            GetNextValue(numCounterArray, ref numCounterArrayIndex);

            for (int i = maxLength - 1; i > 0; i--)
            {
                if (queryListArray[i] != null)
                {
                    while (numsSum > 0 && numsSum > i && numCounterArrayIndex > 0)
                    {
                        numsSum -= numCounterArrayIndex;
                        counter--;

                        if (!GetNextValue(numCounterArray, ref numCounterArrayIndex))
                        {
                            return result;
                        }
                    }

                    foreach (var queryIndex in queryListArray[i])
                    {
                        result[queryIndex] = counter;
                    }
                }
            }

            return result;
        }

        private bool GetNextValue(int[] numCounterArray, ref int numCounterArrayIndex)
        {
            numCounterArray[numCounterArrayIndex]--;
            while (numCounterArrayIndex > 0 && numCounterArray[numCounterArrayIndex] == 0)
            {
                numCounterArrayIndex--;
            }
            return numCounterArrayIndex > 0;
        }
    }
}