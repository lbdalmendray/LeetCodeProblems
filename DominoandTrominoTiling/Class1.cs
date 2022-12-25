namespace DominoandTrominoTiling
{
    public class Solution
    {
        private readonly ulong Modulo = 1000_000_007;
        public int NumTilings(int n)
        {
            ulong?[] solutions = new ulong?[n > 2 ? n + 1 : 3];
            ulong?[] solutionSums = new ulong?[n > 2 ? n + 1 : 3];
            
            solutionSums[0] = 1;
            solutionSums[1] = 2;

            solutions[0] = 1;
            solutions[1] = 1;
            solutions[2] = 2;

            for (int i = 2; i <= n-1; i++)
            {
                solutionSums[i] = (solutionSums[i - 1] + Solve(i, solutions, solutionSums)) % Modulo;
            }

            return (int)(Solve(n, solutions, solutionSums) );
        }

        private ulong Solve(int n, ulong?[] solutions, ulong?[] solutionSums)
        {
            if (n < 0)
                return 0;
            else if (!solutions[n].HasValue)
            {
                ulong result = 0;

                /*
                 -- 
                     P(n-2) 
                 --
                 */

                result = (result +  Solve(n - 2, solutions, solutionSums) ) % Modulo;

                /*
                 | 
                    P(n-1)
                 |
                 */

                result = (result + Solve(n - 1, solutions, solutionSums)) % Modulo;

                /////////
                
                //for (int i = 0; i <= n-3; i++)
                //{
                //    result = (result + 2 * Solve(i, solutions, solutionSums)) % Modulo;
                //}

                /*
                |  --       --  _|
                        ...      
                |-  --        -- |
                */

                result = (result + 2 * solutionSums[n - 3].Value) % Modulo;
                
                /////////
                
                solutions[n] = result;
            }
            return solutions[n].Value;
        }
    }
}