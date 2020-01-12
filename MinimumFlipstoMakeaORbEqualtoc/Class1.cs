using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumFlipstoMakeaORbEqualtoc
{
    public class Solution
    {
        public int MinFlips(int a, int b, int c)
        {
            var aBinary = Convert.ToString(a, 2).Reverse().ToArray();
            var bBinary = Convert.ToString(b, 2).Reverse().ToArray();
            var cBinary = Convert.ToString(c, 2).Reverse().ToArray();
            

            int result = 0;
            int max = Math.Max( Math.Max(aBinary.Length, bBinary.Length),cBinary.Length );
            for (int i = 0; i < max; i++)
            {
                var aValue = i < aBinary.Length ? aBinary[i] : '0'; 
                var bValue = i < bBinary.Length ? bBinary[i] : '0';
                var cValue = i < cBinary.Length ? cBinary[i] : '0';
                result += Calculate(aValue, bValue, cValue);
            }

            return result;
        }

        private int Calculate(char aValue, char bValue, char cValue)
        {
            if ((aValue == '1' && bValue == '0') || (aValue == '0' && bValue == '1'))
            {
                if (cValue == '0')
                    return 1;
            }
            else if (aValue == '1' && bValue == '1')
            {
                if (cValue == '0')
                    return 2;

            }
            else if (aValue == '0' && bValue == '0')
            {
                if (cValue == '1')
                    return 1;
            }
            return 0;
        }
    }
}
