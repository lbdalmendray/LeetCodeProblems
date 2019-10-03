using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace WordLadderII
{
    public class Solution
    {
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            var allWords = Enumerable.Concat(new string[] { beginWord }, wordList);
            WordGroupGraph wordGroupGraph = new WordGroupGraph(allWords, endWord);
            return wordGroupGraph.FindLadders();
        }        
    }

    public class WordGroup
    {
        public LinkedList<int> WordIndexes { get; private set; }
        public int IndexGroup { get; set; }
        public int EndWordIndex { get; private set; }
        //public int WordDiffIndex { get; private set; }

        bool? isendWordGroup;
        public bool isEndWordGroup
        {
            get
            {
                if (isendWordGroup.HasValue)
                {
                    return isendWordGroup.Value;
                }

                isendWordGroup = WordIndexes.Any(index => index == EndWordIndex);
                return isendWordGroup.Value;
            }
        }

        bool? isbeginWordGroup;
        public bool isBeginWordGroup
        {
            get
            {
                if (isbeginWordGroup.HasValue)
                {
                    return isbeginWordGroup.Value;
                }

                isbeginWordGroup = WordIndexes.Any(index => index == 0);
                return isbeginWordGroup.Value;
            }
        }


        public WordGroup(/*int wordDiffIndex,*/ int endWordIndex)
        {
            EndWordIndex = endWordIndex;
            //WordDiffIndex = wordDiffIndex;
            WordIndexes = new LinkedList<int>();
        }
    }

    public class WordGroupGraph
    {
        ulong Base = 26;
        ulong[] Powers;

        public int endWordIndex;
        public string[] Words { get; private set; }
        public LinkedList<WordGroup>[] GroupsByWordIndex { get; private set; }
        public WordGroup[] AllGroups { get; private set; }
        public WordGroupGraph(IEnumerable<string> words, string endWord)
        {
            Words = words.ToArray();
            CreateGroups(endWord);
        }

        public IList<IList<string>> FindLadders()
        {
            if (endWordIndex == -1)
                return new List<IList<string>>() as IList<IList<string>>;

            var relations = ReduceBFS();
            relations = GetRelationsInverted(relations);

            IList<IList<string>> results = GetAllPathsByRelations(endWordIndex, relations);

            return results;
        }

        private IList<IList<string>> GetAllPathsByRelations(int endWordIndex , LinkedList<int>[] relations)
        {
            var results = DFSByRelations(endWordIndex, 0, relations, new LinkedList<LinkedList<int>>() , new LinkedList<int>()) ;
            return results.Select(e => e.Select(i=>Words[i]).ToList() as IList<string>).ToList() as IList<IList<string>>;
        }

        private LinkedList<LinkedList<int>> DFSByRelations(int firstIndex, int endIndex , LinkedList<int>[] relations, LinkedList<LinkedList<int>> results, LinkedList<int> currentPath)
        {
            currentPath.AddFirst(firstIndex);

            if( firstIndex == endIndex)
            {
                results.AddLast(ClonePathInt(currentPath));

            }
            else
            {
                if (relations[firstIndex] != null)
                    foreach (var index in relations[firstIndex])
                    {
                        DFSByRelations(index, endIndex, relations, results, currentPath);
                    }
            }       

            currentPath.RemoveFirst();

            return results;
        }

        private LinkedList<int>[] GetRelationsInverted(LinkedList<int>[] relations)
        {
            LinkedList<int>[] results = new LinkedList<int>[relations.Length];

            for (int i = 0; i < relations.Length; i++)
            {
                if(relations[i]!=null)
                    foreach (var index in relations[i])
                    {
                        if (results[index] == null)
                            results[index] = new LinkedList<int>();
                        results[index].AddLast(i);
                    }
            }

            return results;
        }

        private LinkedList<int>[] ReduceBFS()
        {
            var relations = new LinkedList<int>[Words.Length];
            int[] value = Enumerable.Repeat(int.MaxValue,Words.Length).ToArray();

            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[] { 0, 0 , -1 });

            while(queue.Count != 0 )
            {              
                var first = queue.Dequeue() ;
                if (first[1] > value[endWordIndex])
                    return relations;

                if (value[first[0]] < first[1])
                    continue;

                if (first[2] != -1)
                {
                    if (relations[first[2]] == null)
                        relations[first[2]] = new LinkedList<int>();
                    relations[first[2]].AddLast(first[0]);
                }

                if (value[first[0]] == first[1])
                    continue;

                value[first[0]] = first[1];
                
                var newValue = first[1] + 1;
                foreach (var group in GroupsByWordIndex[first[0]])
                {
                    foreach (var wordIndex in group.WordIndexes)
                    {
                        queue.Enqueue(new int[] { wordIndex, newValue, first[0] });
                    }
                }
            }

            return relations;
        }


        private LinkedList<int> ClonePathInt(LinkedList<int> currentPath)
        {
            LinkedList<int> result = new LinkedList<int>();

            foreach (var item in currentPath)
            {
                result.AddLast(item);
            }

            return result; 
        }
        
        private void CreateGroups(string endWord)
        {
            ///
            Powers = new ulong[Words[0].Length];
            Powers[0] = 1;
            for (int i = 1; i < Powers.Length; i++)
            {
                Powers[i] = Powers[i - 1] * Base;
            }

            var wordsValues = GetWordsValues();
            wordsValues = EliminateWordRepetitions(wordsValues);

            GroupsByWordIndex = new LinkedList<WordGroup>[Words.Length];
            for (int i = 0; i < GroupsByWordIndex.Length; i++)
            {
                GroupsByWordIndex[i] = new LinkedList<WordGroup>();
            }

            LinkedList<WordGroup> allGroupsLinkedList = new LinkedList<WordGroup>();

            var endWordValue = GetWordValue(endWord);
            endWordIndex = -1;
            for (int i = 0; i < wordsValues.Length; i++)
            {
                if (wordsValues[i] == endWordValue)
                {
                    endWordIndex = i;
                    break;
                }
            }
            if (endWordIndex == -1)
                return;

            int groupIndex = 0;

            for (int i = 0; i < Words[0].Length; i++)
            {
                var groups = CreateGroupsByIndex(i, wordsValues, endWordIndex);
                foreach (var group in groups)
                {
                    allGroupsLinkedList.AddLast(group);
                    group.IndexGroup = groupIndex;
                    groupIndex++;
                }
            }

            AllGroups = allGroupsLinkedList.ToArray();
        }

        private ulong[] EliminateWordRepetitions(ulong[] wordsValues)
        {
            ulong beginWordValue = wordsValues[0];
            var indexes = Enumerable.Range(0, wordsValues.Length).ToArray();
            LinkedList<ulong> results = new LinkedList<ulong>();
            LinkedList<string> words = new LinkedList<string>();
            Array.Sort(wordsValues, indexes);

            for (int i = 0; i < wordsValues.Length; i++)
            {
                if (beginWordValue == wordsValues[i])
                {
                    results.AddFirst(wordsValues[i]);
                    words.AddFirst(Words[indexes[i]]);
                }
                else
                {
                    results.AddLast(wordsValues[i]);
                    words.AddLast(Words[indexes[i]]);
                }
                int j = i + 1;
                for (; j < wordsValues.Length; j++)
                {
                    if (wordsValues[i] != wordsValues[j])
                        break;
                }
                i = j - 1;
            }

            Words = words.ToArray();
            return results.ToArray();
        }

        private LinkedList<WordGroup> CreateGroupsByIndex(int index, ulong[] wordsValues, int endWordIndex)
        {
            ulong[] wordValuesByIndex = new ulong[wordsValues.Length];
            int[] indexes = new int[wordsValues.Length];
            Array.Copy(wordsValues, 0, wordValuesByIndex, 0, wordsValues.Length);
            ulong aValue = (ulong)'a';

            for (int i = 0; i < wordsValues.Length; i++)
            {
                wordValuesByIndex[i] -= (((ulong)Words[i][index]) - aValue) * Powers[index];
                indexes[i] = i;
            }

            Array.Sort(wordValuesByIndex, indexes);
            LinkedList<WordGroup> result = new LinkedList<WordGroup>();

            for (int i = 0; i < wordsValues.Length; i++)
            {
                var newGroup = new WordGroup(/*index,*/ endWordIndex);
                result.AddLast(newGroup);
                newGroup.WordIndexes.AddLast(indexes[i]);
                GroupsByWordIndex[indexes[i]].AddLast(newGroup);

                int j = i + 1;
                for (; j < wordsValues.Length; j++)
                {
                    if (wordValuesByIndex[i] != wordValuesByIndex[j])
                    {
                        break;
                    }
                    newGroup.WordIndexes.AddLast(indexes[j]);
                    GroupsByWordIndex[indexes[j]].AddLast(newGroup);
                }

                i = j - 1;
            }

            return result;
        }

        private ulong[] GetWordsValues()
        {
            ulong[] results = new ulong[Words.Length];
            for (int i = 0; i < Words.Length; i++)
            {
                results[i] = GetWordValue(Words[i]);
            }
            return results;
        }

        private ulong GetWordValue(string word)
        {

            ulong aValue = (ulong)'a';
            ulong result = 0;
            for (int i = 0; i < word.Length; i++)
            {
                result += (((ulong)word[i]) - aValue) * Powers[i];
            }

            return result;
        }
    }
}
