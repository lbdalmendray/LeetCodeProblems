using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges;

public class Solution
{
    /*
     You are given an m x n grid where each cell can have one of three values:
        0 representing an empty cell,
        1 representing a fresh orange, or
        2 representing a rotten orange.
     */
    public int OrangesRotting(int[][] grid)
    {
        int freshCounter = 0;
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == 1)
                    freshCounter++;
            }
        }
        if (freshCounter == 0)
            return 0;

        List<(int x, int y)> rottenList = new List<(int x, int y)>();
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == 2)
                {
                    rottenList.Add((i, j));
                }
            }
        }

        int result = 0;

        while (rottenList.Count > 0)
        {
            List<(int x, int y)> newRottenList = new List<(int x, int y)>();

            for (int i = 0; i < rottenList.Count; i++)
            {
                (int x, int y) = rottenList[i];

                if (x > 0 && grid[x - 1][y] == 1)
                {
                    newRottenList.Add((x - 1, y));
                    grid[x-1][y] = 2;
                }

                if (y > 0 && grid[x][y - 1] == 1)
                {
                    newRottenList.Add((x, y - 1));
                    grid[x][y - 1] = 2;
                }

                if (x < grid.Length-1 && grid[x + 1][y] == 1)
                {
                    newRottenList.Add((x + 1, y));
                    grid[x + 1][y] = 2;

                }

                if (y < grid[0].Length-1 && grid[x][y + 1] == 1)
                {
                    newRottenList.Add((x , y+ 1));
                    grid[x][y + 1] = 2;
                }
            }
            if (newRottenList.Count > 0)
            {
                freshCounter -= newRottenList.Count;
                result++;
            }

            rottenList = newRottenList;
        }

        if (freshCounter == 0)
            return result;
        else
            return -1;
    }
}
