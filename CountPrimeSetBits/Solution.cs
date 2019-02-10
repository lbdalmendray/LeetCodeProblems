using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountPrimeSetBits
{
    public class Solution
    {
        public int CountPrimeSetBits(int L, int R)
        {

            int[] primes = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31 };

            int primerCount = 0;
            for (int i = L; i <= R; i++)
            {
                int bits1 = GetCountBinaryBits(i);
                if (Array.BinarySearch<int>(primes, bits1) > -1)
                    primerCount++;
            }
            return primerCount;
        }

        public int GetCountBinaryBits(int number)
        {
            string binaryf = Convert.ToString(number, 2);
            int result = 0;

            for (int i = 0; i < binaryf.Length; i++)
            {
                if (binaryf[i] == '1')
                    result++;
            }

            return result;
        }


    }
}
