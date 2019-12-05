using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextJustification
{
    public class Solution
    {
        public IList<string> FullJustify(string[] words, int maxWidth)
        {
            LinkedList<int[]> wordsLines = new LinkedList<int[]>();

            int sum = words[0].Length;
            wordsLines.AddLast(new int[2]);

            for (int i = 1; i < words.Length; i++)
            {
                if (sum + words[i].Length + 1 <= maxWidth)
                {
                    sum += words[i].Length + 1;
                    wordsLines.Last()[1] = i;
                }
                else
                {
                    sum = words[i].Length;
                    wordsLines.AddLast(new int[] { i, i });
                }
            }

            var wordsLinesArray = wordsLines.ToArray();
            int lengthLess1 = wordsLinesArray.Length - 1;
            LinkedList<LinkedList<char>> result = new LinkedList<LinkedList<char>>();
            
            for (int i = 0; i < lengthLess1 ; i++)
            {
                result.AddLast(GetString(wordsLinesArray[i], words, maxWidth));
            }

            result.AddLast(GetStringLast(wordsLinesArray[wordsLinesArray.Length-1],words,maxWidth));

            return result.Select(e => new string(e.ToArray())).ToList();
        }

        private LinkedList<char> GetStringLast(int[] firstLast, string[] words, int maxWidth)
        {
            int sumLength = 0;
            for (int i = firstLast[0]; i <= firstLast[1]; i++)
            {
                sumLength += words[i].Length;
            }
            sumLength += firstLast[1] - firstLast[0];

            int diff = maxWidth - sumLength;

            LinkedList<char> result = new LinkedList<char>();
            for (int i = firstLast[0]; i <= firstLast[1]; i++)
            {
                if (i > firstLast[0])
                    result.AddLast(' ');
                for (int j = 0; j < words[i].Length; j++)
                {
                    result.AddLast(words[i][j]);
                }
            }

            for (int i = 0; i < diff; i++)
            {
                result.AddLast(' ');
            }

            return result;
        }

        private LinkedList<char> GetString(int[] firstLast, string[] words, int maxWidth)
        {
            if ( firstLast[0] == firstLast[1])
            {
                LinkedList<char> result2 = new LinkedList<char>();
                for (int i = 0; i < words[firstLast[0]].Length; i++)
                {
                    result2.AddLast(words[firstLast[0]][i]);
                }
                while(result2.Count < maxWidth)
                {
                    result2.AddLast(' ');
                }
                return result2;
            }

            int sumLength = 0;
            for (int i = firstLast[0]; i <= firstLast[1]; i++)
            {
                sumLength += words[i].Length;
            }

            int difference = maxWidth - sumLength;

            int wordsCountLessOne = (firstLast[1] - firstLast[0]);

            int emptyMinLength = difference / wordsCountLessOne;

            int emptyResLength = difference % wordsCountLessOne;

            LinkedList<char> result = new LinkedList<char>();
            LinkedList<LinkedListNode<char>> nodes = new LinkedList<LinkedListNode<char>>();

            for (int i = firstLast[0]; i <= firstLast[1]; i++)
            {
                if (i > firstLast[0])
                    for (int j = 0; j < emptyMinLength; j++)
                    {
                        result.AddLast(' ');
                    }

                var node = result.AddLast(words[i][0]);
                nodes.AddLast(node);
                for (int j = 1; j < words[i].Length; j++)
                {
                    result.AddLast(words[i][j]);
                }
                
            }

            foreach (var node in nodes.Skip(1).Take(emptyResLength))
            {
                result.AddBefore(node, ' ');
            }

            return result;
        }
    }
}
