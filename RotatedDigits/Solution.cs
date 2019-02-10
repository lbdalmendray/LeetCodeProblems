using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotatedDigits
{
    public class Solution
    {
        public int RotatedDigits(int N)
        {
            int count = 0;

            for (int i = 1; i <= N; i++)
            {
                if (GoodRotatedNumberAndDifferent(i))
                    count++;
            }
            return count;
        }

        public bool GoodRotatedNumberAndDifferent(int inputNumber)
        {
            string nString = inputNumber.ToString();
            bool oneDifferent = false;

            char[] goodDigits = new char [] { '2', '5', '6', '9' };
            char[] badDigits = new char [] { '3', '4' ,'7' };
            //char[] normalDigits = new char[] {'0' , '1' , '8' };

            for (int i = 0; i < nString.Length ; i++)
            {
                if ( goodDigits.Contains( nString[i]) )
                {
                    oneDifferent = true;
                }
                else if ( badDigits.Contains(nString[i]))
                {
                    return false;
                }
            }

            return oneDifferent;
        }
    }
}
