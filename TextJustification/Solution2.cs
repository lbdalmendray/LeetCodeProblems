using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextJustification
{
    public class Solution2
    {
        public IList<string> FullJustify(string[] words, int maxWidth)
        {
            LinkedList<string> result = new LinkedList<string>();
            int i = 0;
            int j = i;
            int sum = 0;
            for (; i < words.Length; i++)
            {
                sum = words[i].Length;
                j = i + 1;
                for (; j < words.Length; j++)
                {
                    if (sum + words[j].Length + 1 > maxWidth)
                    {
                        break;
                    }
                    sum += words[j].Length + 1;
                }
                j--;
                if (j == words.Length - 1)
                    break;
                if (j != i)
                {
                    result.AddLast(GenerateLine(words, i, j, maxWidth, sum - (j - i)));
                }
                else
                {
                    result.AddLast(Filling(words, i, maxWidth));
                }
                i = j;
            }
            if (j != i)
            {
                result.AddLast(GenerateLineStrange(words, i, j, maxWidth, sum));
            }
            else
            {
                result.AddLast(Filling(words, i, maxWidth));
            }
            return result.ToList();
        }

        private string Filling(string[] words, int index, int maxWidth)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < words[index].Length; i++)
            {
                sb.Append(words[index][i]);
            }

            for (int i = 0; i < maxWidth - words[index].Length; i++)
            {
                sb.Append(' ');
            }

            return sb.ToString();
        }
        private string GenerateLine(string[] words, int index1, int index2, int maxWidth, int sum)
        {
            int diff = maxWidth - sum;
            int delta = diff / (index2 - index1);
            int rest = diff % (index2 - index1);
            StringBuilder sb = new StringBuilder();

            foreach (var item in words[index1])
            {
                sb.Append(item);
            }

            for (int i = index1 + 1; i < index2; i++)
            {
                for (int k = 0; k < delta; k++)
                {
                    sb.Append(' ');
                }
                if (rest != 0)
                {
                    sb.Append(' ');
                    rest--;
                }
                foreach (var item in words[i])
                {
                    sb.Append(item);
                }
            }
            if (rest != 0)
            {
                sb.Append(' ');
            }
            for (int k = 0; k < delta; k++)
            {
                sb.Append(' ');
            }

            foreach (var item in words[index2])
            {
                sb.Append(item);
            }

            return sb.ToString();
        }

        private string GenerateLineStrange(string[] words, int index1, int index2, int maxWidth, int sum )
        {
            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i < words[index1].Length; i++)
            {
                sb.Append(words[index1][i]);
            }

            for (int j = index1+1; j <=index2; j++)
            {
                sb.Append(' ');
                for (int i = 0; i < words[j].Length; i++)
                {
                    sb.Append(words[j][i]);
                }               
            }

            for (int i = 0; i < maxWidth - sum ; i++)
            {
                sb.Append(' ');
            }

            return sb.ToString();
        }
    }
}
