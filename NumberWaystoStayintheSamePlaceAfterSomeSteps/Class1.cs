using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NumberWaystoStayintheSamePlaceAfterSomeSteps
{
    public class Solution
    {
        public int NumWays(int steps, int arrLen)
        {
            Info[,] infos = new Info[steps+1, steps/2 + 2];
            var result = NumWaysAux(steps, 0, arrLen, infos);
            return (int)((result) % (1000000000 + 7));
        }

        private BigInteger NumWaysAux(int steps, int index, int arrLen, Info[,] infos)
        {
            if (index < 0 || index >= arrLen || index >= infos.GetLength(1) )
                return 0;

            if ( infos[steps,index] != null)
            {
                return infos[steps, index].Result;
            }

            infos[steps, index] = new Info();

            
            if( steps == 0)
            {
                if (index == 0)
                {
                    infos[steps, index].Result = 1;
                    return 1;
                }
                else
                    return 0;
            }

            BigInteger result = 0;

            result += NumWaysAux(steps - 1, index, arrLen, infos);
            result += NumWaysAux(steps - 1, index + 1, arrLen, infos);
            result += NumWaysAux(steps - 1, index - 1, arrLen, infos);

            infos[steps, index].Result = result;
            return result;
        }
    }

    internal class Info
    {
        public BigInteger Result { get; internal set; }
    }
}
