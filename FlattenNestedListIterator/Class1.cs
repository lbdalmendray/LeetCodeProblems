using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlattenNestedListIterator
{
    /**
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * interface NestedInteger {
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */
    public class NestedIterator
    {
        LinkedList<int> list;
        LinkedListNode<int> node;
        public NestedIterator(IList<NestedInteger> nestedList)
        {
            list = new LinkedList<int>();
            DFS(nestedList, list);
            node = list.First;
        }

        private void DFS(IList<NestedInteger> nestedList, LinkedList<int> list)
        {
            foreach (var item in nestedList)
            {
                DFS(item, list);
            }
        }

        private void DFS(NestedInteger nestedInteger, LinkedList<int> list)
        {
            if( nestedInteger.IsInteger())
            {
                list.AddLast(nestedInteger.GetInteger());
            }
            else
            {
                foreach (var item in nestedInteger.GetList())
                {
                    DFS(item, list);
                }
            }
        }

        public bool HasNext()
        {
            return node != null;
        }

        public int Next()
        {
            if (HasNext())
            {
                var result = node;
                node = node.Next;
                return result.Value;
            }
            else
                throw new Exception("Do not have any other element");
        }
    }

    /**
     * Your NestedIterator will be called like this:
     * NestedIterator i = new NestedIterator(nestedList);
     * while (i.HasNext()) v[f()] = i.Next();
     */
}
