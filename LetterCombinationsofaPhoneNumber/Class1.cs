using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LetterCombinationsofaPhoneNumber
{
    public class Solution
    {
        public IList<string> LetterCombinations(string digits)
        {
            if (digits.Length == 0)
                return new List<string>();

            LinkedList<string> result = new LinkedList<string>();
            int[] max = new int[] { 0, 0, 2, 2, 2, 2, 2, 3, 2, 3 };
            char[] current = new char[digits.Length];
            int[] states = Enumerable.Repeat(-1, digits.Length).ToArray();
            int index = 0;
            while(true)
            {
                if ( states[index]!= max[index])
                {
                    states[index]++;
                }
                else
                {
                    if (index == 0)
                        break;
                    states[index] = -1;
                    index--;
                    continue;
                }

                current[index] = GetChar(digits[index], states[index]);

                if ( index == digits.Length-1)
                {
                    result.AddLast(new string(current));
                }
                else
                {
                    index++;
                }
            }


            return result.ToList();
        }

        private char GetChar(char charNumber, int index)
        {
            int number = charNumber - '2';
            int sum = number * 3 + index;
            return (char)('a' + sum);
        }
    }
}
