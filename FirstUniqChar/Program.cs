using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstUniqChar
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            Console.WriteLine(s.FirstUniqChar("abcdedsdeabcs"));
            Console.WriteLine(s.FirstUniqChar("loveleetcode"));
            Console.WriteLine(s.FirstUniqChar("leetcode"));

            Console.ReadLine();
        }
    }
}
