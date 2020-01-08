using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordBreakII
{
    public class Solution
    {
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            MyContainer container = new MyContainer(wordDict);
            Info[] infos = new Info[s.Length + 1];
            infos[s.Length] = new Info { Solvable = true};

            Info result = WordBreak(0, infos, s, container);
            if (result.Solvable)
            {
                var resultList = new LinkedList<string>();
                result.GetEnumerable(resultList, new LinkedList<int[]>(), s);
                return resultList.ToList();
            }
            return new List<string>();
        }

        private Info WordBreak(int index, Info[] infos, string s, MyContainer container)
        {
            if (infos[index] != null)
                return infos[index];

            var info = infos[index] = new Info();
            
            foreach (var lastedPosition in container.GetValidWordPositions(s,index))
            {
                var posibleChild = WordBreak(lastedPosition + 1, infos, s, container);
                if (!posibleChild.Solvable)
                    continue;

                var infoNode = new InfoNode();
                infoNode.indexes[0] = index;
                infoNode.indexes[1] = lastedPosition;

                infoNode.Children = posibleChild; 

                info.Result.AddLast(infoNode);
            }

            info.Solvable = info.Result.Count > 0;

            return info;
        }
    }

    public class MyContainer
    {
        IMyContainerNode firstNode;
        public MyContainer(IList<string> wordDict)
        {
            try
            {
                firstNode = new MyContArrayNode();
                foreach (var item in wordDict)
                {
                    firstNode.Add(item, 0);
                }

            }
            catch (System.OutOfMemoryException e)
            {
                firstNode = new MyContLinkedNode();
                foreach (var item in wordDict)
                {
                    firstNode.Add(item, 0);
                }
            }
        }

        public LinkedList<int> GetValidWordPositions(string stringValue, int firstIndex)
        {
            LinkedList<int> result = new LinkedList<int>();
            var node = firstNode;

            while (firstIndex < stringValue.Length && node != null)
            {
                if (node.HasChar(stringValue[firstIndex], out node))
                {
                    if (node.IsWord)
                        result.AddLast(firstIndex);
                }
                firstIndex++;
            }

            return result;
        }

        public static int GetValue(char character)
        {
            if (character < 'a')
                return character - 'A';
            return 26 + character - 'a';
        }
    }

    public interface IMyContainerNode
    {
        bool IsWord { get; }
        bool HasChar(char charValue, out IMyContainerNode node);

        void Add(string stringValue, int index);
    }

    public class MyContArrayNode : IMyContainerNode
    {
        public MyContArrayNode[] charValues = new MyContArrayNode[52];
        public bool IsWord { get ; protected set ; }

        public void Add(string stringValue, int index)
        {
            if (index == stringValue.Length)
                IsWord = true;
            else
            {
                if( charValues[MyContainer.GetValue( stringValue[index])] == null)
                {
                    charValues[MyContainer.GetValue(stringValue[index])] = new MyContArrayNode();
                }
                charValues[MyContainer.GetValue(stringValue[index])].Add(stringValue, index + 1);
            }
        }

        public bool HasChar(char charValue, out IMyContainerNode node)
        {
            node = charValues[MyContainer.GetValue(charValue)];
            return node != null;
        }
    }

    public class MyContLinkedNode : IMyContainerNode
    {
        public LinkedList<MyContLinkedNode> charValues = new LinkedList<MyContLinkedNode>();
        public bool IsWord { get; protected set; }
        public char CharValue { get; protected set; }
        public void Add(string stringValue, int index)
        {
            if (index == stringValue.Length)
                IsWord = true;
            else
            {
                if (!HasChar(stringValue[index], out IMyContainerNode firstNode))
                {
                    var node = new MyContLinkedNode { CharValue = stringValue[index] };
                    charValues.AddLast(node);
                    node.Add(stringValue, index + 1);
                }
                else
                {
                    firstNode.Add(stringValue, index + 1);
                }
            }
        }

        public bool HasChar(char charValue, out IMyContainerNode node )
        {
            node = charValues.FirstOrDefault(e => e.CharValue == charValue);
            return node != null;
        }
    }


    public class Info
    {
        public LinkedList<InfoNode> Result = new LinkedList<InfoNode>();

        public bool Solvable { get; internal set; }

        public void GetEnumerable(LinkedList<string> result , LinkedList<int[]> indexes, string stringValue)
        {
            foreach (var infoNode in Result)
            {
                indexes.AddLast(infoNode.indexes);
                if( infoNode.Children.Result.Count != 0)
                {
                    infoNode.Children.GetEnumerable(result, indexes, stringValue);
                }
                else
                {
                    result.AddLast(GetStringFrom(indexes, stringValue));
                }
                indexes.RemoveLast();
            }
        }

        private string GetStringFrom(LinkedList<int[]> indexes, string stringValue)
        {
            LinkedList<char> chars = new LinkedList<char>();
            AddAllCharsFromTo(stringValue, indexes.First.Value[0], indexes.First.Value[1], chars);
            foreach (var item in indexes.Skip(1))
            {
                chars.AddLast(' ');
                AddAllCharsFromTo(stringValue, item[0], item[1], chars);
            }

            return new string(chars.ToArray());
        }

        private void AddAllCharsFromTo(string stringValue, int v1, int v2, LinkedList<char> charValues)
        {
            for (int i = v1; i <= v2; i++)
            {
                charValues.AddLast(stringValue[i]);
            }
        }
    }

    public class InfoNode
    {
        public int[] indexes { get; set; } = new int[2];
        public Info Children { get; set; }
    }
}
