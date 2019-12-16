using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathinaGridwithObstaclesElimination
{
    public class Solution
    {
        public int ShortestPath(int[][] grid, int k)
        {
            if ( k >= grid.Length + grid[0].Length - 3)
            { 
                return grid.Length + grid[0].Length - 2;
            }

            BFSInfo[,] infos = new BFSInfo[grid.Length, grid[0].Length];
            int?[,,]  solutions = new int?[grid.Length, grid[0].Length, k + 1];
            for (int i = 0; i <=k ; i++)
            {
                solutions[grid.Length-1, grid[0].Length-1, i] = 0; 
            }

            return ShortestPath(0, 0, k, grid, infos, solutions);
        }

        private int ShortestPath(int x, int y, int k, int[][] grid, BFSInfo[,] infos, int?[,,] solutions)
        {
            if (solutions[x, y, k].HasValue)
                return solutions[x, y, k].Value;

            if(infos[x,y] == null)
            {
                infos[x, y] = CalculateBFSInfo(x, y, grid);
            }
            int? result = null;
            if (infos[x, y].Result.HasValue)
                result = infos[x, y].Result.Value;

            if (k > 0)
            {
                foreach (var obstacle in infos[x, y].Obstacles)
                {
                    var currentResult = ShortestPath(obstacle[0], obstacle[1], k - 1, grid, infos, solutions);
                    if (currentResult != -1)
                    {
                        currentResult += obstacle[2];
                        if (!result.HasValue || result > currentResult)
                            result = currentResult;
                    }
                }
            }

            solutions[x, y, k] = result.HasValue ? result.Value : -1;
            return solutions[x, y, k].Value;
        }

        private BFSInfo CalculateBFSInfo(int x, int y, int[][] grid)
        {
            BFSInfo result = new BFSInfo();
            bool[,] selected = new bool[grid.Length, grid[0].Length];

            LinkedList<int[]> queue = new LinkedList<int[]>();
            queue.AddLast(new int[] { x, y, 0 });
           
            while(queue.Count != 0)
            {
                var value = queue.First.Value;
                queue.RemoveFirst();

                if (value[0] == grid.Length - 1 && value[1] == grid[0].Length-1)
                {
                    result.Result = value[2];
                    var lessValue = value[2] - 1;
                    while(result.Obstacles.Count != 0)
                    {
                        if (result.Obstacles.Last.Value[2] >= lessValue)
                        {
                            result.Obstacles.RemoveLast();
                        }
                        else
                            break;
                    }
                    break;
                }
                IEnumerable<int[]> nextPositions = GetNextPositions(value,grid);
                var nextValue = value[2] + 1;
                foreach (var item in nextPositions.Where(e => !selected[e[0], e[1]]))
                {
                    if( grid[item[0]][item[1]] == 1)
                    {
                        result.Obstacles.AddLast(new int[] { item[0], item[1], nextValue });
                    }
                    else
                    {
                        queue.AddLast(new int[] { item[0], item[1], nextValue });
                    }
                    selected[item[0], item[1]] = true;
                }                
            }

            return result;
        }

        private IEnumerable<int[]> GetNextPositions(int[] value, int[][] grid)
        {
            LinkedList<int[]> result = new LinkedList<int[]>();
            if (value[0] > 0)
                result.AddLast(new int[] { value[0] - 1, value[1] });
            if (value[0] < grid.Length - 1)
                result.AddLast(new int[] { value[0] + 1, value[1] });
            if (value[1] > 0)
                result.AddLast(new int[] { value[0] , value[1] - 1 });
            if (value[1] < grid[0].Length - 1)
                result.AddLast(new int[] { value[0] , value[1] + 1 });
            return result;
        }
    }

    internal class BFSInfo
    {
        public int? Result { get; internal set; }
        public LinkedList<int[]> Obstacles { get; internal set; } = new LinkedList<int[]>();
    }
}
