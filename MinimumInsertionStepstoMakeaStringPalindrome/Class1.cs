using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumInsertionStepstoMakeaStringPalindrome
{
    public class Solution
    {
        public int MinInsertions(string s)
        {
            if (IsPalindrome(s))
                return 0;
            var info = GetBestPalindromeSequence(s);
            if (info.Length == 0)
                return s.Length - 1;
            return GetSolution(info, s);
        }

        private int GetSolution(Info info, string s)
        {
            int result = 0;
            if (info.Indexes[0] > 0)
                result += info.Indexes[0];
            if (info.Indexes[1] < s.Length - 1)
                result += s.Length - 1 - (info.Indexes[1]);

            while (info.Next != null && info.Next.Length != 0)
            {
                result += info.Next.Indexes[0] - info.Indexes[0] - 1;
                result += info.Indexes[1] - info.Next.Indexes[1] - 1;
                info = info.Next;
            }

            if (info.Indexes[1] != info.Indexes[0] && info.Next != null)
            {
                if (info.Indexes[1] - info.Indexes[0] > 2)
                    result += info.Indexes[1] - info.Indexes[0] - 2;
                //result += info.Indexes[1] - info.Indexes[0] - 2;
            }

            return result;
        }

        public Info GetBestPalindromeSequence(string s)
        {
            Info[,] infos = new Info[s.Length, s.Length];
            return GetBestPalindromeSequence(s, 0, s.Length - 1, infos);
        }

        public Info GetBestPalindromeSequence(string s, int firstIndex, int lastIndex, Info[,] infos)
        {
            if (firstIndex >= lastIndex)
                return new Info();

            if (infos[firstIndex, lastIndex] != null)
                return infos[firstIndex, lastIndex];
            Info currentInfo;

            if (s[firstIndex] == s[lastIndex])
            {
                currentInfo = new Info();
                currentInfo.Indexes = new int[] { firstIndex, lastIndex };
                currentInfo.Next = GetBestPalindromeSequence(s, firstIndex + 1, lastIndex - 1, infos);
                currentInfo.Length = currentInfo.Next.Length + 1;
            }
            else
            {
                var first = GetBestPalindromeSequence(s, firstIndex + 1, lastIndex, infos);
                var second = GetBestPalindromeSequence(s, firstIndex, lastIndex - 1, infos);

                if (first.Length > second.Length)
                    currentInfo = first;
                else if (first.Length < second.Length)
                    currentInfo = second;
                else
                {
                    if (first.Diff() > second.Diff())
                    {
                        currentInfo = first;
                    }
                    else
                        currentInfo = second;
                }
            }
            infos[firstIndex, lastIndex] = currentInfo;
            return currentInfo;
        }

        private bool IsPalindrome(string s)
        {
            if (s.Length == 0 || s.Length == 1)
                return true;
            int mid = s.Length / 2;
            for (int i = 0; i < mid; i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                    return false;
            }
            return true;
        }
    }

    public class Info
    {
        public int[] Indexes { get; internal set; }
        public Info Next { get; internal set; }
        public int Length { get; internal set; }

        internal int Diff()
        {
            if (Indexes == null)
                return -1;
            return Indexes[1] - Indexes[0] + 1 ; 
        }
    }
}
