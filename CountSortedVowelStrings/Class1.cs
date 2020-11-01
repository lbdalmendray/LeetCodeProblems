using System;
using System.Linq;

namespace CountSortedVowelStrings
{
    public class Solution
    {
        public int CountVowelStrings(int n)
        {
            int[,] infos = new int[5, n + 1];
            for (int i = 0; i < 5; i++)
            {
                infos[i, 0] = 1;
            }
            

            for (int j = 1; j <= n ; j++)
            {
                infos[0, j] = 1;
            }

            for (int i = 1; i < 5 ; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    for (int k = 0; k <= j; k++)
                    {
                        infos[i, j] += /*k+*/ infos[i - 1, j - k]; 
                    }
                }
            }

            return infos[4, n];
        }
    }
}
