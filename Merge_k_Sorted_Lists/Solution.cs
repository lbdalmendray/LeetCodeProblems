using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge_k_Sorted_Lists
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }

        public override string ToString()
        {
            return val.ToString();
        }
    }

    public class Solution
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null)
                return null;

            int nullCountList = 0;
            for (int i = 0; i < lists.Length; i++)
            {
                if (lists[i] != null)
                    nullCountList++;
            }
            if (nullCountList == 0)
                return null;

            ListNode[] realList = new ListNode[nullCountList];

            for (int i = 0, j = 0; i < lists.Length; i++)
            {
                if (lists[i] != null)
                {
                    realList[j] = lists[i];
                    j++;
                }
            }

            Tuple<ListNode, int>[] firstValues = new Tuple<ListNode, int>[nullCountList];

            for (int i = 0; i < nullCountList; i++)
            {
                firstValues[i] = new Tuple<ListNode, int>(realList[i], i);
                realList[i] = realList[i].next;
            }

            Heap heap = new Heap(firstValues);
            var minimum = heap.Extract_Minimum();
            var result = new ListNode(minimum.Item1.val);
            var resultt = result;

            ListNode lastToHeap = null;
            lastToHeap = ExtractLastToHeap(realList, minimum.Item2);

            while (heap.Length > 0 || lastToHeap != null)
            {
                if (lastToHeap != null)
                {
                    heap.InsertValue(new Tuple<ListNode, int>(lastToHeap, minimum.Item2));
                }
                minimum = heap.Extract_Minimum();
                resultt.next = new ListNode(minimum.Item1.val);
                resultt = resultt.next;
                lastToHeap = ExtractLastToHeap(realList, minimum.Item2);
                if (realList[minimum.Item2] == null)
                {
                    nullCountList--;
                }
                if (nullCountList == 1)
                {
                    if (lastToHeap != null)
                    {
                        heap.InsertValue(new Tuple<ListNode, int>(lastToHeap, minimum.Item2));
                    }
                    while (heap.Length != 0)
                    {
                        minimum = heap.Extract_Minimum();
                        resultt.next = new ListNode(minimum.Item1.val);
                        resultt = resultt.next;
                    }
                    int onlyListIndex = -1;
                    for (onlyListIndex = 0; onlyListIndex < realList.Length; onlyListIndex++)
                    {
                        if (realList[onlyListIndex] != null)
                            break;
                    }
                    resultt.next = realList[onlyListIndex];
                    break;
                }
            }

            return result;

        }

        public ListNode ExtractLastToHeap(ListNode[] realList, int lastMinumListIndex)
        {
            if (realList[lastMinumListIndex] != null)
            {
                var r = realList[lastMinumListIndex];
                realList[lastMinumListIndex] = realList[lastMinumListIndex].next;
                return r;
            }

            return null;
        }
    }

    public class Heap
    {
        private Tuple<ListNode, int>[] values;
        public int Length = 0;
        public Heap(Tuple<ListNode, int>[] values)
        {
            this.values = values;
            Length = values.Length;
            BuildHeap();
        }

        public void BuildHeap()
        {
            for (int i = LastNonLeaf(); i >= 0; i--)
            {
                Heapify(i);
            }
        }

        public void InsertValue(Tuple<ListNode, int> valuee)
        {
            values[Length] = valuee;
            Length++;
            int currentIndex = Length - 1;
            var parentIndex = Parent(currentIndex);

            while (parentIndex != -1 && values[parentIndex].Item1.val > values[currentIndex].Item1.val)
            {
                Swap(currentIndex, parentIndex);
                currentIndex = parentIndex;
                parentIndex = Parent(currentIndex);
            }
        }

        public int FirstLeafIndex()
        {
            return Parent(Length - 1) + 1;
        }

        public int LastNonLeaf()
        {
            return Parent(Length - 1);
        }

        public Tuple<ListNode, int> Extract_Minimum()
        {
            var result = values[0];
            Swap(0, Length - 1);
            Length--;
            Heapify(0);
            return result;
        }

        public int Parent(int childIndex)
        {
            if (childIndex > 0 && childIndex < Length)
                return ((int)((childIndex + 1) / 2)) - 1;
            return -1;
        }

        public int LeftChild(int parentIndex)
        {
            int childIndex = 2 * (parentIndex + 1) - 1;
            if (childIndex > Length - 1)
                return -1;
            return childIndex;
        }
        public int RightChild(int parentIndex)
        {
            int childIndex = 2 * (parentIndex + 1) - 1 + 1;
            if (childIndex > Length - 1)
                return -1;
            return childIndex;
        }
        public void Heapify(int index)
        {
            if (RightChild(index) != -1 && LeftChild(index) != -1)
            {
                if ((values[index].Item1.val <= values[RightChild(index)].Item1.val) && (values[index].Item1.val <= values[LeftChild(index)].Item1.val))
                {
                    return;
                }

                int minIndex = (values[RightChild(index)].Item1.val <= values[LeftChild(index)].Item1.val) ? RightChild(index) : LeftChild(index);
                Swap(minIndex, index);
                Heapify(minIndex);
            }
            else if (LeftChild(index) != -1)
            {
                if ((values[index].Item1.val <= values[LeftChild(index)].Item1.val))
                {
                    return;
                }

                Swap(LeftChild(index), index);
                Heapify(LeftChild(index));
            }

        }

        public void Swap(int index1, int index2)
        {
            var aux = values[index1];
            values[index1] = values[index2];
            values[index2] = aux;
        }

    }
}
