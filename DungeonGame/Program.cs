using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            var result = s.CalculateMinimumHP(new int[,] 
            { 
                { -2, -3, 3 }, 
                { -5, -10, 1 }, 
                { 10, 30, -5 }
            });
            Console.WriteLine(result);
            Console.ReadLine();

            ////////////////////////////////////////////////

            s = new Solution();
            result = s.CalculateMinimumHP(new int[,]
            {
                { -2 },
                { -4},
                { 10 }
            });
            Console.WriteLine(result);
            Console.ReadLine();


            ////////////////////////////////////////////////

            s = new Solution();
            result = s.CalculateMinimumHP(new int[,]
            {
                { -2, -3, 0 , -3 },
                { -5, -10, 0 , 6},
                { 10, 30, -5 , -8}
            });
            Console.WriteLine(result);
            Console.ReadLine();

            ////////////////////////////////////////////////

            s = new Solution();
            result = s.CalculateMinimumHP(new int[,]
            {
                { -2}
            });
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
