using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueensThatCanAttacktheKing
{
    public class Solution
    {
        public IList<IList<int>> QueensAttacktheKing(int[][] queens, int[] king)
        {
            bool[] selected = new bool[queens.Length];
            bool up = false;
            bool down = false;
            bool left = false;
            bool right = false;
            bool rightUp = false;
            bool rightdown = false;
            bool leftUp = false;
            bool leftdown = false;
            LinkedList<int[]> result = new LinkedList<int[]>();
            Array.Sort(queens.Select(q => Distance(q, king)).ToArray(), queens);

            for (int i = 0; i < queens.Length; i++)
            {
                var currentQueen = queens[i];
                if (isUp(currentQueen, king))
                {
                    if (up)
                        continue;
                    up = true;
                    result.AddLast(queens[i]);
                }
                else if (isDown(currentQueen, king))
                {
                    if (down)
                        continue;
                    down = true;
                    result.AddLast(queens[i]);
                }
                else if (isRight(currentQueen, king))
                {
                    if (right)
                        continue;
                    right = true;
                    result.AddLast(queens[i]);
                }
                else if (isLeft(currentQueen, king))
                {
                    if (left )
                        continue;
                    left = true;
                    result.AddLast(queens[i]);
                }
                /////
                else if (isRightUp(currentQueen, king))
                {
                    if (rightUp)
                        continue;
                    rightUp = true;
                    result.AddLast(queens[i]);
                }
                /////
                else if (isRightDown(currentQueen, king))
                {
                    if (rightdown)
                        continue;
                    rightdown = true;
                    result.AddLast(queens[i]);
                }
                /////
                else if (isLeftDown(currentQueen, king))
                {
                    if (leftdown)
                        continue;
                    leftdown = true;
                    result.AddLast(queens[i]);
                }
                /////
                else if (isLeftUp(currentQueen, king))
                {
                    if (leftUp)
                        continue;
                    leftUp = true;
                    result.AddLast(queens[i]);
                }

            }

            return result.Select(e => e.ToList() as IList<int>).ToList() as IList<IList<int>>;
        }

        private bool isRightUp(int[] currentQueen, int[] king)
        {
            return currentQueen[1] > king[1] && currentQueen[0] > king[0] && IsSimetricDistance(currentQueen, king); ;
        }

        private bool isRightDown(int[] currentQueen, int[] king)
        {
            return currentQueen[1] < king[1] && currentQueen[0] > king[0] && IsSimetricDistance(currentQueen, king); ;
        }

        private bool isLeftDown(int[] currentQueen, int[] king)
        {
            return currentQueen[1] < king[1] && currentQueen[0] < king[0] && IsSimetricDistance(currentQueen, king); ;
        }

        private bool isLeftUp(int[] currentQueen, int[] king)
        {
            return currentQueen[1] > king[1] && currentQueen[0] < king[0] && IsSimetricDistance(currentQueen,king);
        }

        private bool IsSimetricDistance(int[] currentQueen, int[] king)
        {
            return Math.Abs(currentQueen[0] - king[0]) == Math.Abs(currentQueen[1] - king[1]);
        }

        private bool isRight(int[] currentQueen, int[] king)
        {
            return currentQueen[1] == king[1] && currentQueen[0] > king[0];
        }

        private bool isLeft(int[] currentQueen, int[] king)
        {
            return currentQueen[1] == king[1] && currentQueen[0] < king[0];
        }

        private bool isDown(int[] currentQueen, int[] king)
        {
            return currentQueen[0] == king[0] && currentQueen[1] < king[1];
        }

        private bool isUp(int[] currentQueen, int[] king)
        {
            return currentQueen[0] == king[0] && currentQueen[1] > king[1];
        }

        private int Distance(int[] q, int[] king)
        {
            return Math.Abs(q[0] - king[0]) + Math.Abs(q[1] - king[1]);
        }
    }
}
