using System.Linq;

namespace MaximalSquare
{
    public class Solution
    {
        public int MaximalSquare(char[][] matrix)
        {
            int[,] right = CalculateRight(matrix);
            int[,] down = CalculateDown(matrix);
            int[,] square = CalculateSquare(matrix, right, down);
            int result = 0;
            for (int i = 0; i < square.GetLength(0); i++)
            {
                for (int j = 0; j < square.GetLength(1); j++)
                {
                    result = Math.Max(result, square[i, j]);
                }
            }
            return result*result;
        }

        private int[,] CalculateSquare(char[][] matrix, int[,] right, int[,] down)
        {
            int[,] result = new int[matrix.Length, matrix[0].Length];

            for (int i = right.GetLength(0)-1; i > -1; i--)
            {
                for (int j = right.GetLength(1) - 1; j > -1; j--)
                {
                    if(i == right.GetLength(0) - 1
                        || j == right.GetLength(1) - 1)
                    {
                        if ( matrix[i][j] == '1')
                        {
                            result[i, j] = 1;
                        }
                    }
                    else
                    {
                        int currentRight = right[i, j]-1;
                        int currentDown = down[i, j]-1;
                        int currentDiagSquare = result[i + 1, j + 1];
                        result[i, j] = Math.Min(currentRight, Math.Min(currentDown, currentDiagSquare))+1;
                    }
                }
            }

            return result;
        }

        private int[,] CalculateDown(char[][] matrix)
        {
            int[,] result = new int[matrix.Length, matrix[0].Length];

            for (int row = result.GetLength(0)-1; row > -1 ; row--)
            {
                for (int col = 0; col < result.GetLength(1); col++)
                {
                    if (row == matrix.GetLength(0) - 1)
                    {
                        if (matrix[row][col] == '1')
                        {
                            result[row, col] = 1;
                        }
                    }
                    else
                    {
                        if (matrix[row][col] == '1')
                        {
                            result[row, col] = result[row + 1, col] == 0 ? 1 : result[row + 1, col] + 1;
                        }
                    }
                }
            }

            return result;
        }

        private int[,] CalculateRight(char[][] matrix)
        {
            int[,] result = new int[matrix.Length, matrix[0].Length];
            
            for (int col = result.GetLength(1) - 1 ; col > -1 ; col--)
            {
                for (int row = 0; row < result.GetLength(0); row++)
                {
                    if ( col == result.GetLength(1) - 1)
                    {
                        if (matrix[row][col] == '1')
                        {
                            result[row, col] = 1;
                        }
                    }
                    else
                    {
                        if (matrix[row][col] == '1')
                        {
                            result[row, col] = result[row, col+1] == 0 ? 1 : result[row, col + 1] + 1;
                        }                        
                    }
                }
            }

            return result;
        }
    }
}