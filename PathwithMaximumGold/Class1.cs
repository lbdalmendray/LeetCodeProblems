using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathwithMaximumGold
{
    public class Solution
    {
        public int GetMaximumGold(int[][] grid)
        {
            LinkedList<int[]> goldPositions = new LinkedList<int[]>();
            bool [][] selected = new bool[grid.Length][];
            for (int i = 0; i < grid.Length; i++)
            {
                selected[i] = new bool[grid[i].Length];
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] > 0)
                    {
                        goldPositions.AddLast(new int[] { i, j });
                    }
                    else
                        selected[i][j] = true;
                }
            }


            if (goldPositions.Count == 0)
                return 0;

            var result =  goldPositions.Select(goldPosition => MaxMaximumGold(goldPosition, selected, grid)).Max();

            return result;
        }

        private int MaxMaximumGold(int[] goldPosition , bool[][] selected , int[][] grid)
        {
            if (selected[goldPosition[0]][goldPosition[1]])
                return 0;
            int result = grid[goldPosition[0]][goldPosition[1]];
            selected[goldPosition[0]][goldPosition[1]] = true;
            int upper = 0;
            if( goldPosition[0] > 0 )
            {
                upper = MaxMaximumGold(new int[] { goldPosition[0] - 1, goldPosition[1] }, selected, grid);
            }

            int left = 0;
            if (goldPosition[1] > 0)
            {
                left = MaxMaximumGold(new int[] { goldPosition[0], goldPosition[1] - 1 }, selected, grid);
            }

            int down = 0;
            if (goldPosition[0] < grid.Length -1)
            {
                down = MaxMaximumGold(new int[] { goldPosition[0]+1, goldPosition[1] }, selected, grid);
            }

            int right = 0;
            if (goldPosition[1] < grid[goldPosition[0]].Length - 1)
            {
                right = MaxMaximumGold(new int[] { goldPosition[0] , goldPosition[1] + 1 }, selected, grid);
            }

            selected[goldPosition[0]][goldPosition[1]] = false;
            return result + Math.Max(Math.Max(Math.Max(upper,down),right),left);
        }
    }
}
