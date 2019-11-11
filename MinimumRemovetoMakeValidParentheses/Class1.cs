using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumRemovetoMakeValidParentheses
{
    public class Solution
    {
        public string MinRemoveToMakeValid(string s)
        {
            LinkedList<int> result = new LinkedList<int>();

            LinkedList<int> opened = new LinkedList<int>();

            for (int i = 0; i < s.Length; i++)
            {
                if(s[i]== '(')
                {
                    opened.AddLast(i);
                }
                else if(s[i]==')')
                {
                    if( opened.Count > 0 )
                    {
                        opened.RemoveLast();
                    }
                    else
                    {
                        result.AddLast(i);
                    }
                }
            }

            bool[] selected = new bool[s.Length];
            foreach (var item in result)
            {
                selected[item] = true;
            }

            foreach (var item in opened)
            {
                selected[item] = true;
            }

            LinkedList<char> resultString = new LinkedList<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if( !selected[i])
                {
                    resultString.AddLast(s[i]);
                }
            }

            return new string(resultString.ToArray());
                
        }
    }
}
