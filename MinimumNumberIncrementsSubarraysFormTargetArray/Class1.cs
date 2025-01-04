

using System.Collections.Generic;

namespace MinimumNumberIncrementsSubarraysFormTargetArray;

public class Solution
{
    public int MinNumberOperations(int[] target)
    {
        /// SORTING TARGET AND GENERATING UNIQUE VALUES (DESCENDING ORDER)
        SortedSet<int> sortedUniqueTargetValues = new SortedSet<int>(target, Comparer<int>.Create((a, b) => b - a));

        /// CREATING RANGES (int index1, int index2, int value)
        List<(int index1, int index2, int value)> rangeList = GenerateRangeList(target);

        /// CREATING linkedListListBySortedUniqueTargetValues
        LinkedList<(int index1, int index2, int value)>[] linkedListListBySortedUniqueTargetValues = GeneratelinkedListListBySortedUniqueTargetValues(sortedUniqueTargetValues, rangeList,
            out Dictionary<int, int> sortedUniqueTargetValuesIndexes);

        /// CREATING nodeTargetArray
        LinkedListNode<(int index1, int index2, int value)>[] nodeTargetArray = GenerateNodeTargetArray(target.Length, linkedListListBySortedUniqueTargetValues);

        int result = 0;

        for (int i = 0; i < linkedListListBySortedUniqueTargetValues.Length; i++)
        {
            var list = linkedListListBySortedUniqueTargetValues[i];

            foreach ((int index1l, int index2l, int valuel) in list)
            {
                int nextValue = 0;
                (int index1, int index2, int value) = (index1l, index2l, valuel);

                int index1Less1 = index1 - 1;
                if (index1Less1 > -1)
                {
                    var indexless1Node = nodeTargetArray[index1Less1];
                    nextValue = Math.Max(indexless1Node.Value.value, nextValue);
                }

                int index2Plus1 = index2 + 1;
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
                        index1 = indexless1Node.Value.index1;
                        indexless1Node.List.Remove(indexless1Node);
                    }
                }

                if (index2Plus1 < target.Length)
                {
                    var index2Plus1Node = nodeTargetArray[index2Plus1];
                    if (index2Plus1Node.Value.value == nextValue)
                    {
                        index2 = index2Plus1Node.Value.index2;
                        index2Plus1Node.List.Remove(index2Plus1Node);
                    }
                }

                if (nextValue != 0)
                {
                    var newNode = linkedListListBySortedUniqueTargetValues[sortedUniqueTargetValuesIndexes[nextValue]].AddLast((index1, index2, nextValue));
                    nodeTargetArray[index1] = newNode;
                    nodeTargetArray[index2] = newNode;
                }

                result += value - nextValue ;

            }
        }

        return result;
    }

    private LinkedListNode<(int index1, int index2, int value)>[] GenerateNodeTargetArray(int targetLenght, LinkedList<(int index1, int index2, int value)>[] linkedListListBySortedUniqueTargetValues)
    {
        LinkedListNode<(int index1, int index2, int value)>[] result = new LinkedListNode<(int index1, int index2, int value)>[targetLenght];

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

    private LinkedList<(int index1, int index2, int value)>[] GeneratelinkedListListBySortedUniqueTargetValues(SortedSet<int> sortedUniqueTargetValues , List<(int index1, int index2, int value)> rangeList
        , out Dictionary<int, int> sortedUniqueTargetValuesIndexes)
    {
        LinkedList<(int index1, int index2, int value)>[] result = new LinkedList<(int index1, int index2, int value)>[sortedUniqueTargetValues.Count];
        sortedUniqueTargetValuesIndexes = new Dictionary<int, int>();
        int i = 0;
        foreach (var sortedUniqueTargetValue in sortedUniqueTargetValues)
        {
            sortedUniqueTargetValuesIndexes[sortedUniqueTargetValue] = i;
            result[i++] = new LinkedList<(int index1, int index2, int value)>();
        }

        foreach ((int index1, int index2, int value) in rangeList)
            result[sortedUniqueTargetValuesIndexes[value]].AddLast(( index1,  index2, value));

        return result;
    }

    private List<(int index1, int index2, int value)> GenerateRangeList(int[] target)
    {
        List<(int index1, int index2, int value)> result = new();

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
            result.Add((i, lastIndexDifferent - 1, target[i]));
            i = lastIndexDifferent - 1;
        }

        return result;
    }
}
