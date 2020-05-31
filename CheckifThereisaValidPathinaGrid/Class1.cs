using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckifThereisaValidPathinaGrid
{
    public class Solution
    {
        public bool HasValidPath(int[][] grid)
        {
            var graph = CreateGraph(grid);
            return BFS(graph, (0, 0), (grid.Length - 1, grid[0].Length - 1));
        }

        private bool BFS(LinkedList<(int, int)>[,] graph, (int, int) pos1, (int, int) pos2)
        {
            int n = graph.GetLength(0);
            int m = graph.GetLength(1);
            bool[,] selected = new bool[n, m];
            selected[pos1.Item1, pos1.Item2] = true;

            LinkedList<(int, int)> queue = new LinkedList<(int, int)>();
            queue.AddLast(pos1);
            while(queue.Count != 0)
            {
                if (pos2 == queue.First.Value)
                    return true;

                (int x, int y) = queue.First.Value;
                queue.RemoveFirst();

                foreach( (int x1,int y1) in graph[x,y])
                {
                    if (selected[x1, y1])
                        continue;

                    if ( graph[x1,y1] .Contains((x,y)))
                    {
                        queue.AddLast((x1, y1));
                        selected[x1, y1] = true;
                    }
                }
            }

            return false;
        }

        private LinkedList<(int,int)> [,] CreateGraph(int[][] grid)
        {
            int n = grid.Length;
            int m = grid[0].Length;
            LinkedList<(int, int)>[,] result = new LinkedList<(int, int)>[grid.Length,grid[0].Length];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    result[i, j] =  GetNextPositions(grid, i, j, n , m );
                }
            }

            return result;
        }

        private LinkedList<(int, int)> GetNextPositions(int[][] grid, int i, int j, int n , int m)
        {
            LinkedList<(int, int)> result = new LinkedList<(int, int)>();

            var value = grid[i][j];

            if( value == 1)
            {
                if (j > 0)
                    result.AddLast((i, j - 1));
                if (j < m - 1)
                    result.AddLast((i, j + 1));
            }
            else if ( value == 2)
            {
                if (i > 0)
                    result.AddLast((i - 1, j ));
                if (i < n - 1)
                    result.AddLast((i + 1, j ));
            }
            else if (value == 3)
            {
                if (j > 0)
                    result.AddLast((i , j - 1));
                if (i < n - 1)
                    result.AddLast((i + 1, j ));
            }
            else if (value == 4)
            {
                if (j < m-1)
                    result.AddLast((i, j + 1));
                if (i < n - 1)
                    result.AddLast((i + 1, j));
            }
            else if (value == 5)
            {
                if (j > 0)
                    result.AddLast((i, j - 1));
                if (i > 0 )
                    result.AddLast((i - 1, j));
            }
            else if (value == 6)
            {
                if (j < m - 1)
                    result.AddLast((i, j + 1));
                if (i > 0)
                    result.AddLast((i - 1, j));
            }

            return result;
        }
    }
}
