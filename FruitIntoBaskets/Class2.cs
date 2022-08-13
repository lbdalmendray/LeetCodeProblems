using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitIntoBaskets
{
    public class Solution2
    {
        public int TotalFruit(int[] fruits)
        {
            int result = 0;
            int counter = 1;
            HashSet<int> lastTwo = new HashSet<int>();
            lastTwo.Add(fruits[0]);
            for (int i = 1; i < fruits.Length; i++)
            {
                if (lastTwo.Contains(fruits[i]))
                {
                    counter++;
                }
                else
                {
                    if (lastTwo.Count == 2)
                    {
                        if (counter > result)
                            result = counter;
                        var removeElement = lastTwo.First(e => e != fruits[i - 1]);
                        lastTwo.Remove(removeElement);
                        lastTwo.Add(fruits[i]);
                        counter = 2;
                        for (int j = i-2; j > -1 ; j--)
                        {
                            if (fruits[i - 1] == fruits[j])
                                counter--;
                            else
                                break;
                        }
                    }
                    else
                    {
                        lastTwo.Add(fruits[i]);
                        counter++;
                    }
                }
            }

            if (counter > result)
                result = counter;

            return result;
        }
    }
}
