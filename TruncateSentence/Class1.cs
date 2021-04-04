using System;
using System.Linq;
using System.Text;

namespace TruncateSentence
{
    public class Solution
    {
        public string TruncateSentence(string s, int k)
        {
            var parts = s.Split(' ');
            StringBuilder sb = new StringBuilder();
            sb.Append(parts[0]);
            foreach (var item in parts.Skip(1).Take(k-1))
            {
                sb.Append(" ");
                sb.Append(item);
            }
            return sb.ToString();
        }
    }
}
