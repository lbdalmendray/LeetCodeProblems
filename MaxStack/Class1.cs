using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxStack
{
    public class MaxStack
    {
        SortedDictionary<int, LinkedList<LinkedListNode<int>>> sortedContainer;
        LinkedList<int> container;
        /** initialize your data structure here. */
        public MaxStack()
        {
            sortedContainer = new SortedDictionary<int, LinkedList<LinkedListNode<int>>>(Comparer<int>.Create((a, b) => b - a));
            container = new LinkedList<int>();
        }

        public void Push(int x)
        {
            var node = container.AddLast(x);
            if ( !sortedContainer.TryGetValue(x,out var list))
            {
                list = new LinkedList<LinkedListNode<int>>();
                sortedContainer.Add(x, list);
            }

            list.AddLast(node);
        }

        public int Pop()
        {
            if (container.Count == 0)
                return -1;

            var node = container.Last;
            RemoveNodeFromSortedContainer(node.Value);
            container.RemoveLast();
            return node.Value;
        }        

        public int Top()
        {
            if (container.Count == 0)
                return -1;
            return container.Last.Value;
        }

        public int PeekMax()
        {
            if (sortedContainer.Count == 0)
                return -1;
            return sortedContainer.First().Key;
        }

        public int PopMax()
        {
            if (sortedContainer.Count == 0)
                return -1;
            var keyValue = sortedContainer.First();
            container.Remove(keyValue.Value.Last.Value);
            RemoveNodeFromSortedContainer(keyValue.Key);
            return keyValue.Key;
        }

        private void RemoveNodeFromSortedContainer(int value)
        {
            var list = sortedContainer[value];
            list.RemoveLast();
            if (list.Count == 0)
                sortedContainer.Remove(value);
        }
    }

    /**
     * Your MaxStack object will be instantiated and called as such:
     * MaxStack obj = new MaxStack();
     * obj.Push(x);
     * int param_2 = obj.Pop();
     * int param_3 = obj.Top();
     * int param_4 = obj.PeekMax();
     * int param_5 = obj.PopMax();
     */
}
