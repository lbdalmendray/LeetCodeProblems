namespace DiagonalTraverse;

public class Solution
{
    public int[] FindDiagonalOrder(int[][] mat)
    {
        int m = mat.Length;
        int n = mat[0].Length;

        if (m == 1)
            return mat[0];
        else if (n == 1)
        {
            int[] result = new int[m];
            for (int i = 0; i < m; i++)
            {
                result[i] = mat[i][0];
            }
            return result;
        }
        else
        {
            int counter = 0;
            int total = m * n;
            int x = 0;
            int y = 0;
            bool up = true;
            int[] result = new int[total];
            while (counter < total)
            {
                result[counter] = mat[x][y];
                counter++;

                if (up)
                {
                    if (y == n - 1)
                    {
                        x++;
                        up = false;
                    }
                    else if (x == 0)
                    {
                        y++;
                        up = false;
                    }
                    else
                    {
                        x--;
                        y++;
                    }
                }
                else /// down
                {
                    if (x == m - 1)
                    {
                        y++;
                        up = true;
                    }

                    else if (y == 0)
                    {
                        x++;
                        up = true;
                    }
                    else
                    {
                        x++;
                        y--;
                    }
                }
            }

            return result;
        }
    }
}
