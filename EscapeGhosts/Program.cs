using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeGhosts
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[][] ghosts = new int[][] { new int []{1,0 } , new int[]{0,3 } };
            int[] target = new int[] {0,1  };
            Console.WriteLine(s.EscapeGhosts(ghosts, target));
            ghosts = new int[][] { new int[] { 1, 0 } };
            target = new int[] { 2, 0 };
            Console.WriteLine(s.EscapeGhosts(ghosts, target));
            ghosts = new int[][] { new int[] { 2, 0 } };
            target = new int[] { 1, 0 };
            Console.WriteLine(s.EscapeGhosts(ghosts, target));
            Console.ReadLine();
        }
    }
}
