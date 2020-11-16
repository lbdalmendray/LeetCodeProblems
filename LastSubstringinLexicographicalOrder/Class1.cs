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

            if (value == 'a')
                return s;

            var indexesArray = indexes.ToArray();

            LinkedList<int[]> list1 = new LinkedList<int[]>();

            for (int i = 0; i < indexesArray.Length ; i++)
            {
                int j = indexesArray[i] + 1;
                for (; j < s.Length; j++)
                {
                    if ( s[j] != s[indexesArray[i]])
                    {
                        j--;
                        break;
                    }
                }
                if (j == s.Length)
                    j--;
                list1.AddLast(new int[] { indexesArray[i], j });
                i += j - indexesArray[i];
            }

            int max = list1.Max(e => e[1] - e[0]);
            ;

            //LinkedList<int[]> list = new LinkedList<int[]>(indexes.Select(e => new int[] { e, e }));
            LinkedList<int[]> list = new LinkedList<int[]>(list1.Where(e => e[1] - e[0] == max));

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
