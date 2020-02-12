using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberofStepstoReduceaNumbertoZero
{
    public class Solution
    {
        public int NumberOfSteps(int num)
        {
            int result = 0;
            while(num != 0 )
            {
                if (num % 2 == 0)
                    num /= 2;
                else
                    num--;
                result++;
            }

            return result;
        }
    }
}
