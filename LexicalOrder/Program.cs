using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            var aaa =  String.Compare("10", "10");

            Solution s = new Solution();

            var first = DateTime.Now;
            Console.WriteLine(first);
            //var r = s.LexicalOrder(5000000);
            var r = s.LexicalOrder(100);
            for (int i = 0; i < r.Count; i++)
            {
                Console.WriteLine(r[i]);
            }
            Console.WriteLine("FINISHED");
            var last = DateTime.Now;
            Console.WriteLine(last);
            Console.WriteLine((last - first).TotalSeconds);

             first = DateTime.Now;
            Console.WriteLine(first);
             r = s.LexicalOrderV2(5000000);
            //for (int i = 0; i < r.Count ; i++)
            //{
            //    Console.WriteLine(r[i]);
            //}
            Console.WriteLine("FINISHED");
             last = DateTime.Now;
            Console.WriteLine(last);
            Console.WriteLine((last - first).TotalSeconds);


            Console.ReadLine();
        }
    }
}
