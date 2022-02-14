using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimumDominoRotationsForEqualRow
{
    public class Solution
    {
        public int MinDominoRotations(int[] tops, int[] bottoms)
        {
            var info1 = CalculateInfo(tops[0], tops, bottoms);
            var info2 = CalculateInfo(bottoms[0], tops, bottoms);

            List<int> resultList = new List<int>();

            if ( info1.Counter == tops.Length)
            {
                int cResult = Math.Min(
                    info1.TopCounter - info1.BothCounter,
                    info1.BottomCounter - info1.BothCounter
                    );
                resultList.Add(cResult);
            }

            if (info2.Counter == tops.Length)
            {
                int cResult = Math.Min(
                    info2.TopCounter - info2.BothCounter,
                    info2.BottomCounter - info2.BothCounter
                    );
                resultList.Add(cResult);
            }

            if( resultList.Count == 0)
            {
                return -1;
            }

            return resultList.Min();
        }

        private Info CalculateInfo(int value , int [] tops , int [] bottoms)
        {
            Info result = new Info();

            result.Counter = Enumerable.Range(0, tops.Length).Where(i => tops[i] == value || bottoms[i] == value).Select(e => 1).Sum();

            result.BothCounter = Enumerable.Range(0, tops.Length).Where(i => tops[i] == value  && bottoms[i] == value).Select(e => 1).Sum();

            int topCounter = Enumerable.Range(0, tops.Length).Where(i => tops[i] == value).Select(e => 1).Sum();
            result.TopCounter = topCounter;

            int botCounter = Enumerable.Range(0, bottoms.Length).Where(i => bottoms[i] == value).Select(e => 1).Sum();
            result.BottomCounter = botCounter;

            return result;
        }


        
        
    }

    internal class Info
    {
        internal int Counter { get; set; }
        internal int TopCounter { get; set; }
        internal int BottomCounter { get; set; }
        internal int BothCounter { get; set; }
    }    
}
