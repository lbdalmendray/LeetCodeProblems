using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellswithOddValuesinaMatrix
{
    public class Solution
    {
        public int OddCells(int n, int m, int[][] indices)
        {
            int[,] results = new int[n, m];
            for (int i = 0; i < indices.Length; i++)
            {
                int row = indices[i][0];

                for (int j = 0; j < m; j++)
                {
                    results[row, j]++;
                }


                int column = indices[i][1];

                for (int j = 0; j < n; j++)
                {
                    results[j, column]++;
                }
            }

            int result = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if( results[j,i] % 2 !=0)
                    {
                        result++;
                    }
                }
            }

            return result;
        }
    }
}
