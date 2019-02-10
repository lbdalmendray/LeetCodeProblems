using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountCornerRectangles
{
    public class Solution
    {
        public int CountCornerRectangles(int[,] grid)
        {
            if (/*grid == null ||*/ grid.GetLength(0) < 2 || grid.GetLength(1) < 2)
                return 0;
            return CountCornerRectangles(grid, 0);
        }

        public int CountCornerRectanglesV2(int[,] grid)
        {
            if (/*grid == null ||*/ grid.GetLength(0) < 2 || grid.GetLength(1) < 2)
                return 0;
            int result = 0;
            var aaa = grid.GetValue(0, 0);
            for (int i = 0; i < grid.GetLength(1)-1; i++)
            {
                
                for (int j = i+1; j < grid.GetLength(1); j++)
                {
                    int count = 0;
                    for (int k = 0; k < grid.GetLength(0) ; k++)
                    {
                        if (grid[k, i] == 1 && grid[k, j] == 1)
                            count++;
                    }
                    result += count * (count - 1) / 2;
                }
            }

            return result;
        }

        public int CountCornerRectanglesV3(int[,] grid)
        {
            //if ( grid == null)
            // return 0;
            if (grid.GetLength(0) < 2 || grid.GetLength(1) < 2)
                return 0;

            int result = 0;
            for (int i = 0; i < grid.GetLength(1) - 1; i++)
            {
                for (int j = i + 1; j < grid.GetLength(1); j++)
                {
                    int count = 0;

                    for (int k = 0; k < grid.GetLength(0); k++)
                    {
                        if (grid[k, i] == 1 && grid[k, j] == 1)
                        {
                            count++;
                        }
                    }
                    result += count * (count - 1) / 2;
                }
            }
            return result;
        }

        public int CountCornerRectangles(int[,] grid, int columnIndex)
        {
            if (grid.GetLength(1) - columnIndex < 2)
                return 0;

            int result = 0;

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                if (grid[i, columnIndex] == 1)
                    result += CountCornerRectanglesBeginAt(grid, i, columnIndex);
            }

            result += CountCornerRectangles(grid, columnIndex + 1);
            return result;

        }

        public int CountCornerRectanglesBeginAt(int[,] grid, int rowIndex, int columnIndex)
        {
            if (grid.GetLength(0) - rowIndex < 2)
                return 0;
            int result = 0;
            for (int i = columnIndex + 1; i < grid.GetLength(1); i++)
            {
                if (grid[rowIndex, i] == 1)
                {
                    for (int j = rowIndex + 1; j < grid.GetLength(0); j++)
                    {
                        if (grid[j, columnIndex] == 1 && grid[j, i] == 1)
                            result++;
                    }
                }
            }

            return result;
        }

    }
}
