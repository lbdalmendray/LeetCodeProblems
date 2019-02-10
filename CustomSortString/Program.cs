using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSortString
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var result = s.CustomSortString("cbaf3467g", "abcd");
            Console.WriteLine(result);
            result = s.CustomSortString("c", "abcd");
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
