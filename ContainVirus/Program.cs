using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainVirus
{
    class Program
    {
        static void Main(string[] args)
        {
            /// Ejemplo 1 // Respuesta 10 
            int[,] grid = new int[,]
            {
                { 0, 1, 0, 0, 0, 0, 0, 1 },
                { 0, 1, 0, 0, 0, 0, 0, 1},
                { 0, 0, 0, 0, 0, 0, 0, 1},
                {0, 0, 0, 0, 0, 0, 0, 0}
            };
            /// Ejemplo 2 Respuesta 4 
            grid = new int[,]
            {
                {1,1,1 },
                { 1,0,1},
                {1,1,1}
            };

            /// Ejemplo 2 // REspuesta 13
            grid = new int[,]
            {
                {1,1,1,0,0,0,0,0,0 },
                {1,0,1,0,1,1,1,1,1},
                {1,1,1,0,0,0,0,0,0}
            };

            grid = new int[,]

            {{0,1,0,1,1,1,1,1,1,0}
            ,{0,0,0,1,0,0,0,0,0,0}
            ,{0,0,1,1,1,0,0,0,1,0}
            ,{0,0,0,1,1,0,0,1,1,0}
            ,{0,1,0,0,1,0,1,1,0,1}
            ,{0,0,0,1,0,1,0,1,1,1}
            ,{0,1,0,0,1,0,0,1,1,0}
            ,{0,1,0,1,0,0,0,1,1,0}
            ,{0,1,1,0,0,1,1,0,0,1}
            ,{1,0,1,1,0,1,0,1,0,1}
            };

            Solution s = new Solution();
            var count = s.ContainVirus(grid);
            
        }
    }
}
