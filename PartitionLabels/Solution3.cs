using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartitionLabels
{
    public class Solution3
    {
        public IList<int> PartitionLabels(string s)
        {
            if (s == null || s.Length == 0)
                return new List<int>();

            LinkedList<int> result = new LinkedList<int>();

            Dictionary<char, int> lastIndexDictionary = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                lastIndexDictionary[s[i]] = i;
            }

            int lastIndex = -1;
            int firstIndex = -1;

            for (int i = 0; i < s.Length; i++)
            {
                if ( i > lastIndex )
                {
                    lastIndex = lastIndexDictionary[s[i]];
                    firstIndex = i;
                }

                if (i == lastIndex)
                    result.AddLast(lastIndex - firstIndex + 1);
                else
                {
                    lastIndex = lastIndexDictionary[s[i]];
                }
            }

            return result.ToList();
        }
    }
}
