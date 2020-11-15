using System;                        
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ShortestWordDistanceII
{
    public class WordDistance
    {
        readonly Dictionary<(int, int), int> distances;
        readonly Dictionary<string, int> wordNumbers;
        readonly Dictionary<int, LinkedList<int>> lists = new Dictionary<int, LinkedList<int>>();

        public WordDistance(string[] words)
        {
            wordNumbers = new Dictionary<string, int>(words.Length);
            
            int number = 0;
            for (int i = 0; i < words.Length; i++)
            {
                int cKey = 0;
                if (!wordNumbers.TryGetValue(words[i], out cKey))
                {
                    wordNumbers[words[i]] = number;
                    cKey = number;
                    number++;
                }
            }

            distances = new Dictionary<(int, int), int>(wordNumbers.Count * (wordNumbers.Count - 1) / 2);

            var wordKeys = words.Select(e => wordNumbers[e]).ToArray();
            LinkedList<(int,int)> wordKeysAux = new LinkedList<(int,int)>();

            for (int i = 0; i < wordKeys.Length; i++)
            {
                wordKeysAux.AddLast((wordKeys[i],i));
                int j = i + 1;
                for (; j < wordKeys.Length; j++)
                {
                    if (wordKeys[j] != wordKeys[i])
                    {
                        if (i != j - 1)
                            wordKeysAux.AddLast((wordKeys[j - 1],j-1));
                        i = j - 1;
                        break;
                    }
                }

                if (j == words.Length && i != j - 1)
                {
                    wordKeysAux.AddLast((wordKeys[j - 1],j-1));
                    break;
                }
            }

            var wordKeysArray = wordKeysAux.ToArray();

            foreach (var key in wordNumbers.Values)
            {
                lists[key] = new LinkedList<int>();
            }

            for (int i = 0; i < wordKeysArray.Length; i++)
            {
                lists[wordKeysArray[i].Item1].AddLast(wordKeysArray[i].Item2);
            }
        }

        #region Version1

        /*
        public WordDistance(string[] words)
        {
            wordNumbers = new Dictionary<string, int>(words.Length);

            int number = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (!wordNumbers.ContainsKey(words[i]))
                {
                    wordNumbers[words[i]] = number;
                    number++;
                }
            }

            distances = new Dictionary<(int, int), int>(wordNumbers.Count * (wordNumbers.Count - 1) / 2);

            var wordKeys = words.Select(e => wordNumbers[e]).ToArray();

            for (int i = 0; i < wordKeys.Length - 1; i++)
            {
                for (int j = i + 1; j < wordKeys.Length; j++)
                {
                    if (wordKeys[i] == wordKeys[j])
                        continue;
                    TryAddDistance(wordKeys[i], wordKeys[j], i, j);
                }
            }
        }

        */

        #endregion

        private int TryAddDistance(int key1, int key2 )
        {
            int keyMin = Math.Min(key1, key2);
            int keyMax = Math.Max(key1, key2);

            if (distances.TryGetValue((keyMin, keyMax), out int value))
            {
                return value;
            }
            int result = int.MaxValue;
            var list1 = lists[key1];
            var list2 = lists[key2];

            var node1 = list1.First;
            var node2 = list2.First;

            LinkedListNode<int> nodeMin;
            LinkedListNode<int> nodeMax;

            if ( node1.Value > node2.Value)
            {
                nodeMin = node2;
                nodeMax = node1;
            }
            else
            {
                nodeMin = node1;
                nodeMax = node2;
            }

            while (nodeMax != null)
            {
                int cDistance = nodeMax.Value - nodeMin.Value;
                if (cDistance < result)
                    result = cDistance;
                nodeMin = nodeMin.Next;
                if (nodeMin == null)
                    break;
                if ( nodeMin.Value > nodeMax.Value)
                {
                    var aux = nodeMin;
                    nodeMin = nodeMax;
                    nodeMax = aux;
                }
            }

            distances [(keyMin, keyMax)] = result;

            return result;
        }

        /*
         
        private void TryAddDistance(int key1, int key2, int distance)
        {
            int keyMin = Math.Min(key1, key2);
            int keyMax = Math.Max(key1, key2);
            
            if (distances.TryGetValue((keyMin, keyMax), out int value))
            {
                if (value <= distance)
                    return;
            }

            distances[(keyMin, keyMax)] = distance;
        }

        */

        /*
         
        private void TryAddDistance(int key1, int key2, int i, int j)
        {
            int keyMin = Math.Min(key1, key2);
            int keyMax = Math.Max(key1, key2);
            int distance = j - i;
            if ( distances.TryGetValue((keyMin,keyMax), out int value))
            {
                if (value <= distance)
                    return;
            }

            distances[(keyMin, keyMax)] = distance;
        }

        */

        public int Shortest(string word1, string word2)
        {
            int key1 = wordNumbers[word1];
            int key2 = wordNumbers[word2];
            int keyMin = Math.Min(key1, key2);
            int keyMax = Math.Max(key1, key2);
            return TryAddDistance(key1, key2);
        }

        /*

        public int Shortest(string word1, string word2)
        {
            int key1 = wordNumbers[word1];
            int key2 = wordNumbers[word2];
            int keyMin = Math.Min(key1, key2);
            int keyMax = Math.Max(key1, key2);
            return distances[(keyMin, keyMax)];
        }

        */
    }

    /**
     * Your WordDistance object will be instantiated and called as such:
     * WordDistance obj = new WordDistance(words);
     * int param_1 = obj.Shortest(word1,word2);
     */
}
