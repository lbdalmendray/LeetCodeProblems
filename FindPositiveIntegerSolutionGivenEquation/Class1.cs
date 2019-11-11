using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindPositiveIntegerSolutionGivenEquation
{
    /*
 * // This is the custom function interface.
 * // You should not implement it, or speculate about its implementation
 * public class CustomFunction {
 *     // Returns f(x, y) for any given positive integers x and y.
 *     // Note that f(x, y) is increasing with respect to both x and y.
 *     // i.e. f(x, y) < f(x + 1, y), f(x, y) < f(x, y + 1)
 *     public int f(int x, int y);
 * };
 */

    public class Solution
    {
        public IList<IList<int>> FindSolution(CustomFunction customfunction, int z)
        {
            LinkedList<IList<int>> result = new LinkedList<IList<int>>(); 

            for (int i = 1; i < 1000; i++)
            {
                if(FindSolution(customfunction,z, i, out IList<int> resultPart))
                {
                    result.AddLast(resultPart);
                }
            }

            return result.ToList() as IList<IList<int>>;
        }

        private bool FindSolution(CustomFunction customfunction,int z, int x, out IList<int> result)
        {
            int i = 1;
            int j = 1000;
            result = null;

            while(i <= j)
            {
                if ( i == j )
                {
                    if ( customfunction.f(x,j) == z)
                    {
                        result = new int[] { x, j }.ToList();
                        return true;
                    }
                    return false;
                }
                else if ( j-i == 1)
                {
                    if (customfunction.f(x, i) == z)
                    {
                        result = new int[] { x, i }.ToList();
                        return true;
                    }
                    else if (customfunction.f(x, j) == z)
                    {
                        result = new int[] { x, j }.ToList();
                        return true;
                    }
                    return false;
                }
                int mid = (i + j) / 2;
                var value = customfunction.f(x, mid);
                if (value == z)
                {
                    result = new int[] { x, mid }.ToList();
                    return true;
                }
                else if (value < z)
                {
                    i = mid + 1;
                }
                else
                    j = mid - 1;
            }

            return false;
        }
    }
}
