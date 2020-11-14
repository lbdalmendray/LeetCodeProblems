using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedListWeightSumII
{
    public class Solution
    {
        public int DepthSumInverse(IList<NestedInteger> nestedList)
        {
            int depth = 1;
            foreach (var item in nestedList)
            {
                depth = Math.Max(depth, GetDepth(item));
            }

            int sum = 0;

            foreach (var item in nestedList)
            {
                sum += GetSum(item, depth);
            }

            return sum;
        }

        private int GetSum(NestedInteger nestedIntegerInput, int depth)
        {
            int result = 0;
            LinkedList<(NestedInteger, int)> queue = new LinkedList<(NestedInteger, int)>();
            queue.AddLast((nestedIntegerInput, depth));
            
            while(queue.Count!= 0)
            {
                (NestedInteger ni, int cDepth) = queue.First.Value;
                queue.RemoveFirst();

                if (ni.IsInteger())
                    result += ni.GetInteger() * cDepth;
                else
                {
                    foreach (var item in ni.GetList())
                    {
                        queue.AddLast((item, cDepth - 1));
                    }
                }
            }
            
            return result;
        }

        private int GetDepth(NestedInteger nesteInteger)
        {
            int maxDepth = 1;
            LinkedList<(NestedInteger, int)> queue = new LinkedList<(NestedInteger, int)>();
            queue.AddLast((nesteInteger, maxDepth));

            while( queue.Count != 0)
            {
                (NestedInteger ni, int depth) = queue.First.Value;
                queue.RemoveFirst();

                if (ni.IsInteger())
                    maxDepth = Math.Max(maxDepth, depth);
                else
                {
                    foreach (var item in ni.GetList())
                    {
                        queue.AddLast((item, depth + 1));
                    }
                }
            }
            
            return maxDepth;
        }
    }
}
