using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RansomNote
{
    public class Solution
    {
        public bool CanConstruct(string ransomNote, string magazine)
        {
            if (ransomNote == null || ransomNote.Length == 0)
                return true;
            if (ransomNote.Length > magazine.Length)
                return false;

            int[] megArray = new int[26];
            for (int i = 0; i < magazine.Length; i++)
            {
                megArray[magazine[i] - 'a']++;
            }

            for (int i = 0; i < ransomNote.Length; i++)
            {
                int index = ransomNote[i] - 'a';
                if (megArray[index] == 0)
                    return false;
                megArray[index]--;
            }
            return true;
        }
    }
}
