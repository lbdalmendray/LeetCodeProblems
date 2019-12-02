using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountSquareSubmatriceswithAllOnes
{
    public class Solution
    {
        public int  CountSquares(int[][] matrix)
        {
            int min = Math.Min(matrix.Length, matrix[0].Length);
            Boolean[,,] infos = new Boolean[matrix.Length, matrix[0].Length, matrix[0].Length+1];
            int result = 0;
            for (int k = 1; k <= min; k++)
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    if (i + k - 1 > matrix.Length - 1)
                        break;
                    for (int j = 0; j < matrix[0].Length; j++)
                    {
                        if (j + k - 1 > matrix[0].Length - 1)
                            break;
                        if (k == 1)
                        {
                            infos[i, j, k]= matrix[i][j] == 1 ? true : false;
                            if (infos[i, j, k])
                            {
                                result++;
                            }
                        }
                        else
                        {
                            infos[i, j, k] = infos[i, j, k - 1] && infos[i + 1, j, k - 1]
                                && infos[i, j + 1, k - 1] && infos[i + 1, j + 1, k - 1];
                            if (infos[i, j, k])
                            {
                                result++;
                            }
                        }
                    }
                }
            }

            return result;
        }

    }
}
