using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIfItIsaStraightLine
{
    public class Solution
    {
        public bool CheckStraightLine(int[][] coordinates)
        {
            var coordinatesDouble = coordinates.Select(e => e.Select(ea => (double)ea).ToArray()).ToArray(); 
            var first = coordinatesDouble[0];
            var direction = new double[] { coordinatesDouble[1][0] - first[0], coordinatesDouble[1][1] - first[1] };

            for (int i = 2; i < coordinatesDouble.Length; i++)
            {
                var currentDirection = new double[] { coordinatesDouble[i][0] - first[0], coordinatesDouble[i][1] - first[1] };
                var scalar = ((double)direction[0] )/ ((double)currentDirection[0]);
                if (Math.Abs(currentDirection[1] * scalar - direction[1]) > 0.000000001)
                    return false;
            }

            return true;            
        }
    }
}
