using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountCornerRectangles
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> l = new LinkedList<int>();
            LinkedList<int> l2 = new LinkedList<int>();
            Tuple<int> a;

            l.AddLast(10);
            l2.AddLast(20);
            l2.AddLast(30);
            l.AddLast(l2.First);

            string abc = "abcdefghijklmnopqrstvwxyz";
            string jjj = "122AbXd00".ToLower();

            int min = 'a';
            int max = 'a';

            for (int i = 1; i < abc.Length; i++)
            {
                if (abc[i] > max)
                    max = abc[i];
                if (abc[i] < min)
                    min = abc[i];
            }

            

            /*
             * 
             * [[1, 0, 0, 1, 0],
 [0, 0, 1, 0, 1],
 [0, 0, 0, 1, 0],
 [1, 0, 1, 0, 1]]
             
             */

            Solution s = new Solution();
            int[,] grid = new int[,] { 
                { 1, 0, 0, 1, 0 }, 
                { 0, 0, 1, 0, 1 }, 
                { 0, 0, 0, 1, 0 }, 
                { 1, 0, 1, 0, 1 } };

            grid = new int[,] {
                { 1, 1,1 },
                { 1, 1,1 },
            { 1, 1,1 }};

            //grid = new int[200, 200];
            //for (int i = 0; i < 200; i++)
            //{
            //    for (int j = 0; j < 200; j++)
            //    {
            //        grid[i, j] = 1;
            //    }
            //}
            //var aa = s.CountCornerRectangles(grid);
            var aa2 = s.CountCornerRectanglesV2(grid);
            var aa3 = s.CountCornerRectanglesV3(grid);

        }
    }
}
