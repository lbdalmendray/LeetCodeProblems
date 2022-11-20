using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TheEmployeeThatWorkedontheLongestTask
{
    public class Solution
    {
        public int HardestWorker(int n, int[][] logs)
        {
            int bestResultIndex = 0;
            int[] durations = new int[logs.Length];
            durations[0] = logs[0][1];

            for (int i = 1; i < logs.Length; i++)
            {
                durations[i] = logs[i][1] - logs[i - 1][1];
            }

            for (int i = 1; i < logs.Length; i++)
            {
                if (durations[i] > durations[bestResultIndex])
                {
                    bestResultIndex = i;
                }
                else if (durations[i] == durations[bestResultIndex])
                {
                    if (logs[i][0] < logs[bestResultIndex][0])
                        bestResultIndex = i;
                }
            }

            return logs[bestResultIndex][0];
        }
    }
}
