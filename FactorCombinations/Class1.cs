using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorCombinations
{
    public class Solution
    {
        public IList<IList<int>> GetFactors(int n)
        {
            LinkedList<LinkedList<int>> result = new LinkedList<LinkedList<int>>();
            CalculateFactors(2, n, new LinkedList<int> () , result);
            return result.Select(e => e.ToList() as IList<int>).ToList();
        }

        private void CalculateFactors( int first , int last , LinkedList<int> currentList , LinkedList<LinkedList<int>> result)
        {
            if ( last == 1 )
            {
                if (currentList.Count > 1)
                    result.AddLast(Clone(currentList));
            }
            else
            {

                for (int i = first; i <= last; i++)
                {
                    if( last % i == 0)
                    {
                        currentList.AddLast(i);
                        CalculateFactors(i, last / i, currentList, result);
                        currentList.RemoveLast();
                    }
                }
            }
        }

        private LinkedList<int> Clone(LinkedList<int> input)
        {
            LinkedList<int> result = new LinkedList<int>();
            foreach(var item in input)
            {
                result.AddLast(item);
            }
            return result;
        }
    }
}
