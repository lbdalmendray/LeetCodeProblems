using System;
using System.Linq;

namespace ValidTriangleNumber
{
    public class Solution
    {
        public int TriangleNumber(int[] nums)
        {
            if (nums == null && nums.Length == 0)
                return 0;

            int result = 0;

            ////////////// COUNTER OF LENGTHS ///////////////// 

            int[] counter = new int[nums.Max() + 1];
            for (int i = 0; i < nums.Length; i++)
            {
                counter[nums[i]]++;
            }

            ////////////// SUMS FROM 0 to I index /////////////

            int[] sums = new int[counter.Length];
            sums[0] = counter[0];

            for (int i = 1; i < counter.Length; i++)
            {
                sums[i] += counter[i] + sums[i - 1];
            }

            ///////////// ALL LENGTHS DIFFERENTS TRIANGLES //////

            for (int i = 0; i < counter.Length-1; i++)
            {
                if (counter[i] == 0)
                    continue;

                for (int j = i+1; j < counter.Length; j++)
                {
                    if (counter[j] == 0)
                        continue;
                    
                    int length = i + j;
                    int cSum = GetSum(j + 1, length - 1, sums);
                    result += counter[i] * counter[j] * cSum;
                }
            }

            ///////////// JUST TWO EQUAL LENGTHS TRIANGLES ///////

            for (int i = 0; i < counter.Length; i++)
            {
                if (counter[i] < 2)
                    continue;

                int cPossibilities = counter[i] * (counter[i] - 1) / 2;

                int cSum = GetSum(1, i * 2 - 1, sums) - counter[i];
                result += cSum * cPossibilities;
            }

            ///////////// JUST THREE EQUAL LENGTHS TRIANGLES ///////

            for (int i = 0; i < counter.Length; i++)
            {
                if (counter[i] < 3)
                    continue;

                int cPossibilities = counter[i] * (counter[i] - 1) * (counter[i] - 2) / 6;
                result += cPossibilities;
            }

            ////////////////////////////////////////////////////////
            
            return result;

        }

        private int GetSum(int index1, int index2, int[] sums)
        {
            if (index2 >= sums.Length)
                index2 = sums.Length - 1;

            if (index1 <= 0)
                return sums[index2];
            return sums[index2] - sums[index1-1];
        }
    }
}
