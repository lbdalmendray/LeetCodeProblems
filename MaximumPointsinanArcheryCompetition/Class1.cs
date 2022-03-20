using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MaximumPointsinanArcheryCompetition
{
    public class Solution
    {
        public int[] MaximumBobPoints(int numArrows, int[] aliceArrows)
        {
            Info [,] solutions = new Info[aliceArrows.Length, numArrows+1];
            Info solution = Solve(aliceArrows.Length-1, numArrows, aliceArrows, solutions);
            var result = GetResultFromSolution(solution);
            return result;
        }

        private int[] GetResultFromSolution(Info solution)
        {
            int[] result = new int[12];

            int index = result.Length - 1;
            while (solution != null)
            {
                result[index] = solution.CurrentPosValue;
                solution = solution.Child;
                index--;
            }

            return result;
        }

        private Info Solve(int position, int arrows , int[] aliceArrows, Info[,] solutions)
        {
            if (solutions[position, arrows] != null)
                return solutions[position, arrows];
            else if ( position == 0)
            {
                Info result = new Info { CurrentPosValue = arrows };
                solutions[position, arrows] = result;
                return result;
            }
            else
            {
                var info1Arrows = arrows - (aliceArrows[position] + 1);
                Info info1 = info1Arrows >-1 ? Solve(position - 1, info1Arrows, aliceArrows, solutions): null;
                int sol1 = 0;
                if (info1 != null)
                {
                    sol1 = position + info1.TotalValue; ;
                }

                Info info2 = Solve(position - 1, arrows, aliceArrows, solutions);

                Info result;
                if (info1 != null && sol1 > info2.TotalValue)
                {
                    result = new Info 
                    { 
                        TotalValue = sol1 
                        , Child = info1 
                        , CurrentPosValue = aliceArrows[position] + 1
                    };
                }
                else
                {
                    result = new Info 
                    { 
                        TotalValue = info2.TotalValue
                        , Child = info2
                        , CurrentPosValue = 0
                    };
                }

                solutions[position, arrows] = result;
                return result;
            }
        }

        class Info
        {
            public int TotalValue { get; internal set; }
            public Info Child { get; internal set; }
            public int CurrentPosValue { get; internal set; }
        }
    }
}
