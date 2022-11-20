using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingaRobottoPrinttheLexicographicallySmallestString
{
    public class Solution
    {
        public string RobotWithString(string s)
        {
            StringBuilder sb = new StringBuilder();

            SortedDictionary<char, LinkedList<int>> charIndexDict = new SortedDictionary<char, LinkedList<int>>();

            for (int i = 0; i < s.Length; i++)
            {
                var charValue = s[i];
                if (!charIndexDict.TryGetValue(charValue, out var list))
                {
                    list = new LinkedList<int>();
                    charIndexDict[charValue] = list;
                }
                list.AddLast(i);
            }

            LinkedList<char> tList = new LinkedList<char>();

             int index = 0;

            while (index < s.Length)
            {
                if (charIndexDict.Count > 0)
                {
                    var kv = charIndexDict.First();

                        if (tList.Count > 0 && kv.Key < tList.Last.Value
                            || tList.Count == 0)
                        {
                            var firstIndex = kv.Value.First.Value;
                            for (; index <= firstIndex; index++)
                            {
                                tList.AddLast(s[index]);
                                var list = charIndexDict[s[index]];
                                list.RemoveFirst();
                                if (list.Count == 0)
                                    charIndexDict.Remove(s[index]);
                            }
                        }
                        sb.Append(tList.Last.Value);
                        tList.RemoveLast();
                }
                else
                {
                    if (tList.Count > 0)
                        sb.Append(tList.Reverse().ToArray());
                    break;
                }
            }

            if (tList.Count > 0)
                sb.Append(tList.Reverse().ToArray());

            return sb.ToString();
        }
    }
}
