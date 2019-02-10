using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReorganizeString
{
    public class Solution
    {
        public string ReorganizeString(string S)
        {

            Dictionary<char, int> dictionary = new Dictionary<char, int>(S.Length);
            for (int i = 0; i < S.Length; i++)
            {
                if (!dictionary.ContainsKey(S[i]))
                {
                    dictionary.Add(S[i], 0);
                }
                dictionary[S[i]]++;
            }

            //var keyValues = dictionary.ToArray();
            //Array.Sort<KeyValuePair<char, int>>(keyValues, new Comparison<KeyValuePair<char, int>>(delegate (KeyValuePair<char, int> kv1, KeyValuePair<char, int> kv2) { return Comparer<int>.Default.Compare(kv1.Value, kv2.Value); }));
            var keyValues = SortKeyValues(dictionary, S.Length);
            LinkedList<char> stringValue = new LinkedList<char>();

            bool rightDir = true;

            for (int i = 1; i <= keyValues[0].Value; i++)
            {
                stringValue.AddLast(keyValues[0].Key);
            }

            for (int i = 1; i < keyValues.Length; i++)
            {
                LinkedListNode<char> node = null;

                if (rightDir)
                {
                    stringValue.AddFirst(keyValues[i].Key);
                    node = stringValue.First.Next;
                }
                else
                {
                    stringValue.AddLast(keyValues[i].Key);
                    node = stringValue.Last.Previous;
                }

                int count = keyValues[i].Value - 1;

                if (rightDir)
                {
                    int j = 1;
                    for (; j <= count; j++)
                    {
                        if (node == null)
                        {
                            break;
                        }

                        node = stringValue.AddAfter(node, keyValues[i].Key).Next;
                    }

                    for (; j <= count; j++)
                    {
                        stringValue.AddLast(keyValues[i].Key);
                    }

                }
                else
                {
                    int j = 1;
                    for (; j <= count; j++)
                    {
                        if (node == null)
                        {
                            break;
                        }

                        node = stringValue.AddBefore(node, keyValues[i].Key).Previous;
                    }

                    for (; j <= count; j++)
                    {
                        stringValue.AddFirst(keyValues[i].Key);
                    }
                }

                rightDir = !rightDir;
            }

            var stringValueArray = stringValue.ToArray();

            for (int i = 0; i < stringValueArray.Length - 1; i++)
            {
                if (stringValueArray[i] == stringValueArray[i + 1])
                    return "";
            }

            return new String(stringValueArray);


        }

        private KeyValuePair<char, int>[] SortKeyValues(Dictionary<char, int> dictionary, int length)
        {
            LinkedList<KeyValuePair<char, int>>[] result = new LinkedList<KeyValuePair<char, int>>[length];

            foreach (var keyValue in dictionary)
            {
                if (result[keyValue.Value-1] == null)
                    result[keyValue.Value-1] = new LinkedList<KeyValuePair<char, int>>();
                result[keyValue.Value-1].AddLast(keyValue);
            }

            KeyValuePair<char, int>[] resultReal = new KeyValuePair<char, int>[dictionary.Keys.Count];

            int index = 0;
            for (int i = 0; i < length; i++)
            {
                if (result[i] != null)
                {
                    foreach (var item in result[i])
                    {
                        resultReal[index++] = item;
                    }
                }
            }

            return resultReal;
                        
        }

        public string ReorganizeStringV2(string S)
        {

            Dictionary<char, int> dictionary = new Dictionary<char, int>(S.Length);
            for (int i = 0; i < S.Length; i++)
            {
                if (!dictionary.ContainsKey(S[i]))
                {
                    dictionary.Add(S[i], 0);
                }
                dictionary[S[i]]++;
            }

            var keyValues = dictionary.ToArray();
            Array.Sort<KeyValuePair<char, int>>(keyValues, new Comparison<KeyValuePair<char, int>>(delegate (KeyValuePair<char, int> kv1, KeyValuePair<char, int> kv2) { return Comparer<int>.Default.Compare(kv1.Value, kv2.Value); }));
            LinkedList<char> stringValue = new LinkedList<char>();

            bool rightDir = true;

            for (int i = 1; i <= keyValues[0].Value; i++)
            {
                stringValue.AddLast(keyValues[0].Key);
            }

            for (int i = 1; i < keyValues.Length; i++)
            {
                LinkedListNode<char> node = null;

                if (rightDir)
                {
                    stringValue.AddFirst(keyValues[i].Key);
                    node = stringValue.First.Next;
                }
                else
                {
                    stringValue.AddLast(keyValues[i].Key);
                    node = stringValue.Last.Previous;
                }

                int count = keyValues[i].Value - 1;

                if (rightDir)
                {
                    int j = 1;
                    for (; j <= count; j++)
                    {
                        if (node == null)
                        {
                            break;
                        }

                        node = stringValue.AddAfter(node, keyValues[i].Key).Next;
                    }

                    for (; j <= count; j++)
                    {
                        stringValue.AddLast(keyValues[i].Key);
                    }

                }
                else
                {
                    int j = 1;
                    for (; j <= count; j++)
                    {
                        if (node == null)
                        {
                            break;
                        }

                        node = stringValue.AddBefore(node, keyValues[i].Key).Previous;
                    }

                    for (; j <= count; j++)
                    {
                        stringValue.AddFirst(keyValues[i].Key);
                    }
                }

                rightDir = !rightDir;
            }

            var stringValueArray = stringValue.ToArray();

            for (int i = 0; i < stringValueArray.Length - 1; i++)
            {
                if (stringValueArray[i] == stringValueArray[i + 1])
                    return "";
            }

            return new String(stringValueArray);


        }
    }
}
