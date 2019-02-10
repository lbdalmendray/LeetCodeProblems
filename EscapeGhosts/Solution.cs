using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeGhosts
{
    public class Solution
    {
        public bool EscapeGhosts(int[][] ghosts, int[] target)
        {
            int userDistance = Distance(target[0], target[1], 0, 0);
            for (int i = 0; i < ghosts.Length; i++)
            {
                int currentGDistance = Distance(target[0], target[1], ghosts[i][0], ghosts[i][1]);
                if (currentGDistance <= userDistance)
                    return false;
            }
            return true;
        }

        public int Distance ( int x , int y , int xt , int yt )
        {
            return Math.Abs(x - xt) + Math.Abs(y - yt);            
        }
    }
}
