using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRUCache
{
    public class LRUCache
    {
        private readonly int capacity;
        private readonly LinkedList<int> keyOrder = new LinkedList<int>();
        private readonly Dictionary<int, Info> dictionary;

        public LRUCache(int capacity)
        {
            if (capacity < 0)
                capacity = 0;

            this.capacity = capacity;
            dictionary = new Dictionary<int, Info>(capacity);
        }

        public int Get(int key)
        {
            if (dictionary.TryGetValue(key, out var info))
            {
                PutFirst(key, info);
                
                return info.Value;
            }
            else
                return -1;
        }

        public void Put(int key, int value)
        {
            if (dictionary.TryGetValue(key, out var info))
            {
                PutFirst(key, info);
                info.Value = value;
            }
            else
            {
                if (capacity == 0)
                    return;

                if (keyOrder.Count == capacity)
                    RemoveLast();
                var node = keyOrder.AddFirst(key);
                info = new Info { Value = value, Node = node };
                dictionary.Add(key, info);                
            }
        }        

        private void PutFirst(int key, Info info)
        {
            LinkedListNode<int> node = info.Node;
            keyOrder.Remove(node);
            info.Node = keyOrder.AddFirst(key);
        }

        private void RemoveLast()
        {
            var key = keyOrder.Last.Value;
            keyOrder.RemoveLast();
            dictionary.Remove(key);
        }

        private class Info
        {
            public int Value { get; internal set; }
            public LinkedListNode<int> Node { get; internal set; }
        }
    }

    
}
