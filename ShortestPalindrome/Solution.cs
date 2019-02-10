using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPalindrome
{
    public class Solution
    {
        public string ShortestPalindrome(string s)
        {
            if (s.Length == 0 || s.Length == 1)
                return s;
            char[] slong = new char[s.Length + s.Length - 1];
            for (int i = 0; i < s.Length - 1; i++)
            {
                slong[2 * i] = s[i];
                //slong[2*i+1] =0;
            }
            slong[2 * (s.Length - 1)] = s[s.Length - 1];
            int index = ShortestPalindromeOddIndex(slong);
            return GeneratePalindrome(slong, index);
        }

        public string GeneratePalindrome(char[] slong, int index)
        {
            LinkedList<char> list = new LinkedList<char>();

            int i = index + 1;
            if (index % 2 == 0)
            {
                list.AddLast(slong[index]);
                i = index + 2;
            }

            for (; i < slong.Length; i += 2)
            {
                var value = slong[i];
                list.AddFirst(value);
                list.AddLast(value);
            }

            return new String(list.ToArray());
        }

        public int ShortestPalindromeOddIndex(char[] slong)
        {

            int index = slong.Length / 2;

            long leftValue = 0;
            long rightValue = 0;

            int i = index + 1;
            int j = index - 1;

            for (; j > -1; i++, j--)
            {
                leftValue += slong[j];
                rightValue += slong[i];
            }

            i--;
            j++;

            while (leftValue != rightValue || !IsEquals(slong,index+1,index-1) )
            {
                index--;
                rightValue -= slong[i];
                rightValue -= slong[i - 1];
                rightValue += slong[index + 1];
                i -= 2;

                leftValue -= slong[index];
            }

            return index;
        }

        private bool IsEquals(char[] slong, int index11, int index21 )
        {
            for (; index21 > -1 ; index11++, index21--)
            {
                if (slong[index11] != slong[index21])
                {
                    return false;
                }
            }

            return true;
        }

        public string ShortestPalindromeV2(string s)
        {
            if (s.Length == 0 || s.Length == 1)
                return s;

            Dictionary<char, int> relation = new Dictionary<char, int>(s.Length);
            int count = 1;
            char[] relationOp = new char[s.Length + 1];
            relationOp[0] = ' ';

            for (int i = 0; i < s.Length; i++)
            {
                if (!relation.ContainsKey(s[i]))
                {
                    relation.Add(s[i], count);
                    relationOp[count] = s[i];
                    count++;
                }
            }

            int[] slong = new int[s.Length + s.Length - 1];
            for (int i = 0; i < s.Length - 1; i++)
            {
                slong[2 * i] = relation[s[i]];
                //slong[2*i+1] =0;
            }
            slong[2*(s.Length - 1)] = relation[s[s.Length - 1]];
            int index = ShortestPalindromeOddIndexV2(slong, s.Length % 2 == 1, count);

            return GeneratePalindromeV2(slong, relationOp, index);

        }

        public string GeneratePalindromeV2(int[] slong, char[] relationOp, int index)
        {
            LinkedList<char> list = new LinkedList<char>();

            int i = index + 1;
            if (index % 2 == 0)
            {
                list.AddLast(relationOp[slong[index]]);
                i = index + 2;
            }

            for (; i < slong.Length ; i += 2)
            {
                var value = relationOp[slong[i]];
                list.AddFirst(value);
                list.AddLast(value);
            }

            return new String(list.ToArray());
        }

        public int ShortestPalindromeOddIndexV2(int[] slong, bool odd, int basee)
        {

            int index = slong.Length / 2;

            int leftValue = 0;
            int rightValue = 0;
            int basePow = 1;

            int i = index + 1;
            int j = index - 1;

            for (; j > -1; i++, j--)
            {
                leftValue += basePow * slong[j];
                rightValue += basePow * slong[i];
                basePow *= basee;
            }

            i--;
            j++;
            basePow = basePow / basee;

            while (leftValue != rightValue)
            {
                index--;
                rightValue -= basePow * slong[i];
                rightValue -= (basePow / basee) * slong[i - 1];
                rightValue *= basee;
                rightValue += slong[index + 1];
                i -= 2;

                leftValue -= slong[index];
                leftValue = leftValue / basee;
                basePow = basePow / basee;
            }

            return index;
        }
    }

    public class CharArrayIndexer
    {
        char[] value;
        char c;
        public readonly int Length;

        public CharArrayIndexer(char[] value)
        {
            this.value = value;
            Length = value.Length + value.Length - 1;
        }

        public char this[int i]
        {
            get
            {
                if (i % 2 == 0)
                    return value[i / 2];

                return c;
            }
        }
    }
}
