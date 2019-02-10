using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidTic_Tac_ToeState
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();

            String[] input = new string[3] { "O  ", "   ", "   " };

            input = new string[3] { "O  ", "   ", "   " };
            var result = s.ValidTicTacToe(input);
            Console.WriteLine(input + " " + result + ":" + false);

            input = new string[3] { "XOX", " X ", "   " };
            result= s.ValidTicTacToe(input);
            Console.WriteLine(input + " " + result + ":" + false);


            input = new string[3] { "XXX", "   ", "OOO" };
            result= s.ValidTicTacToe(input);
            Console.WriteLine(input + " " + result + ":" + false);

            input = new string[3] { "XOX", "O O", "XOX" };
            result = s.ValidTicTacToe(input);
            Console.WriteLine(input + " " + result + ":" + true);

            input = new string[3] { "XOX", "OXO", "O X" };
            result = s.ValidTicTacToe(input);
            Console.WriteLine(input + " " + result + ":" + false);

            input = new string[3] { "   ", "   ", "   " };
            result = s.ValidTicTacToe(input);
            Console.WriteLine(input + " " + result + ":" + true);

            input = new string[3] { "XXO", "XOX", "OXO" };
            result = s.ValidTicTacToe(input);
            Console.WriteLine(input + " " + result + ":" + false);
            // ["XXO","XOX","OXO"]


            //"XXO"
            //"XOX"
            //"OXO"
            Console.ReadLine();




        }
    }
}
