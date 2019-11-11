using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumSwapstoMakeStringsEqual
{
    public class Solution
    {
        public int MinimumSwap(string s1, string s2)
        {
            int xs = 0;
            int ys = 0;
            
            for (int i = 0; i < s1.Length; i++)
            {
                if( s1[i] != s2[i])
                {
                    if (s1[i] == 'x')
                    {
                        xs++;
                    }
                    else
                        ys++;
                }
            }

            if ((xs + ys) % 2 != 0)
                return -1;

            return xs / 2 + ys / 2 + xs % 2 + ys % 2;
        }
    }
}
