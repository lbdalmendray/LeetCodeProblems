using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumDominoRotationsForEqualRow
{
    public class Solution2
    {
        public int MinDominoRotations(int[] tops, int[] bottoms)
        {
            int t1 = tops[0];
            int b1 = bottoms[0];

            int t1Counter = Enumerable.Range(1, tops.Length-1).All(i => tops[i] == t1 || bottoms[i] == t1) ? tops.Length : 0 ;
            int b1Counter = Enumerable.Range(1, bottoms.Length-1).All(i => tops[i] == b1 || bottoms[i] == b1) ? bottoms.Length : 0;

            if (t1Counter < tops.Length && b1Counter < bottoms.Length)
                return -1;
            if (t1Counter < tops.Length)
            {
                return CalculateSolution(b1, tops, bottoms);
            }
            else if (b1Counter < bottoms.Length)
            {
                return CalculateSolution(t1, tops, bottoms);
            }
            else if (t1 == b1)
            {
                return CalculateSolution(t1, tops, bottoms);
            }
            else
            {
                int t1Sol = CalculateSolution(t1, tops, bottoms);
                int b1Sol = CalculateSolution(b1, tops, bottoms);
                return Math.Min(t1Sol, b1Sol);
            }
        }

        private int CalculateSolution(int faceValue, int [] tops, int [] bottoms)
        {
            int topCounter = 0;
            int botCounter = 0;
            for (int i = 0; i < tops.Length; i++)
            {
                if (tops[i] == bottoms[i])
                    continue;
                else if (tops[i] == faceValue)
                    topCounter++;
                else
                    botCounter++;
            }

            return Math.Min(topCounter, botCounter);
        }
    }
}
