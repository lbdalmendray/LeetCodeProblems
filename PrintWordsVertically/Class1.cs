using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintWordsVertically
{
    public class Solution
    {
        public IList<string> PrintVertically(string s)
        {
            var words = s.Split(' ');
            int maxLength = words.Max(e => e.Length);
            int[] maxWordLengthAfter = new int[words.Length];
            maxWordLengthAfter[maxWordLengthAfter.Length - 1] = words[maxWordLengthAfter.Length - 1].Length;
            for (int i = maxWordLengthAfter.Length - 2 ; i >= 0 ; i--)
            {
                maxWordLengthAfter[i] = Math.Max(maxWordLengthAfter[i + 1], words[i].Length);
            }

            LinkedList<LinkedList<char>> rows = new LinkedList<LinkedList<char>>();
            for (int i = 0; i < maxLength; i++)
            {
                LinkedList<char> currentList = new LinkedList<char>();
                for (int j = 0; j < words.Length; j++)
                {
                    var word = words[j];
                    if (i < word.Length)
                        currentList.AddLast(word[i]);
                    else if (i < maxWordLengthAfter[j])
                    {
                        currentList.AddLast(' ');
                    }
                    else
                        break;
                }
                rows.AddLast(currentList);
            }

            return rows.Select(e => new string(e.ToArray())).ToList();
        }
    }

}
