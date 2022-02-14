using System;
using System.Linq;
using System.Text;

namespace RepeatedStringMatch
{
    public class Solution
    {
        public int RepeatedStringMatch(string a, string b)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int result = 0;
            stringBuilder.Append(a);
            result++;
            while(stringBuilder.Length < b.Length)
            {
                stringBuilder.Append(a);
                result++;
            }
            if( stringBuilder.ToString().Contains(b))
                return result;
            stringBuilder.Append(a.Take(b.Length-1));
            
            for (int i = a.Length - 1, j =0 ; j < b.Length; i++,j++)
            {
                if (stringBuilder[i] != b[j])
                    return -1;
            }
            return result;
        }
    }
}
