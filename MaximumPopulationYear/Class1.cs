using System;

namespace MaximumPopulationYear
{
    public class Solution
    {
        public int MaximumPopulation(int[][] logs)
        {
            int[] yearsCounter = new int[2050 + 1 ];

            for (int i = 0; i < logs.Length; i++)
            {
                for (int j = logs[i][0]; j < logs[i][1]; j++)
                {
                    yearsCounter[j]++;
                }
            }

            int bestyear = 1950;
            for (int i = 1951; i < 2051; i++)
            {
                if( yearsCounter[bestyear] < yearsCounter[i])
                {
                    bestyear = i;
                }
            }

            return bestyear;
        }
    }
}
