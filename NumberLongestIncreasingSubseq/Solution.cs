using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberLongestIncreasingSubseq
{
    public class Solution
    {
        public int FindNumberOfLIS(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            Tuple<int,int> [] countLengths = new Tuple<int,int>[nums.Length+1];
            countLengths[0] = new Tuple<int, int>(1,1);
            int lengthMax = 1;
            int countMax = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                int count = 1;
                int Length = 1;
                for (int j = i - 1; j > -1; j--)
                {
                    if (nums[j] < nums[i])
                    {
                        if (countLengths[j].Item2 + 1 == Length)
                        {
                            count += countLengths[j].Item1;
                        }
                        else if (countLengths[j].Item2 + 1 > Length)
                        {
                            count = countLengths[j].Item1;
                            Length = countLengths[j].Item2 + 1;
                        }
                    } 
                }
                countLengths[i] = new Tuple<int, int>(count, Length);
                if (lengthMax < Length)
                {
                    lengthMax = Length ;
                    countMax = count ;
                }
            }

            
            {
                int count = 1;
                int Length = 1;
                for (int j = nums.Length-1; j > -1; j--)
                {
                    // true
                    {
                        if (countLengths[j].Item2 + 1 == Length)
                        {
                            count += countLengths[j].Item1;
                        }
                        else if (countLengths[j].Item2 + 1 > Length)
                        {
                            count = countLengths[j].Item1;
                            Length = countLengths[j].Item2 + 1;
                        }
                    }
                }
                countLengths[nums.Length] = new Tuple<int, int>(count, Length);
                if (lengthMax < Length)
                {
                    lengthMax = Length;
                    countMax = count;
                }
            }

            return countMax;            
        }
    }
}
