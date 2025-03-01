

using System.Collections.Generic;

namespace MinimumNumberIncrementsSubarraysFormTargetArray;

public class Solution
{
    public int MinNumberOperations(int[] target)
    {
        /// SORTING TARGET AND GENERATING UNIQUE VALUES (DESCENDING ORDER)
        SortedSet<int> sortedUniqueTargetValues = new SortedSet<int>(target, Comparer<int>.Create((a, b) => b - a));

        /// CREATING RANGES (int index1, int index2, int value)
        List<Info> rangeList = GenerateRangeList(target);

        /// CREATING linkedListListBySortedUniqueTargetValues
        LinkedList<Info>[] linkedListListBySortedUniqueTargetValues = GeneratelinkedListListBySortedUniqueTargetValues(sortedUniqueTargetValues, rangeList,
            out Dictionary<int, int> sortedUniqueTargetValuesIndexes);

        /// CREATING nodeTargetArray
        LinkedListNode<Info>[] nodeTargetArray = GenerateNodeTargetArray(target.Length, linkedListListBySortedUniqueTargetValues);

        int result = 0;

        for (int i = 0; i < linkedListListBySortedUniqueTargetValues.Length; i++)
        {
            var list = linkedListListBySortedUniqueTargetValues[i];

            foreach (Info info in list)
            {
                int nextValue = 0;

                int index1Less1 = info.index1 - 1;
                if (index1Less1 > -1)
                {
                    var indexless1Node = nodeTargetArray[index1Less1];
                    nextValue = Math.Max(indexless1Node.Value.value, nextValue);
                }

                int index2Plus1 = info.index2 + 1;
                if (index2Plus1 < target.Length)
                {
                    var index2Plus1Node = nodeTargetArray[index2Plus1];
                    nextValue = Math.Max(index2Plus1Node.Value.value, nextValue);
                }

                /// UPDATE NEXT LOWER LEVEL BASED ON THIS LIST ELEMENT
                /// OR CREATE NEW RANGES BY MERGING THE (int index1, int index2, int value) WITH THEM

                if (index1Less1 > -1)
                {
                    var indexless1Node = nodeTargetArray[index1Less1];
                    if (indexless1Node.Value.value == nextValue)
                    {
                        info.index1 = indexless1Node.Value.index1;
                        indexless1Node.List.Remove(indexless1Node);
                    }
                }

                if (index2Plus1 < target.Length)
                {
                    var index2Plus1Node = nodeTargetArray[index2Plus1];
                    if (index2Plus1Node.Value.value == nextValue)
                    {
                        info.index2 = index2Plus1Node.Value.index2;
                        index2Plus1Node.List.Remove(index2Plus1Node);
                    }
                }

                result += info.value - nextValue;

                if (nextValue != 0)
                {
                    info.value = nextValue;
                    var newNode = linkedListListBySortedUniqueTargetValues[sortedUniqueTargetValuesIndexes[nextValue]].AddLast(info);
                    nodeTargetArray[info.index1] = newNode;
                    nodeTargetArray[info.index2] = newNode;
                }
            }
        }

        return result;
    }

    private LinkedListNode<Info>[] GenerateNodeTargetArray(int targetLenght, LinkedList<Info>[] linkedListListBySortedUniqueTargetValues)
    {
        LinkedListNode<Info>[] result = new LinkedListNode<Info>[targetLenght];

        foreach (var list in linkedListListBySortedUniqueTargetValues)
        {
            var node = list.First;
            while(node!= null)
            {
                result[node.Value.index1] = node;
                result[node.Value.index2] = node;
                node = node.Next;
            }
        }

        return result;
    }

    private LinkedList<Info>[] GeneratelinkedListListBySortedUniqueTargetValues(SortedSet<int> sortedUniqueTargetValues , List<Info> rangeList
        , out Dictionary<int, int> sortedUniqueTargetValuesIndexes)
    {
        LinkedList<Info>[] result = new LinkedList<Info>[sortedUniqueTargetValues.Count];
        sortedUniqueTargetValuesIndexes = new Dictionary<int, int>();
        int i = 0;
        foreach (var sortedUniqueTargetValue in sortedUniqueTargetValues)
        {
            sortedUniqueTargetValuesIndexes[sortedUniqueTargetValue] = i;
            result[i++] = new LinkedList<Info>();
        }

        foreach (Info info in rangeList)
            result[sortedUniqueTargetValuesIndexes[info.value]].AddLast(info);

        return result;
    }

    private List<Info> GenerateRangeList(int[] target)
    {
        List<Info> result = new();

        for (int i = 0; i < target.Length; i++)
        {
            var lastIndexDifferent = i + 1;
            for (; lastIndexDifferent < target.Length;)
            {
                if (target[lastIndexDifferent] == target[i])
                {
                    lastIndexDifferent++;
                }
                else
                    break;
            }
            result.Add(new Info { index1 = i, index2 = lastIndexDifferent - 1, value = target[i] });
            i = lastIndexDifferent - 1;
        }

        return result;
    }

    private class Info
    {
        public int index1;
        public int index2;
        public int value;
    }
}
