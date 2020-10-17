using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFUCache
{
    public class LFUCache
    {
        LinkedList<FreqInfo> keyOrderList = new LinkedList<FreqInfo>();
        Dictionary<int, Info> dict;
        int capacity;
        int Length = 0;
        public LFUCache(int capacity)
        {
            this.capacity = capacity;
            dict = new Dictionary<int, Info>(capacity);
        }

        public int Get(int key)
        {
            if (dict.TryGetValue(key, out var info))
            {
                MoveKeyToNextPosition(info, key);
                return info.Value;
            }
            else
                return -1;
        }   

        public void Put(int key, int value)
        {
            if (dict.TryGetValue(key, out var info))
            {
                MoveKeyToNextPosition(info, key);
                info.Value = value;
            }
            else
            {
                LinkedListNode<FreqInfo> node1;
                LinkedListNode<int> node2;
                if ( Length == capacity)
                {
                    node1 = keyOrderList.First;
                    node2 = node1.Value.KeyList.Last;
                    int firstKey = node2.Value;
                    dict.Remove(firstKey);
                    RemoveNode2PossibleNode1(node1, node2);
                    Length--;
                }
                if (keyOrderList.Count > 0 && keyOrderList.First.Value.Freq == 1)
                {
                    node1 = keyOrderList.First;
                }
                else
                {
                    node1 = keyOrderList.AddFirst(new FreqInfo { Freq = 1 });
                }

                node2 = node1.Value.KeyList.AddLast(key);
                info = new Info { Node1 = node1, Node2 = node2, Value = value };
                dict.Add(key, info);
                Length++;                
            }
        }

        private void MoveKeyToNextPosition(Info info, int key)
        {
            LinkedListNode<FreqInfo> node1 = info.Node1;
            LinkedListNode<int> node2 = info.Node2;
            var node1Next = node1.Next;
            RemoveNode2PossibleNode1(node1, node2);
            AddToNext(node1Next, node1.Value.Freq + 1, key, info);
        }

        private void RemoveNode2PossibleNode1(LinkedListNode<FreqInfo> node1, LinkedListNode<int> node2)
        {
            node2.List.Remove(node2);
            if (node1.Value.KeyList.Count == 0)
            {
                keyOrderList.Remove(node1);
            }
        }

        private void AddToNext(LinkedListNode<FreqInfo> node1Next, ulong freq, int key, Info info)
        {
            if (node1Next == null)
                node1Next = keyOrderList.AddLast(new FreqInfo { Freq = freq });
            
            info.Node1 = node1Next;
            var node2 = node1Next.Value.KeyList.AddFirst(key);
            info.Node2 = node2;
        }

        private class FreqInfo
        {
            public ulong Freq { get; internal set; }
            public LinkedList<int> KeyList { get; private set; } = new LinkedList<int>();
        }

        private class Info
        {
            public int Value { get; internal set; }
            public LinkedListNode<FreqInfo> Node1 { get; internal set; }
            public LinkedListNode<int> Node2 { get; internal set; }
        }
    }
}
