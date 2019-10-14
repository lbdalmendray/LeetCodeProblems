using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywithChips
{
    public class Solution
    {
        public int MinCostToMoveChips(int[] chips)
        {
            int number2 = 0;
            int numberNot2 = 0;

            foreach (var item in chips)
            {
                if (item % 2 == 0)
                    number2++;
                else
                    numberNot2++;
            }
            if (number2 >= numberNot2)
                return numberNot2;
            else
                return number2;
        }
    }
}
