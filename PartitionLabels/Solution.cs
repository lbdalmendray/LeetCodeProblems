using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartitionLabels
{
    public class Solution
    {
        public IList<int> PartitionLabels(string S)
        {

            int[] maxIndex = new int[26];

            for (int i = 0; i < S.Length; i++)
            {
                maxIndex[S[i] - 'a'] = i;
            }

            int firstIndex = -1;
            int lastIndex = -1;
            int countPart = 0;

            LinkedList<int> result = new LinkedList<int>();

            for (; firstIndex < S.Length; firstIndex++)
            {
                if (firstIndex == lastIndex)
                {
                    firstIndex++;
                    if (firstIndex >= S.Length)
                        break;
                    lastIndex = maxIndex[S[firstIndex] - 'a'];
                    countPart = lastIndex - firstIndex + 1;
                    result.AddLast(countPart);
                    if (firstIndex == lastIndex)
                        firstIndex--;
                }
                else if (maxIndex[S[firstIndex] - 'a'] > lastIndex)
                {
                    result.Last.Value += maxIndex[S[firstIndex] - 'a'] - lastIndex;
                    lastIndex = maxIndex[S[firstIndex] - 'a'];
                }
            }
            return result.ToList();


        }
    }
}
