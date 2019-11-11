using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberofClosedIslands
{
    public class Solution
    {
        public int ClosedIsland(int[][] grid)
        {
            LinkedList<LinkedList<int[]>> islands = new LinkedList<LinkedList<int[]>>();
            var gridClone = Clone(grid);

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if(gridClone[i][j] == 0 )
                    {
                        islands.AddLast(new LinkedList<int[]>());
                        CreateIsland(islands, gridClone, i, j);
                    }
                }
            }

            return islands.Where(island => IsTotalIsland(island , grid)).Count();
            
        }

        private bool IsTotalIsland(LinkedList<int[]> island, int[][] grid)
        {
            foreach (var pos in island)
            {
                if (pos[0] == 0 || pos[0] == grid.Length - 1)
                    return false;
                if (pos[1] == 0 || pos[1] == grid[0].Length - 1)
                    return false;
            }

            return true;
        }

        private int[][] Clone(int[][] grid)
        {
            int[][] result = new int[grid.Length][];
            for (int i = 0; i < grid.Length; i++)
            {
                result[i] = new int[grid[i].Length];
                for (int j = 0; j < result[i].Length; j++)
                {
                    result[i][j] = grid[i][j];
                }
            }

            return result; 
        }

        private void CreateIsland(LinkedList<LinkedList<int[]>> islands, int[][] grid, int i, int j)
        {
            LinkedList<int[]> islandPos = new LinkedList<int[]>();
            islandPos.AddLast(new int[] { i, j });
            grid[i][j] = 1;

            while (islandPos.Count != 0 )
            {
                var pos = islandPos.First.Value;
                i = pos[0];
                j = pos[1];
                islandPos.RemoveFirst();
                islands.Last.Value.AddLast(pos);

                if (i > 0 && grid[i - 1][j] == 0)
                {
                    islandPos.AddLast(new int[] { i - 1, j });
                    grid[i - 1][j] = 1;
                }
                if ( i < grid.Length-1 && grid[i + 1][j] == 0)
                { 
                    islandPos.AddLast(new int[] { i + 1, j });
                    grid[i + 1][j] = 1;
                }
                if (j > 0 && grid[i][j - 1] == 0)
                {
                    islandPos.AddLast(new int[] { i, j - 1 });
                    grid[i][j - 1] = 1;
                }
                if (j < grid[0].Length - 1 && grid[i][j + 1] == 0)
                {
                    islandPos.AddLast(new int[] { i, j + 1 });
                    grid[i][j + 1] = 1;
                }
            }
        }
    }
}
