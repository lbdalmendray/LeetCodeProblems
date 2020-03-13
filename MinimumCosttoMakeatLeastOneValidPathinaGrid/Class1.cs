using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumCosttoMakeatLeastOneValidPathinaGrid
{
    public class Solution
    {
        public int MinCost(int[][] grid)
        {
            if (grid.Length * grid[0].Length == 1)
                return 0;

            var graph = CreateGraph(grid);

            return CalculateMinDistance(graph, grid.Length, grid[0].Length);
        }

        private int CalculateMinDistance(LinkedList<((int, int), int)>[,] graph, int n, int m)
        {

            SortedDictionary<int, HashSet<(int,int)>> container = new SortedDictionary<int, HashSet<(int,int)>>();

            ((int, int),int,bool)?[,] fathers = new ((int, int),int,bool)?[n, m];
            fathers[0, 0] = ((0, 0),0,true);

            foreach ( var (pos,length) in graph[0,0])
            {
                if (pos == (n - 1, m - 1))
                    return length;

                if (!container.TryGetValue(length, out var currentHashSet))
                {
                    currentHashSet = new HashSet<(int, int)>();
                    currentHashSet.Add(pos);
                    container.Add(length, currentHashSet);
                }
                else
                    currentHashSet.Add(pos);

                fathers[pos.Item1, pos.Item2] = ((0, 0), length,false);
            }

            while(container.Count != 0 )
            {
                var first = container.First();

                var fatherLength = first.Key;
                var currentHashSet1 = first.Value;

                var firstCHS = currentHashSet1.First();
                currentHashSet1.Remove(firstCHS);
                if (currentHashSet1.Count == 0)
                    container.Remove(first.Key);

                if (firstCHS == (n - 1, m - 1))
                    return fathers[firstCHS.Item1, firstCHS.Item2].Value.Item2;
                else
                {
                    var (v1, v2, v3) = fathers[firstCHS.Item1, firstCHS.Item2].Value;
                    fathers[firstCHS.Item1, firstCHS.Item2] = (v1, v2, true);
                }

                foreach (var (pos, length) in graph[firstCHS.Item1, firstCHS.Item2])
                {
                    var cLength = length + fatherLength;

                    if (fathers[pos.Item1, pos.Item2].HasValue)
                    {
                        if(fathers[pos.Item1, pos.Item2].Value.Item3)
                        {
                            continue;
                        }
                        else if (fathers[pos.Item1, pos.Item2].Value.Item2 > cLength)
                        {
                            var hashset = container[fathers[pos.Item1, pos.Item2].Value.Item2];
                            hashset.Remove(pos);
                            if (hashset.Count == 0)
                                container.Remove(fathers[pos.Item1, pos.Item2].Value.Item2);
                        }
                        else
                        {
                            continue;
                        }
                    }                                                

                    if (!container.TryGetValue(cLength, out var currentHashSet))
                    {
                        currentHashSet = new HashSet<(int, int)>();
                        currentHashSet.Add(pos);
                        container.Add(cLength, currentHashSet);
                    }
                    else
                        currentHashSet.Add(pos);

                    fathers[pos.Item1, pos.Item2] = (firstCHS, cLength,false);
                }

            }

            return 0;           
            
        }

        private LinkedList<((int,int),int )>[,] CreateGraph(int[][] grid)
        {
            LinkedList<((int, int) , int )>[,] graph = new LinkedList<((int, int) , int )>[grid.Length, grid[0].Length];    ;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    graph[i, j] = GetRelationElements(grid, i, j);
                }
            }

            return graph;

        }

        private LinkedList<((int, int), int)> GetRelationElements(int[][] grid, int i, int j)
        {
            LinkedList<((int, int), int)> result = new LinkedList<((int, int), int)>();
            var gridValue = grid[i][j];
            var currentPosition = (i, j);
            if ( i > 0 )
            {
                var directionPoint = (i - 1, j);
                result.AddLast((directionPoint, (IsCorrectDirection(gridValue, currentPosition, directionPoint) ? 0 : 1)));
            }
            if ( j > 0)
            {
                var directionPoint = (i , j - 1);
                result.AddLast((directionPoint, (IsCorrectDirection(gridValue, currentPosition, directionPoint) ? 0 : 1)));
            }

            if ( j < grid[0].Length - 1)
            {
                var directionPoint = (i, j + 1);
                result.AddLast((directionPoint, (IsCorrectDirection(gridValue, currentPosition, directionPoint) ? 0 : 1)));

            }

            if (i < grid.Length - 1 )
            {
                var directionPoint = (i + 1 , j );
                result.AddLast((directionPoint, (IsCorrectDirection(gridValue, currentPosition, directionPoint) ? 0 : 1)));

            }

            return result;
        }

        private bool IsCorrectDirection(int gridValue, (int i, int j) currentPosition, (int, int j) directionPoint)
        {
            if ( gridValue == 1)// right 
            {
                return (currentPosition.i , currentPosition.j + 1) == directionPoint; 
            }
            else if (gridValue == 2 ) // left 
            {
                return (currentPosition.i, currentPosition.j - 1) == directionPoint;
            }
            else if ( gridValue == 3) // down 
            {
                return (currentPosition.i + 1, currentPosition.j ) == directionPoint;
            }
            else // up 
            {
                return (currentPosition.i - 1, currentPosition.j ) == directionPoint;
            }
        }
    }
}
