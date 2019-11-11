using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountNumberofNiceSubarrays
{
    public class Solution
    {
        public int NumberOfSubarrays(int[] nums, int k)
        {
            LinkedList<Info> ranges = new LinkedList<Info>();
            int notOdds = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if( nums[i]%2 == 0 )
                {
                    notOdds++;
                }
                else
                {
                    ranges.AddLast(new Info { NotOdds = notOdds });
                    notOdds = 0;
                }
            }
            ranges.AddLast(new Info { NotOdds = notOdds });

            if (ranges.Count-1 < k)
                return 0;

            var firstNode = ranges.First;
            var lastNode = ranges.First;
            for (int i = 0; i < k-1; i++)
            {
                lastNode = lastNode.Next;
            }

            int result = 0;
            while(lastNode !=ranges.Last )
            {
                result += (firstNode.Value.NotOdds + 1) * (lastNode.Next.Value.NotOdds + 1);
                firstNode = firstNode.Next;
                lastNode = lastNode.Next;
            }

            return result;

        }
    }

    internal class Info
    {
        public int NotOdds { get; internal set; }
    }
}
