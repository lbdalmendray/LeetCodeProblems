using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumMovesMoveBoxTheirTargetLocation
{
    /// <summary>
    /// Minimum Moves to Move a Box to Their Target Location
    /// </summary>
    public class Solution
    {
        public int MinPushBox(char[][] grid)
        {
            int[] playerPos = GetElementPos(grid, 'S');
            int[] boxPos = GetElementPos(grid, 'B');
            int[] targetPos = GetElementPos(grid, 'T');

            if (ExistPathSimple(boxPos, targetPos, grid, out LinkedList<int[]> path))
            {
                var graph = CreateGraph(boxPos, playerPos, targetPos, grid);
                var directionValues = Enum.GetValues(typeof(Direction)).Cast<Direction>().ToArray();
                int min = int.MaxValue;
                LinkedList<int[]> minPath = null;
                for (int i = 0; i < directionValues.Length; i++)
                {
                    var delta = getDelta(directionValues[i]);
                    grid[boxPos[0]][boxPos[1]] = '#';
                    if (!ExistPathSimple(playerPos, new int[] { boxPos[0] + delta[0], boxPos[1] + delta[1]}, grid, out var p))
                    {
                        continue;
                    }
                    grid[boxPos[0]][boxPos[1]] = 'B';

                    LinkedList<int[]> currentPath = GetMinimumPath(graph, new int[] { boxPos[0], boxPos[1], (int)directionValues[i] }, targetPos);
                    if (currentPath.Count == 0)
                        continue;
                    if (currentPath.Count < min)
                    {
                        min = currentPath.Count;
                        minPath = currentPath;
                    }
                }
                grid[boxPos[0]][boxPos[1]] = 'B';
                return minPath == null ? -1 : minPath.Count - 1;
            }
            else
                return -1;
        }

        private LinkedList<int[]> GetMinimumPath(LinkedList<int[]>[,,] graph, int[] boxPosDirection, int[] targetPos)
        {
            LinkedList<int[]> queue = new LinkedList<int[]>();
            int[,,][]fathers = new int[graph.GetLength(0), graph.GetLength(1), graph.GetLength(2)][];
            fathers[boxPosDirection[0], boxPosDirection[1], boxPosDirection[2]] = new int[] { -1, -1, -1 };
            queue.AddLast(boxPosDirection);

            int[] fatherTargetPos = null; 

            while(queue.Count!=0)
            {
                var posDirection = queue.First.Value;
                queue.RemoveFirst();

                foreach (var relation in graph[posDirection[0],posDirection[1],posDirection[2] ])
                {
                    if( relation[0] == targetPos[0] && relation[1] == targetPos[1])
                    {
                        fatherTargetPos = posDirection;
                        queue.Clear();
                        break;
                    }
                    if( fathers[relation[0],relation[1],relation[2]] == null )
                    {
                        fathers[relation[0], relation[1], relation[2]] = posDirection;
                        queue.AddLast(relation);
                    }
                }                
            }
            if (fatherTargetPos != null)
            {
                LinkedList<int[]> result = new LinkedList<int[]>();
                result.AddFirst(targetPos);
                var currentFather = fatherTargetPos;
                fathers[boxPosDirection[0], boxPosDirection[1], boxPosDirection[2]] = null;
                while (currentFather != null)
                {
                    result.AddFirst(currentFather);
                    currentFather = fathers[currentFather[0], currentFather[1], currentFather[2]];
                }

                return result;
            }
            else
                return new LinkedList<int[]>();

        }

        private LinkedList<int[]>[,,] CreateGraph(int[] boxPos, int[] playerPos,int [] targetPos, char[][] grid)
        {
            grid[boxPos[0]][boxPos[1]] = '.';
            grid[playerPos[0]][playerPos[1]] = '.';
            grid[targetPos[0]][targetPos[1]] = '.';

            var directionValues = Enum.GetValues(typeof(Direction)).Cast<Direction>().ToArray();
            var directionLength = directionValues.Length;
            LinkedList<int[]>[,,] result = new LinkedList<int[]>[grid.Length, grid[0].Length, directionLength];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    for (int k = 0; k < directionLength; k++)
                    {
                        result[i, j,k] = new LinkedList<int[]>();
                    }                    
                }
            }
            char[] notEmptySpacesWIthTargerPos = new char[] { '#', 'T' };
            char[] notEmptySpacesWIthBox = new char[] { '#', 'B' };

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    if (IsNotEmptySpace(grid, i, j, notEmptySpacesWIthTargerPos))
                        continue;

                    for (int k = 0; k < directionLength; k++)
                    {
                        if (directionValues[k] == Direction.Up)
                        {
                            if (i == 0 || i == result.GetLength(0) - 1)
                                continue;
                            if (IsNotEmptySpace(grid, i-1, j) || IsNotEmptySpace(grid, i + 1, j))
                                continue;
                            grid[i - 1][j] = 'B';
                            for (int l = 0; l < directionValues.Length; l++)
                            {
                                int[] delta = getDelta(directionValues[l]);
                                
                                if (ExistPath(new int[] { i, j }, new int[] { i - 1 + delta[0], j + delta[1] }, grid, notEmptySpacesWIthBox, out var p))
                                    result[i, j, k].AddLast(new int[] { i - 1, j, l });
                            }
                            grid[i - 1][j] = '.';
                        }
                        else if (directionValues[k] == Direction.Down)
                        {
                            if (i == 0 || i == result.GetLength(0) - 1)
                                continue;
                            if (IsNotEmptySpace(grid, i - 1, j) || IsNotEmptySpace(grid, i + 1, j))
                                continue;
                            grid[i + 1][j] = 'B';
                            for (int l = 0; l < directionValues.Length; l++)
                            {
                                int[] delta = getDelta(directionValues[l]);
                                if (ExistPath(new int[] { i, j }, new int[] { i + 1 + delta[0], j + delta[1] }, grid, notEmptySpacesWIthBox, out var p))
                                    result[i, j, k].AddLast(new int[] { i+1, j, l });
                            }
                            grid[i + 1][j] = '.';
                        }
                        else if (directionValues[k] == Direction.Left)
                        {
                            if (j == 0 || j == result.GetLength(1) - 1)
                                continue;
                            if (IsNotEmptySpace(grid, i, j - 1) || IsNotEmptySpace(grid, i, j + 1))
                                continue;
                            grid[i][j - 1] = 'B';
                            for (int l = 0; l < directionValues.Length; l++)
                            {
                                int[] delta = getDelta(directionValues[l]);
                                if (ExistPath(new int[] { i, j }, new int[] { i + delta[0], j - 1 + delta[1] }, grid, notEmptySpacesWIthBox, out var p))
                                    result[i, j, k].AddLast(new int[] { i, j - 1, l });
                            }
                            grid[i][j - 1] = '.';
                        }
                        else //if ((Direction)k == Direction.Right)
                        {
                            if (j == 0 || j == result.GetLength(1) - 1)
                                continue;
                            if (IsNotEmptySpace(grid, i, j - 1) || IsNotEmptySpace(grid, i, j + 1))
                                continue;
                            grid[i][j + 1] = 'B';
                            for (int l = 0; l < directionValues.Length; l++)
                            {
                                int[] delta = getDelta(directionValues[l]);
                                if (ExistPath(new int[] {i,j },new int[] {i + delta[0], j+1 + delta[1] },grid, notEmptySpacesWIthBox, out var p))
                                    result[i, j, k].AddLast(new int[] { i, j + 1, l });
                            }
                            grid[i][j + 1] = '.';
                        }
                    }
                }
            }

            grid[boxPos[0]][boxPos[1]] = 'B';
            grid[playerPos[0]][playerPos[1]] = 'S';
            grid[targetPos[0]][targetPos[1]] = 'T';
            
            return result;
        }

        private int[] getDelta(Direction direction)
        {
            if (direction == Direction.Up)
                return new int[] { +1, 0 };
            else if (direction == Direction.Down)
                return new int[] { -1, 0 };
            else if (direction == Direction.Left)
                return new int[] { 0, +1 };
            else // if (direction == Direction.Right)
                return new int[] { 0, -1 };
        }

        private static bool IsNotEmptySpace(char[][] grid, int i, int j, char [] emptyCharacters = null)
        {
            if (emptyCharacters == null)
                return grid[i][j] == '#';
            else
                return emptyCharacters.Contains(grid[i][j]);
        }

        private bool ExistPath(int[] pos1, int[] pos2, char[][] grid, char[] obstacles, out LinkedList<int[]> path)
        {
            if (!IsPosIn(pos1, grid) || !IsPosIn(pos2, grid))
            {
                path = null;
                return false;
            }

            int?[][] gridLee = new int?[grid.Length][];
            for (int i = 0; i < grid.Length; i++)
            {
                //gridLee[i] = new int?[grid[i].Length];
                gridLee[i] = Enumerable.Repeat(-1, grid[i].Length).Select(e => (int?)e).ToArray();
            }

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (obstacles.Contains(grid[i][j]))
                    {
                        gridLee[i][j] = null;
                    }
                }
            }

            gridLee[pos1[0]][pos1[1]] = 0;

            FillGridLee(pos1, pos2, gridLee, grid);

            if (gridLee[pos2[0]][pos2[1]].HasValue && gridLee[pos2[0]][pos2[1]] .Value != -1)
            {
                path = new LinkedList<int[]>();
                var currentPos = pos2;
                while (currentPos[0] != pos1[0] || currentPos[1] != pos1[1])
                {
                    path.AddFirst(currentPos);
                    int posValue = gridLee[currentPos[0]][currentPos[1]].Value - 1;
                    if (currentPos[0] > 0 && gridLee[currentPos[0] - 1][currentPos[1]].HasValue && gridLee[currentPos[0] - 1][currentPos[1]] == posValue)
                    {
                        currentPos = new int[] { currentPos[0] - 1, currentPos[1] };
                    }

                    else if (currentPos[1] > 0 && gridLee[currentPos[0]][currentPos[1] - 1].HasValue && gridLee[currentPos[0]][currentPos[1] - 1] == posValue)
                    {
                        currentPos = new int[] { currentPos[0], currentPos[1] - 1 };
                    }

                    else if (currentPos[0] < gridLee.Length - 1 && gridLee[currentPos[0] + 1][currentPos[1]].HasValue && gridLee[currentPos[0] + 1][currentPos[1]] == posValue)
                    {
                        currentPos = new int[] { currentPos[0] + 1, currentPos[1] };
                    }

                    else if (currentPos[1] < gridLee[0].Length - 1 && gridLee[currentPos[0]][currentPos[1] + 1].HasValue && gridLee[currentPos[0]][currentPos[1] + 1] == posValue)
                    {
                        currentPos = new int[] { currentPos[0], currentPos[1] + 1 };
                    }
                }

                return true;
            }

            path = null;
            return false;

        }

        private bool IsPosIn(int[] pos1, char[][] grid)
        {
            return !(pos1[0] < 0 || pos1[0] >= grid.Length || pos1[1] < 0 || pos1[1] >= grid[0].Length);
        }

        private bool ExistPathSimple(int[] pos1, int[] pos2, char[][] grid , out LinkedList<int[]> path)
        {
            return ExistPath(pos1, pos2, grid, new char[] { '#' }, out path);
        }

        private void FillGridLee(int[] pos1, int[] pos2, int?[][] gridLee , char[][] grid)
        {
            LinkedList<int[]> positions = new LinkedList<int[]>();
            positions.AddLast(pos1);

            while(positions.Count!=0)
            {
                var pos = positions.First.Value;
                positions.RemoveFirst();
                if (pos[0] == pos2[0] && pos[1] == pos2[1])
                    break;

                int posValue = gridLee[pos[0]][pos[1]].Value+1;

                if ( pos[0] >0  && gridLee[pos[0] - 1][pos[1]] == -1 )
                {
                    gridLee[pos[0] - 1][pos[1]] = posValue;
                    positions.AddLast(new int[] { pos[0] - 1, pos[1] });
                }
                
                if ( pos[1] > 0 && gridLee[pos[0]][pos[1] - 1]== -1)
                {
                    gridLee[pos[0]][pos[1] - 1] = posValue;
                    positions.AddLast(new int[] { pos[0] , pos[1] -1});
                }

                if ( pos[0]< gridLee.Length-1 && gridLee[pos[0]+1][pos[1]] == -1)
                {
                    gridLee[pos[0] + 1][pos[1]] = posValue;
                    positions.AddLast(new int[] { pos[0] + 1, pos[1] });
                }

                if (pos[1] < gridLee[0].Length - 1 && gridLee[pos[0]][pos[1] + 1] == -1)
                {
                    gridLee[pos[0]][pos[1] + 1] = posValue;
                    positions.AddLast(new int[] { pos[0], pos[1] + 1 });
                }
            }
        }

        private int[] GetElementPos(char[][] grid, char element)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == element)
                        return new int[] { i, j };
                }
            }
            return null;
        }
    }

    public enum Direction : int 
    {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3
    }
}
