using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsomorphicStrings
{
    public class Solution
    {
        public bool IsIsomorphic(string s, string t)
        {
            if (s == null || s.Length == 0)
                return true;

            Dictionary<char, char> dict1 = new Dictionary<char, char>(s.Length);
            Dictionary<char, char> dict2 = new Dictionary<char, char>(s.Length);

            for (int i = 0; i < s.Length; i++)
            {
                if( dict1.TryGetValue(s[i], out var tvalue))
                {
                    if (tvalue != t[i])
                        return false;
                }
                else
                {
                    dict1.Add(s[i], t[i]);
                }

                if (dict2.TryGetValue(t[i], out var svalue))
                {
                    if (svalue != s[i])
                        return false;
                }
                else
                {
                    dict2.Add(t[i], s[i]);
                }
            }

            return true;
        }
    }
}
