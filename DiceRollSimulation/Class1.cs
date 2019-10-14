using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DiceRollSimulation
{
    public class Solution
    {
        public int DieSimulator(int n, int[] rollMax)
        {
            ulong result = 0;

            ulong?[,,] solutions = new ulong?[n+1, rollMax.Length, rollMax.Max()+1];
            ulong?[,]  sumSolutions = new ulong?[n+1, rollMax.Length];
            int rollMaxMax = rollMax.Max() + 1;
            for (int j = 1; j < n; j++)
            {
                for (int k = 1; k <= rollMaxMax; k++)
                {
                    for (int i = 0; i < rollMax.Length; i++)
                    {
                        if (k > rollMax[i])
                            continue;
                        GetSolution(j, i, k, solutions, rollMax,sumSolutions);
                    }
                }
            }

            for (int i = 0; i < rollMax.Length; i++)
            {
                result += GetSolution(n, i, rollMax[i], solutions, rollMax, sumSolutions);
            }

            return (int)(result % (1000000000 + 7));
        }

        private ulong GetSolution(int n, int i, int maxSeq, ulong?[,,] solutions, int[] rollMax, ulong?[,] sumSolutions)
        {
            if (solutions[n, i, maxSeq].HasValue)
                return solutions[n, i, maxSeq].Value;
            ulong result = 0 ;

            if ( n == 1)
            {
                result = 1;
            }
            else
            {
                if (maxSeq > 1)
                    result += GetSolution(n - 1, i, maxSeq - 1, solutions, rollMax, sumSolutions) % (1000000000 + 7);

                if (!sumSolutions[n, i].HasValue)
                {
                    sumSolutions[n, i] = 0;
                    for (int j = 0; j < rollMax.Length; j++)
                    {
                        if (j == i)
                            continue;
                        sumSolutions[n, i] += GetSolution(n - 1, j, rollMax[j], solutions, rollMax, sumSolutions) % (1000000000 + 7);
                    }
                }
                result += sumSolutions[n, i].Value % (1000000000 + 7);
            }

            solutions[n, i, maxSeq] = result;
            return result;
        }
    }
}
