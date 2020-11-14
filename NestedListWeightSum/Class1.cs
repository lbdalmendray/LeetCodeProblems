using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedListWeightSum
{
    public class Solution
    {
        public int DepthSum(IList<NestedInteger> nestedList)
        {
            int result = 0;

            foreach (var item in nestedList)
            {
                result += CalculateSum(item);
            }

            return result;
        }

        private int CalculateSum(NestedInteger input)
        {
            int result = 0;
            LinkedList<(NestedInteger, int)> queue = new LinkedList<(NestedInteger, int)>();
            queue.AddLast((input, 1));

            while(queue.Count != 0)
            {
                ( NestedInteger current , int depth ) = queue.First.Value;
                queue.RemoveFirst();

                if( current.IsInteger())
                {
                    result += current.GetInteger() * depth;
                }
                else
                {
                    foreach (var item in current.GetList())
                    {
                        queue.AddLast((item, depth + 1));
                    }
                }
            }

            return result;
        }
    }
}
