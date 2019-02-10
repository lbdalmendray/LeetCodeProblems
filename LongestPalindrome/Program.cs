using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestPalindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var result = s.LongestPalindrome("ccc");
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
