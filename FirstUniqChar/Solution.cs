using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstUniqChar
{
    public class Solution
    {
        public int FirstUniqChar(string s)
        {
            bool[] all = new bool[s.Length];
            Dictionary<char, int> dict = new Dictionary<char, int>(s.Length);
            for (int i = 0; i < s.Length; i++)
            {
                if (!dict.ContainsKey(s[i]))
                {
                    dict.Add(s[i], i);
                }
                else
                {
                    all[dict[s[i]]] = true;
                    all[i] = true;
                }
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (!all[i])
                    return i;
            }
            return -1;
        }
    }
}
