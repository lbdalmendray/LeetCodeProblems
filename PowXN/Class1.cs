using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowXN
{
    public class Solution
    {
        public double MyPow(double x, int n)
        {
            long nLong = n;

            var result = MyPowAux(Math.Abs(x), Math.Abs(nLong));
            if (nLong % 2 != 0 && x < 0)
                result *= -1;
            if (nLong < 0)
                result = 1.0 / result;
            return result;
        }

        private double MyPowAux(double x, long n)
        {
            if (n == 1)
            {
                return x;
            }
            else if (n == 0)
            {
                return 1;
            }
            var nDiv2 = n / 2;
            var nRest = n % 2;
            double resNDiv2 = MyPowAux(x, nDiv2);
            double resNRest = MyPowAux(x, nRest);
            var result = resNDiv2 * resNDiv2 * resNRest;
            return result;
        }
    }
}
