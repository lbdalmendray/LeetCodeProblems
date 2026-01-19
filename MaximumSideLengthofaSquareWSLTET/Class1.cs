namespace MaximumSideLengthofaSquareWSLTET;

/// <summary>
/// Maximum Side Length of a Square with Sum Less than or Equal to Threshold
/// 
/// </summary>
public class Solution
{
    public int MaxSideLength(int[][] mat, int threshold)
    {
        int m = mat.Length;
        int n = mat[0].Length;

        //// ROW SUMS 

        long[,] rowSums = new long[m, n];
        for (int i = 0; i < m; i++)
            rowSums[i, 0] = mat[i][0];

        for (int i = 0; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                rowSums[i, j] = rowSums[i, j - 1] + mat[i][j];
            }
        }

        //////////
        ///

        //// COLUMN SUMS 

        long[,] columnSums = new long[m, n];
        for (int i = 0; i < n; i++)
            columnSums[0, i] = mat[0][i];

        for (int i = 0; i < n; i++)
        {
            for (int j = 1; j < m; j++)
            {
                columnSums[j, i] = columnSums[j - 1, i] + mat[j][i];
            }
        }

        //////////
        ///

        int result = 0;

        long[,] previous = new long[m, n];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                previous[i, j] = mat[i][j];
                if (mat[i][j] <= threshold)
                {
                    result = 1;
                }
            }
        }

        int maxLength = Math.Min(m, n);
        for (int L = 2; L <= maxLength; L++)
        {
            long[,] next = new long[m, n];

            for (int i = 0; i < m - L + 1; i++)
            {
                for (int j = 0; j < n - L + 1; j++)
                {
                    next[i, j] = mat[i][j] + (rowSums[i, j + L - 1] - rowSums[i, j]) + (columnSums[i + L - 1, j] - columnSums[i, j]) + previous[i + 1, j + 1];
                    if (next[i, j] <= threshold)
                    {
                        result = L;
                    }
                }
            }

            previous = next;
        }

        return result;
    }
}
