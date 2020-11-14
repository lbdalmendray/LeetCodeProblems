using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberofIslands
{
    public class Solution
    {
        public int NumIslands(char[][] grid)
        {
            int result = 0;
            bool[,] selected = new bool[grid.Length, grid[0].Length];

            for (int i = 0; i < selected.GetLength(0); i++)
            {
                for (int j = 0; j < selected.GetLength(1); j++)
                {
                    if (selected[i, j] || grid[i][j] == '0')
                        continue;
                    SelectIsland(i, j, grid , selected);
                    result++;
                }
            }
            return result;
        }

        private void SelectIsland(int i , int j, char[][] grid , bool [,] selected)
        {
            LinkedList<int[]> landPositions = new LinkedList<int[]>();
            landPositions.AddLast(new int[] { i, j });
            selected[i, j] = true;

            while (landPositions.Count != 0)
            {
                var landPosition = landPositions.First.Value;
                landPositions.RemoveFirst();

                IEnumerable<int[]> nearPositions = GetNearPositions(landPosition[0], landPosition[1], selected.GetLength(0), selected.GetLength(1));

                foreach(var nearPosition in nearPositions.Where(p=> grid[p[0]][p[1]] == '1' && !selected[p[0], p[1]]))
                {
                    selected[nearPosition[0], nearPosition[1]] = true;
                    landPositions.AddLast(nearPosition);
                }
            }
        }

        private IEnumerable<int[]> GetNearPositions(int i , int j, int dim1 , int dim2 )
        {
            LinkedList<int[]> result = new LinkedList<int[]>();

            if (i > 0)
                result.AddLast(new int[] { i - 1, j });
            if (j > 0)
                result.AddLast(new int[] { i, j - 1 });
            if (i < dim1 - 1)
                result.AddLast(new int[] { i+1, j });
            if (j < dim2 - 1)
                result.AddLast(new int[] { i, j + 1 });

            return result;
        }
    }
}
