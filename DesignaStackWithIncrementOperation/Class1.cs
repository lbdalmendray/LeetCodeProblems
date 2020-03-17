using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignaStackWithIncrementOperation
{
    public class CustomStack
    {
        LinkedList<int> list = new LinkedList<int>();
        int maxSize;
        public CustomStack(int maxSize)
        {
            this.maxSize = maxSize;
        }

        public void Push(int x)
        {
            if (list.Count == maxSize)
                return;
            list.AddLast(x);
        }

        public int Pop()
        {
            if (list.Count == 0)
                return -1;
            var result = list.Last();
            list.RemoveLast();
            return result;
        }

        public void Increment(int k, int val)
        {
            if (list.Count == 0)
                return;
            var node = list.First;
            for (int i = 0; i < k && i < list.Count ; i++)
            {
                node.Value += val;
                node = node.Next;
            }            
        }
    }
}
