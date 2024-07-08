using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace MinimumMovesToSpreadStonesOverGrid;

public class Solution
{
    public int[,] Ones =>
        new int[,] { { 1,1,1 }, { 1,1,1 }, { 1,1,1 } }; 

    public int MinimumMoves(int[][] grid)
    {
        Dictionary<int[,], int> processDict = new Dictionary<int[,], int>(new NewEqualityComparer());
        processDict.Add(Ones, 0);
        var realGrid = ToMatrix(grid);
        Dictionary<(int, int), int> morePos = CalculateMorePos(realGrid);
        HashSet<(int, int)> zeroPos = CalculateZeroPos(realGrid);
        return MinimumMoves(realGrid, processDict, morePos, zeroPos);
    }

    private HashSet<(int, int)> CalculateZeroPos(int[,] realGrid)
    {
        HashSet<(int, int)> result = new HashSet<(int, int)>();

        for (int i = 0; i < realGrid.GetLength(0); i++)
        {
            for (int j = 0; j < realGrid.GetLength(1); j++)
            {
                if (realGrid[i, j] == 0)
                    result.Add((i, j));
            }
        }

        return result;
    }

    private Dictionary<(int, int), int> CalculateMorePos(int[,] realGrid)
    {
        Dictionary<(int, int), int> result = new Dictionary<(int, int), int>();

        for (int i = 0; i < realGrid.GetLength(0); i++)
        {
            for (int j = 0; j < realGrid.GetLength(1); j++)
            {
                if (realGrid[i, j] > 1)
                    result.Add((i, j), realGrid[i, j]);
            }
        }

        return result;
    }

    private int[,] ToMatrix(int[][] grid)
    {
        int[,] result = new int[grid.Length, grid[0].Length];
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                result[i, j] = grid[i][j];
            }
        }
        return result;
    }

    private int MinimumMoves(int[,] grid, Dictionary<int[,], int> processDict, Dictionary<(int,int), int> morePos, HashSet<(int,int)> zeroPos)
    {
        if ( processDict.TryGetValue(grid, out int value))
        {
            return value;
        }
        else
        {
            int result = int.MaxValue;

            var morePosArray = morePos.ToArray();

            for (int i = 0; i < morePosArray.Length; i++)
            {
                var morePosKeyValue = morePosArray[i];

                var zeroPosArray = zeroPos.ToArray();

                for (int j = 0; j < zeroPosArray.Length; j++)
                {
                    var zeroPosKeyValue = zeroPosArray[j];
                    int movementCost = Distance(morePosKeyValue.Key, zeroPosKeyValue);
                    
                    grid[morePosKeyValue.Key.Item1, morePosKeyValue.Key.Item2]--;
                    grid[zeroPosKeyValue.Item1, zeroPosKeyValue.Item2]++;
                    if (morePosKeyValue.Value == 2)
                        morePos.Remove(morePosKeyValue.Key);
                    else
                        morePos[morePosKeyValue.Key]--;

                    zeroPos.Remove(zeroPosKeyValue);

                    var currentResult = movementCost + MinimumMoves(grid, processDict, morePos, zeroPos);

                    if (currentResult < result)
                        result = currentResult;

                    grid[morePosKeyValue.Key.Item1, morePosKeyValue.Key.Item2]++;
                    grid[zeroPosKeyValue.Item1, zeroPosKeyValue.Item2]--;

                    morePos[morePosKeyValue.Key] = morePosKeyValue.Value;
                    zeroPos.Add(zeroPosKeyValue);
                }
            }
            processDict.Add(grid, result);
            return result;
        }    
    }

    private int Distance((int, int) p1, (int, int) p2)
    {
        return Math.Abs(p1.Item1 - p2.Item1) + Math.Abs(p1.Item2 - p2.Item2);
    }

    /// <summary>
    /// CalculateTotalPossibilities
    /// numberCells = 9 , amountElements = 9 => 24310 
    /// </summary>
    /// <param name="numberCells"></param>
    /// <param name="amountElements"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static int CalculateTotalPossibilities(int numberCells, int amountElements)
    {
        if (numberCells == 1)
        {
            return 1;
        }
        else if (numberCells > 1)
        {
            int result = 0;
            for (int i = 0; i <= amountElements; i++)
            {
                result += CalculateTotalPossibilities(numberCells - 1, amountElements - i);
            }
            return result;
        }
        else
            throw new Exception();
    }

    public class NewEqualityComparer : IEqualityComparer<int[,]>
    {
        public bool Equals(int[,] x, int[,] y)
        {
            if (x.GetLength(0) == y.GetLength(0) && x.GetLength(1) == y.GetLength(1))
            {
                for (int i = 0; i < x.GetLength(0); i++)
                {
                    for (int j = 0; j < y.GetLength(1); j++)
                    {
                        if (x[i, j] != y[i, j])
                            return false;
                    }
                }
            }

            return true;
        }

        public int GetHashCode([DisallowNull] int[,] obj)
        {
            return (obj[0, 0], obj[0, 1], obj[0, 2]
            , obj[1, 0], obj[1, 1], obj[1, 2]
            , obj[2, 0], obj[2, 1], obj[2, 2]).GetHashCode();
        }
    }
}
