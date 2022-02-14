using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FruitIntoBaskets
{
    public class Solution
    {
        public int TotalFruit(int[] fruits)
        {
            if (fruits == null)
                return 0;

            if ( fruits.Length <= 2)
            {
                return fruits.Length;
            }

            int result = 2;

            HashSet<int> numbers = new HashSet<int>();

            numbers.Add(fruits[0]);
            Info info = new Info { Counter = 1 };
            if (fruits[0] == fruits[1])
            {
                info.Stop = 1;
                info.Counter++;
            }
            else
            {
                numbers.Add(fruits[1]);
                info.Start = 1;
                info.Stop = 1;
                info.Counter++;
            }

            for (int i = 2; i < fruits.Length; i++)
            {
                var fruit = fruits[i];
                if (numbers.Contains(fruit))
                {
                    if (fruit == fruits[i - 1])
                    {
                        info.Stop++;
                        info.Counter++;
                    }
                    else
                    {
                        info.Start = i;
                        info.Stop++;
                        info.Counter++;
                    }
                }
                else
                {
                    if (numbers.Count == 1)
                    {
                        info.Counter++;
                        info.Stop++;
                        info.Start = i;
                        numbers.Add(fruit);
                    }
                    else // numbers.Count == 2
                    {
                        result = Math.Max(result, info.Counter);
                        info.Counter = info.Start - info.Stop + 2;
                        int iLess1 = info.Stop - 1;
                        if (iLess1 > -1)
                        {
                            numbers.Remove(fruits[iLess1]);
                        }
                        numbers.Add(fruit);
                        info.Start = i;
                        info.Stop = i;
                    }
                }
            }
            result = Math.Max(result, info.Counter);
            return result;
        }

        internal class Info
        {
            public int Start { get; set; }
            public int Stop { get; set; }
            public int Counter { get; set; }
        }
    }
}
