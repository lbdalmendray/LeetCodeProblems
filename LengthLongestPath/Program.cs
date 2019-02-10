using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LengthLongestPath
{
    class Program
    {
        static void Main(string[] args)
        {

            Solution s = new Solution();
            var result = s.LengthLongestPath("dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext");
            Console.WriteLine(result);
            result = s.LengthLongestPath("dir\n\tsubdir1\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2");
            Console.WriteLine(result);
            result = s.LengthLongestPath("dir\n\ttfile1.ext");
            Console.WriteLine(result);
            result = s.LengthLongestPath("dir\n\ttfile1");
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
