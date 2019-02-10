using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindRedundantDirectedConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // [[1,2], [1,3], [2,3]]
            // [[1,2], [2,3], [3,4], [4,1], [1,5]]
            Solution s = new Solution();
            var sample = new int[,] {
                {1,2 },
                {1,3 },
                {2,3 }
            };
            sample = new int[,] {
                {1,2},
                {2,3},
                {3,4},
                {4,1},
                {1,5}
            };

            //sample = new int[,]
            //{
            //    {1,2},
            //    {2,3},
            //    {7,4},
            //    {4,5},
            //    {1,6},
            //    {6,7},
            //    {3,4},
            //    {8,1}
            //};
            //[[4,2],[1,5],[5,2],[5,3],[2,4]]

            //sample = new int[,]
            //{
            //    {4,2},
            //    { 1,5},
            //    {5,2 },
            //    {5,3 },
            //    {2,4 },
            //};

            sample = new int[,]
            {
                { 1,2 },
                { 2,3 },
                { 3,4 },
                { 2,2 }
            };

            var rr = s.FindRedundantDirectedConnection(sample);
            
        }
    }
}
