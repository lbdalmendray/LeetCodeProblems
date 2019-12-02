using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberofBurgerswithNoWasteofIngredients
{
    public class Solution
    {
        public IList<int> NumOfBurgers(int tomatoSlices, int cheeseSlices)
        {
            if ( tomatoSlices %2 != 0 )
            {
                return new List<int>();
            }

            int tomatHalf = tomatoSlices/ 2;
            if (tomatHalf < cheeseSlices)
                return new List<int>();

            LinkedList<int> result = new LinkedList<int>();
            int k1 = tomatHalf - cheeseSlices;
            int k2 = cheeseSlices - k1;
            if ( k2 < 0 || k1 < 0 )
                return new List<int>();
            result.AddLast(k1);
            result.AddLast(k2);
            return result.ToList();
        }
    }
}
