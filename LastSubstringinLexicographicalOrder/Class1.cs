using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastSubstringinLexicographicalOrder
{
    public class Solution
    {
        public string LastSubstring(string s)
        {
            int value = int.MinValue;
            LinkedList<int> indexes = null; 

            for (int i = 0; i < s.Length; i++)
            {
                if( s[i] > value)
                {
                    indexes = new LinkedList<int>();
                    indexes.AddLast(i);
                    value = s[i];
                }
                else if ( s[i] == value)
                    indexes.AddLast(i);
            }

            LinkedList<int[]> list = new LinkedList<int[]>(indexes.Select(e => new int[] { e, e }));

            while(list.Count > 1)
            {
                LinkedList<int[]> cList = null;
                value = int.MinValue;
                foreach (var arr in list)
                {
                    if (arr[1] == s.Length)
                        continue;

                    int i = arr[1];

                    if (s[i] > value)
                    {
                        cList = new LinkedList<int[]>();
                        cList.AddLast(arr);
                        value = s[i];
                        arr[1]++;
                    }
                    else if (s[i] == value)
                    {
                        cList.AddLast(arr);
                        arr[1]++;
                    }
                }
                list = new LinkedList<int[]>(cList);
            }

            return s.Substring(list.First.Value[0]);
        }
    }
}
