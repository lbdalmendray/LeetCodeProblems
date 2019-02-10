using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxChunksToSorted
{
    public class Solution
    {
        public int MaxChunksToSorted(int[] arr)
        {

            int[] relation = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                relation[arr[i]] = i;
            }

            int currentMaxIndex = -1;
            int chunksCount = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (currentMaxIndex < relation[i])
                {
                    currentMaxIndex = relation[i];
                }

                if (currentMaxIndex == i)
                {
                    chunksCount++;
                }
            }

            return chunksCount;
        }
    }
}
