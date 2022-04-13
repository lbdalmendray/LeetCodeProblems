using System;
using System.Collections.Generic;
using System.Linq;

namespace OddEvenJump
{
    public class Solution
    {
        public int OddEvenJumps(int[] arr)
        {
            // TODO: GetOddJumpValuesFrom
            int[] oddJumpsNextIndex =  GetOddJumpNextIndexFrom(arr);
            // TODO: GetEvenJumpValuesFrom
            int[] evenJumpsNextIndex =  GetEvenJumpNextIndexFrom(arr);

            bool[] oddJumpsResult = new bool[arr.Length];
            bool[] evenJumpsResult = new bool[arr.Length];
            oddJumpsResult[oddJumpsResult.Length - 1] = true;
            evenJumpsResult[evenJumpsResult.Length - 1] = true;

            for (int i = oddJumpsResult.Length - 2; i > -1; i--)
            {
                if (oddJumpsNextIndex[i] != -1)
                {
                    oddJumpsResult[i] = evenJumpsResult[oddJumpsNextIndex[i]];
                }
                if (evenJumpsNextIndex[i] != -1)
                {
                    evenJumpsResult[i] = oddJumpsResult[evenJumpsNextIndex[i]];
                }
            }

            return oddJumpsResult.Where(e => e).Count();
        }

        private int[] GetEvenJumpNextIndexFrom(int[] arr)
        {
            var infoList = arr.Select((v,i)=>new Info { Value = v , Index = i })
               .OrderByDescending(e => e.Value);

            return GetJumpNextIndexFrom(infoList, arr.Length);
        }

        private int[] GetOddJumpNextIndexFrom(int[] arr)
        {
            var infoList = arr.Select((v, i) => new Info { Value = v, Index = i })
               .OrderBy(e => e.Value);
            return GetJumpNextIndexFrom(infoList, arr.Length);
        }

        private int [] GetJumpNextIndexFrom(IEnumerable<Info> infoList, int arrLength)
        {
            int[] result = Enumerable.Repeat(-1, arrLength).ToArray();

            LinkedList<Info> queue = new LinkedList<Info>();

            foreach (var info in infoList)
            {
                while (queue.Count != 0 && queue.Last.Value.Index < info.Index)
                {
                    result[queue.Last.Value.Index] = info.Index;
                    queue.RemoveLast();
                }
                queue.AddLast(info);
            }

            return result;
        }

        
    }
    public class Info
    {
        public int Value { get; set; }
        public int Index { get; set; }
    }

}
