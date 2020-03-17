using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyNumbersinaMatrix
{
    public class Solution
    {
        public IList<int> LuckyNumbers(int[][] matrix)
        {
            int n = matrix.Length;
            int m = matrix[0].Length;

            int[] minRows = matrix.Select(e => e.Min()).ToArray();
            int[] maxColumns = new int[m];

            for (int i = 0; i < m ; i++)
            {
                LinkedList<int> colElements = new LinkedList<int>();
                int max = matrix[0][i];
                for (int j = 1; j < n ; j++)
                {
                    if (max < matrix[j][i])
                        max = matrix[j][i];
                }
                maxColumns[i] = max;                
            }
            LinkedList<int> result = new LinkedList<int>();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i][j] == minRows[i] && matrix[i][j] == maxColumns[j])
                        result.AddLast(matrix[i][j]);
                }
            }
            return result.ToList();
        }
    }
}
