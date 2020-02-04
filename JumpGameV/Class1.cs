using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpGameV
{
    public class Solution
    {
        public int MaxJumps(int[] arr, int d)
        {
            int?[] infos = new int?[arr.Length];
            
            int result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int cResult = 1 + MaxJumps(i, arr, d, infos);
                if (result < cResult)
                    result = cResult;
            }

            return result;
        }

        private int MaxJumps(int index, int[] arr, int d, int?[] infos)
        {
            if (infos[index].HasValue)
                return infos[index].Value;

            int result = 0;

            int maxIndex = Math.Min(arr.Length - 1, index + d);

            for (int i = index+1; i <= maxIndex; i++)
            {
                if (arr[index] > arr[i])
                {
                    var cResult = 1 + MaxJumps(i, arr, d, infos);
                    if (cResult > result)
                        result = cResult;
                }
                else
                    break;
            }


            int minIndex = Math.Max(0, index - d);

            for (int i = index - 1 ; i >= minIndex; i--)
            {
                if (arr[index] > arr[i])
                {
                    var cResult = 1 + MaxJumps(i, arr, d, infos);
                    if (cResult > result)
                        result = cResult;
                }
                else
                    break;
            }

            infos[index] = result;
            return result;
        }
    }
}
