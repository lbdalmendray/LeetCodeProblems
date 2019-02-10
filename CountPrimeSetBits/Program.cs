using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountPrimeSetBits
{
    class Program
    {
        static void Main(string[] args)
        {
            char c = 'a';
            for (int jj = 0; jj < 26; jj++)
            {
                Console.WriteLine(c++);
            }
            Console.ReadLine();
           
            int i = 8;
            var aa = i << 1;
            int[] primes = new int[] { 2, 3, 5, 7,11, 13, 17, 19, 23, 29, 31 };
            string aaa = Convert.ToString(8, 2);
        }
    }
}
