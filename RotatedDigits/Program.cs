using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotatedDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var result = s.RotatedDigits(15);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
