using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace longest_increasing_path_in_a_matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[,] multiDimensionalArray2 = { { 9,9,4 }, 
                                               {6,6,8 } ,
                                               { 2,1,1 }};

            s.LongestIncreasingPath(multiDimensionalArray2);
        }
    }

    public class Solution
    {
        public int LongestIncreasingPath(int[,] matrix)
        {
            if (matrix == null || matrix.GetLength(0) == 0 || matrix.GetLength(1) == 0)
                return 0;

            bool[,] longestIncresingByindexAlready = new bool[matrix.GetLength(0), matrix.GetLength(1)];
            int[,] longestIncressingByIndex = new int[matrix.GetLength(0), matrix.GetLength(1)];

            int max = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (max < LongestIncreasingPath(longestIncresingByindexAlready, longestIncressingByIndex, matrix, i, j))
                        max = LongestIncreasingPath(longestIncresingByindexAlready, longestIncressingByIndex, matrix, i, j);
                }
            }

            return max;
        }

        private int LongestIncreasingPath(bool[,] longestIncresingByindexAlready, int[,] longestIncressingByIndex, int[,] matrix, int i, int j)
        {
            if (!longestIncresingByindexAlready[i, j])
            {
                longestIncressingByIndex[i, j] = 1;
                if (i + 1 < longestIncressingByIndex.GetLength(0) && matrix[i, j] < matrix[i + 1, j]
                    && longestIncressingByIndex[i, j] < LongestIncreasingPath(longestIncresingByindexAlready, longestIncressingByIndex, matrix, i + 1, j) + 1)
                    longestIncressingByIndex[i, j] = longestIncressingByIndex[i + 1, j] + 1;
                if (i - 1 > -1 && matrix[i, j] < matrix[i - 1, j]
                    && longestIncressingByIndex[i, j] < LongestIncreasingPath(longestIncresingByindexAlready, longestIncressingByIndex, matrix, i - 1, j) + 1)
                    longestIncressingByIndex[i, j] = longestIncressingByIndex[i - 1, j] + 1;
                if (j + 1 < longestIncressingByIndex.GetLength(1) && matrix[i, j] < matrix[i, j + 1]
                    && longestIncressingByIndex[i, j] < LongestIncreasingPath(longestIncresingByindexAlready, longestIncressingByIndex, matrix, i, j + 1) + 1)
                    longestIncressingByIndex[i, j] = longestIncressingByIndex[i, j + 1] + 1;
                if (j - 1 > -1 && matrix[i, j] < matrix[i, j - 1]
                    && longestIncressingByIndex[i, j] < LongestIncreasingPath(longestIncresingByindexAlready, longestIncressingByIndex, matrix, i, j - 1) + 1)
                    longestIncressingByIndex[i, j] = longestIncressingByIndex[i, j - 1] + 1;
                longestIncresingByindexAlready[i, j] = true;
            }
            return longestIncressingByIndex[i, j];
        }


    }
}
