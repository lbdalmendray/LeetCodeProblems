using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidSudoku
{
    public class Solution
    {
        public bool IsValidSudoku(char[][] board)
        {
            for (int i = 0; i < 9; i++)
            {
                if (!IsValidRow(i, board))
                    return false;

                if (!IsValidColumn(i, board))
                    return false;
            }

            int[][] positions3x3 = new int[9][]{
            new int[]{ 0,0  } , new int[]{ 0,3 } , new int[]{ 0,6 }   ,new int[]{ 3,0  } ,
            new int[]{ 3,3 } , new int[]{ 3,6 }   ,new int[]{ 6,0  } , new int[]{ 6,3 } ,
            new int[]{ 6,6 }
            };

            foreach (var currentPosition in positions3x3)
            {
                if (!IsValid3x3Set(currentPosition[0], currentPosition[1], board))
                    return false;
            }

            return true;
        }
        public static bool IsValidRow(int index, char[][] board)
        {
            bool[] exists = new bool[9];

            for (int i = 0; i < 9; i++)
            {
                if (board[index][i] != '.')
                {
                    var intValue = board[index][i] - '1';
                    if (exists[intValue])
                    {
                        return false;
                    }

                    exists[intValue] = true;
                }
            }

            return true;
        }
        public static bool IsValidColumn(int index, char[][] board)
        {
            bool[] exists = new bool[9];

            for (int i = 0; i < 9; i++)
            {
                if (board[i][index] != '.')
                {
                    var intValue = board[i][index] - '1';
                    if (exists[intValue])
                    {
                        return false;
                    }

                    exists[intValue] = true;
                }
            }

            return true;
        }
        public static bool IsValid3x3Set(int posX, int posY, char[][] board)
        {
            bool[] exists = new bool[9];

            int posXLim = posX + 3;
            int posYLim = posY + 3;

            for (int i = posX; i < posXLim; i++)
            {
                for (int j = posY; j < posYLim; j++)
                {
                    if (board[i][j] != '.')
                    {
                        var intValue = board[i][j] - '1';
                        if (exists[intValue])
                        {
                            return false;
                        }

                        exists[intValue] = true;
                    }
                }
            }

            return true;
        }
    }
}
