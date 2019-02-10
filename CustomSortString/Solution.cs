using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSortString
{
    public class Solution
    {
        public string CustomSortString(string S, string T)
        {
            if ( S == "")
            {
                return T;
            }

            if (T == "")
                return "";

            Dictionary<char, int> dict = new Dictionary<char, int>(S.Length);
            char[] rest = new char[T.Length];
            int restIndex = -1;
            for (int i = 0; i < S.Length; i++)
            {
                dict.Add(S[i], 0);
            }

            for (int i = 0; i < T.Length; i++)
            {
                if (dict.ContainsKey(T[i]))
                    dict[T[i]]++;
                else
                    rest[++restIndex] = T[i];
            }
            char[] result = new char[T.Length];
            int resultIndex = 0;
            for (int i = 0; i < S.Length; i++)
            {
                int cv = dict[S[i]];
                for (int j = 0; j < cv; j++)
                {
                    result[resultIndex] = S[i];
                    resultIndex++;
                }
            }

            for (int i = 0; i <= restIndex; i++)
            {
                result[resultIndex] = rest[i];
                resultIndex++;
            }

            return new string(result);

        }
    }
}
