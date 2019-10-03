using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLadderII
{
    public class Solution2
    {
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            if (!wordList.Contains(endWord))
                return (IList<IList<string>>)new List<IList<string>>();

            var infoTree = InfoGraph.GetTreeFrom(beginWord, wordList, endWord, out var endWordIndex, out bool impossibleGetEndWordIndex, out int maxPathValue);

            if (impossibleGetEndWordIndex)
                return (IList<IList<string>>)new List<IList<string>>();


            return infoTree.getAllWordPathFromTo(0/*beginWordIndex*/, endWordIndex, maxPathValue);
        }
    }

    public class InfoGraph
    {
        public string[] Infos { get; private set; }
        LinkedList<int>[] relations;

        public IList<IList<string>> getAllWordPathFromTo(int index1, int index2, int maxPathValue)
        {
            LinkedList<List<int>> result = new LinkedList<List<int>>();
            LinkedList<int> currentList = new LinkedList<int>();
            getAllPathFromTo(index1, index2, currentList, result, new bool[relations.Length], maxPathValue);
            if (result.Count == 0)
                return result.Select(list => list.Select(e => Infos[e]).ToList() as IList<string>).ToList() as IList<IList<string>>;

            var minLength = result.Min(list => list.Count);

            return result.Where(list => list.Count == minLength).Select(list => list.Select(e => Infos[e]).ToList() as IList<string>).ToList() as IList<IList<string>>;
        }

        private void getAllPathFromTo(int index1, int index2, LinkedList<int> currentList, LinkedList<List<int>> result, bool[] selected, int maxPathValue)
        {
            if (currentList.Count > maxPathValue)
                return;

            if (index1 == index2)
            {
                currentList.AddLast(index1);
                result.AddLast(currentList.ToList());
                currentList.RemoveLast();
                return;
            }

            currentList.AddLast(index1);
            selected[index1] = true;
            if (relations[index1] != null)
                foreach (var childIndex in relations[index1])
                {
                    if (!selected[childIndex])
                    {
                        getAllPathFromTo(childIndex, index2, currentList, result, selected, maxPathValue);
                    }
                }

            currentList.RemoveLast();
            selected[index1] = false;
        }

        public static InfoGraph GetTreeFrom(string beginWord, IList<string> wordList, string endWord, out int endWordIndex, out bool impossibleGetEndWordIndex, out int maxPathValue)
        {
            InfoGraph tree = new InfoGraph(beginWord, wordList);
            endWordIndex = 0;
            for (; endWordIndex < tree.Infos.Length; endWordIndex++)
            {
                if (tree.Infos[endWordIndex] == endWord)
                {
                    break;
                }
            }
            if (endWordIndex == tree.Infos.Length)
            {
                impossibleGetEndWordIndex = true;
                maxPathValue = int.MaxValue;
                return null;
            }
            CreateNearByLetterRelations(tree);
            InfoGraph result = GetMinimumPathGraph(tree, 0, endWordIndex, out impossibleGetEndWordIndex, out maxPathValue);
            return result;
        }

        private static InfoGraph GetMinimumPathGraph(InfoGraph graph, int beginWordIndex, int endWordIndex, out bool impossibleGetEndWordIndex, out int maxPathValue)
        {
            impossibleGetEndWordIndex = true;
            maxPathValue = int.MaxValue;

            MyHeap2<int, int[]> heap = new MyHeap2<int, int[]>(graph.Infos.Length);

            InfoGraph graphResult = new InfoGraph(graph.Infos);

            bool[] selected = new bool[graph.Infos.Length];
            int[] pathValues = new int[graph.Infos.Length];

            LinkedList<int[]> queue = new LinkedList<int[]>();

            selected[beginWordIndex] = true;
            queue.AddLast(new int[] { beginWordIndex, -1 });
            bool endWordSelected = false;
            while (queue.Count != 0)
            {
                var first = queue.First;
                queue.RemoveFirst();
                int index = first.Value[0];
                pathValues[index] = 1 + first.Value[1];
                if (index == endWordIndex)
                {
                    endWordSelected = true;
                    impossibleGetEndWordIndex = false;
                    maxPathValue = pathValues[index];
                }
                if (graph.relations[index] != null)
                {
                    if (graphResult.relations[index] == null)
                        graphResult.relations[index] = new LinkedList<int>();
                    foreach (var item in graph.relations[index])
                    {
                        if (endWordSelected)
                        {
                            if (item != endWordIndex)
                            {
                                continue;
                            }
                            else
                            {
                                if (pathValues[index] == pathValues[endWordIndex])
                                {
                                    queue.Clear();
                                    break;
                                }
                            }
                        }
                        if (!selected[item])
                        {
                            selected[item] = true;
                            queue.AddLast(new int[] { item, pathValues[index] });
                        }
                        graphResult.relations[index].AddLast(item);
                    }
                }
            }


            return graphResult;
        }

        private static void CreateNearByLetterRelations(InfoGraph infoTree)
        {
            for (int i = 0; i < infoTree.Infos.Length - 1; i++)
            {
                for (int j = i + 1; j < infoTree.Infos.Length; j++)
                {
                    if (AreNearByLetter(infoTree.Infos[i], infoTree.Infos[j]))
                    {
                        if (infoTree.relations[i] == null)
                        {
                            infoTree.relations[i] = new LinkedList<int>();
                        }
                        infoTree.relations[i].AddLast(j);


                        if (infoTree.relations[j] == null)
                        {
                            infoTree.relations[j] = new LinkedList<int>();
                        }
                        infoTree.relations[j].AddLast(i);

                    }
                }
            }
        }

        public static bool AreNearByLetter(string info1, string info2)
        {
            int differences = 0;

            for (int i = 0; i < info1.Length; i++)
            {
                if (info1[i] != info2[i])
                    differences++;
            }

            return differences == 1;
        }

        public InfoGraph(string beginWord, IList<string> wordList)
        {
            string[] completeWordList = new string[wordList.Count + 1];
            completeWordList[0] = beginWord;
            int i = 1;
            foreach (var word in wordList)
            {
                completeWordList[i] = word;
                i++;
            }

            this.Infos = completeWordList;
            relations = new LinkedList<int>[Infos.Length];

        }

        public InfoGraph(string[] infos)
        {
            this.Infos = infos;
            relations = new LinkedList<int>[Infos.Length];
        }
    }


    public class MyHeap2<TKey, TValue>
    {
        private KeyValuePair<TKey, TValue>[] values;
        public int Length = 0;
        public MyHeap2(KeyValuePair<TKey, TValue>[] values)
        {
            Comparer = Comparer<TKey>.Default;
            this.values = values;
            Length = values.Length;
            BuildHeap();
        }

        public MyHeap2(int maxValuesLength)
        {
            Comparer = Comparer<TKey>.Default;
            this.values = new KeyValuePair<TKey, TValue>[maxValuesLength];
        }

        public void BuildHeap()
        {
            for (int i = LastNonLeaf(); i >= 0; i--)
            {
                Heapify(i);
            }
        }

        public void InsertValue(KeyValuePair<TKey, TValue> valuee)
        {
            values[Length] = valuee;
            Length++;
            int currentIndex = Length - 1;
            var parentIndex = Parent(currentIndex);

            while (parentIndex != -1 && Comparer.Compare(values[parentIndex].Key, values[currentIndex].Key) == 1)
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

        public KeyValuePair<TKey, TValue> Extract_Minimum()
        {
            var result = values[0];
            Swap(0, Length - 1);
            Length--;
            Heapify(0);
            return result;
        }

        public KeyValuePair<TKey, TValue> GetMinimum()
        {
            return values[0];
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
                if (Comparer.Compare(values[index].Key, values[RightChild(index)].Key) <= 0 && Comparer.Compare(values[index].Key, values[LeftChild(index)].Key) <= 0)
                {
                    return;
                }

                int minIndex = Comparer.Compare(values[RightChild(index)].Key, values[LeftChild(index)].Key) <= 0 ? RightChild(index) : LeftChild(index);
                Swap(minIndex, index);
                Heapify(minIndex);
            }
            else if (LeftChild(index) != -1)
            {
                if (Comparer.Compare(values[index].Key, values[LeftChild(index)].Key) <= 0)
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

        public IComparer<TKey> Comparer { get; protected set; }


    }
}
