using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexicalOrder
{

    public class Solution
    {
        public IList<int> LexicalOrder(int n)
        {
            List<int> result = new List<int>(n);
            for (int i = 1; i < 10; i++)
            {
                if (i > n)
                    break;
                result.Add(i);
                Fill(i, result, n);                
            }
            return result;
        }

        void Fill(int lastValue, List<int> result, int n)
        {
            var lastValueP10 = lastValue * 10;
            for (int i = 0; i < 10; i++)
            {
                var newValue = lastValueP10 + i;
                if (newValue > n)
                    return;
                result.Add(newValue);
                Fill(newValue, result, n);
            }            
        }

            public IList<int> LexicalOrderV3(int n)
        {
            var comparer = Comparer<string>.Create(String.Compare);

            SortedDictionary<string, int> dict = new SortedDictionary<string, int>(comparer);

            for (int i = 1; i <= n; i++)
            {
                var ss = i.ToString();
                dict.Add(ss, i);
            }

            return dict.Select(v => v.Value).ToArray();
        }

        public IList<int> LexicalOrderV2(int n)
        {
            Tuple<int, string>[] numbers = new Tuple<int, string>[n];
            for (int i = 1; i <= n; i++)
            {
                numbers[i - 1] = new Tuple<int, string>(i, i.ToString());
            }
            int maxLength = numbers[numbers.Length - 1].Item2.Length;

            LinkedList<Tuple<int, string>>[] linkedArray = new LinkedList<Tuple<int, string>>[11];

            for (int i = 0; i < linkedArray.Length; i++)
            {
                linkedArray[i] = new LinkedList<Tuple<int, string>>();
            }

            for (int i = maxLength-1 ; i >= 0 ; i--)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if ( numbers[j].Item2.Length - 1  < i )
                    {
                        linkedArray[0].AddLast(numbers[j]);
                    }
                    else
                    {
                        linkedArray[numbers[j].Item2[i] - '0'+1] .AddLast(numbers[j]);
                    }
                }

                int k = 0;
                for (int j = 0; j < linkedArray.Length; j++)
                {
                    while(linkedArray[j].Count > 0)
                    {
                        numbers[k] = linkedArray[j].First.Value;
                        linkedArray[j].RemoveFirst();
                        k++;
                    }                     
                }
            }
            return numbers.Select(v => v.Item1).ToArray();

        }

        public IList<int> LexicalOrderV1(int n)
        {
            Tuple<int, string>[] numbers = new Tuple<int, string>[n];
            for (int i = 1; i <= n; i++)
            {
                numbers[i - 1] = new Tuple<int, string>(i, i.ToString());
            }

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (IsLessThan(numbers[j].Item2, numbers[i].Item2))
                    {
                        var aux = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j] = aux;

                    }
                }
            }

            return numbers.Select(v => v.Item1).ToArray();
        }


        public bool IsLessThan(string s1, string s2)
        {
            int i = 0;
            int min = Math.Min(s1.Length, s2.Length);
            for (; i < min; i++)
            {
                if (s1[i] > s2[i])
                    return false;
                else if (s1[i] < s2[i])
                {
                    return true;
                }
            }

            if (s1.Length > min)
                return false;

            return true;
        }

        
    }
}
