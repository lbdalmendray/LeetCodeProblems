using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularPermutationinBinaryRepresentation
{
    public class Solution
    {
        public IList<int> CircularPermutation(int n, int start)
        {
            int potence = 0 ; 
            var result = CircularPermutation(n, ref potence);
            var node = result.First;
            while(node.Value != start)
            {
                node = node.Next;
            }

            LinkedList<int> resultBest = new LinkedList<int>();

            while (node != null)
            {
                resultBest.AddLast(node.Value);
                node = node.Next;
            }

            foreach (var item in result)
            {
                if (item == start)
                    break;
                resultBest.AddLast(item);
            }

            return resultBest.ToList();
        }

        public LinkedList<int> CircularPermutation(int n , ref int potence )
        {
            if ( n == 1)
            {
                potence = 1;
                var r = new LinkedList<int>();
                r.AddLast(0);
                r.AddLast(1);
                return r;
            }
            var result = CircularPermutation(n - 1, ref potence);
            potence = potence * 2;

            var node = result.First;
            while(node != null)
            {
                result.AddFirst(node.Value + potence);
                node = node.Next;
            }

            return result;
        }

    }
}
