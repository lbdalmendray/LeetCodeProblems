using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RearrangeWordsinaSentence
{
    public class Solution
    {
        public string ArrangeWords(string text)
        {
           var words =  text.ToLower().Split(' ');
            SortedDictionary<int, LinkedList<string>> dict = new SortedDictionary<int, LinkedList<string>>();

            foreach (var word in words)
            {
                if (dict.TryGetValue(word.Length, out var list))
                {
                    list.AddLast(word);
                }
                else
                {
                    list = new LinkedList<string>();
                    list.AddLast(word);
                    dict.Add(word.Length, list);
                }
            }

            bool first = true;
            StringBuilder result = new StringBuilder();
            foreach (var keyValue in dict)
            {
                var list = keyValue.Value;
                foreach (var word in list)
                {
                    if (first)
                    {
                        first = false;

                        result.Append(Char.ToUpper(word[0]));
                        result.Append(new string(word.Skip(1).ToArray()));
                    }
                    else
                    {
                        result.Append(' ');
                        result.Append(word);
                    }
                }
            }

            return result.ToString();
        }
    }
}
