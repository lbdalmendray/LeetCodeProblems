using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximum69Number
{
    public class Solution
    {
        public int Maximum69Number(int num)
        {
            var numString = num.ToString().ToArray();

            for (int i = 0; i < numString.Length; i++)
            {
                if (numString[i] == '6')
                {
                    numString[i] = '9';
                    break;
                }
            }

            return int.Parse(new string(numString));
        }
    }
}
