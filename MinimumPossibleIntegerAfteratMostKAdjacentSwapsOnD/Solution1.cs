using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;

namespace MinimumPossibleIntegerAfteratMostKAdjacentSwapsOnD
{
    public class Solution1
    {
        static BigInteger[] tenPotence;

        public string MinInteger(string num, int k)
        {
            if( tenPotence == null || tenPotence.Length < num.Length +1)
            {
                tenPotence = new BigInteger[num.Length + 1];
                tenPotence[0] = 1;
                for (int i = 1; i < tenPotence.Length; i++)
                {
                    tenPotence[i] = tenPotence[i - 1] * 10;
                }
            }

            BigInteger number = BigInteger.Parse(num);
            BigInteger result = number;
            Dictionary<BigInteger, Dictionary<int, Info1>> solutions = new Dictionary<BigInteger, Dictionary<int, Info1>>();

            LinkedList<Info1> queue1 = new LinkedList<Info1>();

            queue1.AddLast(new Info1 { Number = number, NumberLength = num.Length, K = k , NumberIndex = num.Length - 1 });
            AddSolution(solutions, queue1.First.Value);

            while (queue1.Count != 0)
            {
                var first = queue1.First.Value;
                queue1.RemoveFirst();

                if (first.K == 0 || first.NumberIndex == 0 )
                {
                    continue;
                }

                var firstDigit = (first.Number / tenPotence[first.NumberIndex]) % 10;

                //LinkedList<int> indexes = new LinkedList<int>();
                int theIndex = 0;
                BigInteger minDigit = 10;
                for (int i = 1; i <=first.K && first.NumberIndex - i > -1; i++)
                { 
                    var cDigit = (first.Number / tenPotence[first.NumberIndex-i]) % 10;
                    if (cDigit >= firstDigit)
                        continue;
                    if( minDigit > cDigit)
                    {
                        minDigit = cDigit;
                        //indexes.Clear();
                        //indexes.AddLast(first.NumberIndex - i);
                        theIndex = first.NumberIndex - i;
                    }
                    /*else if ( minDigit == cDigit)
                    {
                        //indexes.AddLast(first.NumberIndex - i);
                    }*/
                }


                //if ( indexes.Count != 0)
                if (minDigit < 10)
                {
                    //foreach (var index in indexes)
                    //{
                        var rightPart = first.Number % tenPotence[theIndex];
                        var leftPart = (first.Number / tenPotence[first.NumberIndex + 1])* tenPotence[first.NumberIndex + 1];
                        var center = (first.Number - leftPart) / tenPotence[theIndex];
                        var centerChanged = center / 10 + minDigit * tenPotence[first.NumberIndex- theIndex];
                        var newNumber = leftPart + centerChanged* tenPotence[theIndex] + rightPart;
                        var newInfo = new Info1 { K = first.K - (first.NumberIndex - theIndex), Number = newNumber, NumberIndex = first.NumberIndex - 1, NumberLength = first.NumberLength };
                        if (!ContainsSolution(solutions, newInfo))
                        {
                            AddSolution(solutions, newInfo);
                            queue1.AddFirst(newInfo);
                            if (newNumber < result)
                                result = newNumber;
                        }
                    //}
                }
                else
                {
                        first.NumberIndex--;
                        queue1.AddLast(first);
                }
            }

            var semiResult = result.ToString();
            var sb = new StringBuilder();
            for (int i = 0; i < num.Length - semiResult.Length; i++)
            {
                sb.Append('0');
            }
            sb.Append(semiResult);
            return sb.ToString();
        }

        public string MinInteger1(string num, int k)
        {
            if (tenPotence == null || tenPotence.Length < num.Length + 1)
            {
                tenPotence = new BigInteger[num.Length + 1];
                tenPotence[0] = 1;
                for (int i = 1; i < tenPotence.Length; i++)
                {
                    tenPotence[i] = tenPotence[i - 1] * 10;
                }
            }

            BigInteger number = BigInteger.Parse(num);
            BigInteger result = number;
            Dictionary<BigInteger, Dictionary<int, Info1>> solutions = new Dictionary<BigInteger, Dictionary<int, Info1>>();

            LinkedList<Info1> queue1 = new LinkedList<Info1>();

            queue1.AddLast(new Info1 { Number = number, NumberLength = num.Length, K = k, NumberIndex = num.Length - 1 });
            AddSolution(solutions, queue1.First.Value);

            while (queue1.Count != 0)
            {
                var first = queue1.First.Value;
                queue1.RemoveFirst();

                if (first.K == 0 || first.NumberIndex == 0)
                {
                    continue;
                }

                var firstDigit = (first.Number / tenPotence[first.NumberIndex]) % 10;

                LinkedList<int> indexes = new LinkedList<int>();
                BigInteger minDigit = 10;
                for (int i = 1; i <= first.K && first.NumberIndex - i > -1; i++)
                {
                    var cDigit = (first.Number / tenPotence[first.NumberIndex - i]) % 10;
                    if (cDigit >= firstDigit)
                        continue;
                    if (minDigit > cDigit)
                    {
                        minDigit = cDigit;
                        indexes.Clear();
                        indexes.AddLast(first.NumberIndex - i);
                    }
                    else if (minDigit == cDigit)
                    {
                        indexes.AddLast(first.NumberIndex - i);
                    }
                }


                if (indexes.Count != 0)
                {
                    foreach (var index in indexes)
                    {
                        var rightPart = first.Number % tenPotence[index];
                        var leftPart = (first.Number / tenPotence[first.NumberIndex + 1]) * tenPotence[first.NumberIndex + 1];
                        var center = (first.Number - leftPart) / tenPotence[index];
                        var centerChanged = center / 10 + minDigit * tenPotence[first.NumberIndex - index];
                        var newNumber = leftPart + centerChanged * tenPotence[index] + rightPart;
                        var newInfo = new Info1 { K = first.K - (first.NumberIndex - index), Number = newNumber, NumberIndex = first.NumberIndex - 1, NumberLength = first.NumberLength };
                        if (!ContainsSolution(solutions, newInfo))
                        {
                            AddSolution(solutions, newInfo);
                            queue1.AddFirst(newInfo);
                            if (newNumber < result)
                                result = newNumber;
                        }
                    }
                }
                else
                {
                    first.NumberIndex--;
                    queue1.AddLast(first);
                }
            }

            var semiResult = result.ToString();
            var sb = new StringBuilder();
            for (int i = 0; i < num.Length- semiResult.Length; i++)
            {
                sb.Append('0');
            }
            sb.Append(semiResult);
            return sb.ToString();
        }

        private void AddSolution(Dictionary<BigInteger, Dictionary<int, Info1>> solutions, Info1 first)
        {
            if (!solutions.TryGetValue(first.Number, out var dict))
            {
                dict = new Dictionary<int, Info1>();
                solutions.Add(first.Number, dict);
            }

            dict.Add(first.K, first);
        }

        private bool ContainsSolution(Dictionary<BigInteger, Dictionary<int, Info1>> solutions, Info1 first)
        {
            if ( solutions.TryGetValue(first.Number, out var dict))
            {
                return dict.ContainsKey(first.K);
            }
            return false;
        }
    }

    internal class Info1
    {
        public BigInteger Number { get; internal set; }
        public int NumberLength { get; internal set; }
        public int K { get; internal set; }
        public int NumberIndex { get; internal set; }
    }
}
