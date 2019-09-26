using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var aaaaa = -.4;
            //var a2313 = double.Parse(".-4");
            

            var aaa = "    b a".Split(' ');

            Solution s = new Solution();

            string[] numbers = new string[]
            {
                "-.1e10",
                ".",
                ".1e10",
                "1.e10",
                "   .-4",
                "   111e+20",
                "   111e-20",
                " 005047e+6",
                ".1",
                "1.",
                "    ",
                "    1111.34444   ",
                "    1111.34444e  ",
                "   111e20",
                "  0000003.45444  ",
                "1111.34444  ",
                "1111.34444e10.4",
                "1111.34444e10.4",
                "23 23",
                "23 ",
            };

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i] + "    " + s.IsNumber(numbers[i]) ) ;
                
            }


            Console.ReadLine();
        }
    }
}
