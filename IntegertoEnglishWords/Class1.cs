using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegertoEnglishWords
{
    public class Solution
    {
        public string NumberToWords(int num)
        {
            if (num == 0)
                return "Zero";

            string numString = num.ToString();
            LinkedList<string> result = new LinkedList<string>();

            string[] level = new string[] { null, "Thousand", "Million", "Billion" };

            int countLevel = numString.Length / 3 + (numString.Length % 3 == 0 ? 0 : 1);
            int i = 0;
            for (; i < countLevel-1; i++)
            {
                result.AddFirst(GetThree(numString, numString.Length - 1 - 2 - 3 * i, numString.Length - 1 - 3 * i,level[i]));
            }
            if (numString.Length % 3 == 1)
                numString = "00" + numString;
            else if (numString.Length % 3 == 2)
                numString = "0" + numString;

            result.AddFirst(GetThree(numString, numString.Length - 1 - 2 - 3 * i, numString.Length - 1 - 3 * i, level[i]));


            return GetAllString(result);
        }

        private string GetAllString(LinkedList<string> input)
        {
            string result = input.First.Value;

            foreach (var item in input.Skip(1).Where(e => e != ""))
            {
                result += " " + item;
            }

            return result;
        }

        private string GetThree(string numString, int index1, int index2, string level)
        {
            string result = "";
            var appendLevel = false;
            if ( numString[index1] != '0')
            {
                result += DigitName(numString[index1]) + " Hundred";
                appendLevel = true;
            }

            if ( numString[index1+1] != '0')
            {
                result += (result=="" ?"":" " )+ TwoDigitName(numString[index1+1],numString[index2]);
                appendLevel = true;
            }
            else
            {
                if (numString[index2] != '0')
                {
                    result += (result == "" ? "" : " ") + DigitName(numString[index2]);
                    appendLevel = true;
                }
            }
            if (result != "" && appendLevel&& level != null)
                result += " " + level;
            return result;
        }

        private string TwoDigitName(char v1, char v2)
        {
            string result = null; 
            if ( v1 == '1')
            {
                if (v2 == '0')
                    result = "Ten";
                else if (v2 == '1')
                    result = "Eleven";
                else if (v2 == '2')
                    result = "Twelve";
                else if (v2 == '3')
                    result = "Thirteen";
                else if (v2 == '4')
                    result = "Fourteen";
                else if (v2 == '5')
                    result = "Fifteen";
                else if (v2 == '6')
                    result = "Sixteen";
                else if (v2 == '7')
                    result = "Seventeen";
                else if (v2 == '8')
                    result = "Eighteen";
                else if (v2 == '9')
                    result = "Nineteen";
            }
            else if (v1 == '2')
            {
                result = "Twenty";
                if (v2 != '0')
                    result += " "+ DigitName(v2);
            }
            else if (v1 == '3')
            {
                result = "Thirty";
                if (v2 != '0')
                    result += " " + DigitName(v2);
            }
            else if (v1 == '4')
            {
                result = "Forty";
                if (v2 != '0')
                    result += " " + DigitName(v2);
            }
            else if (v1 == '5')
            {
                result = "Fifty";
                if (v2 != '0')
                    result += " " + DigitName(v2);
            }
            else if (v1 == '6')
            {
                result = "Sixty";
                if (v2 != '0')
                    result += " " + DigitName(v2);
            }
            else if (v1 == '7')
            {
                result = "Seventy";
                if (v2 != '0')
                    result += " " + DigitName(v2);
            }
            else if (v1 == '8')
            {
                result = "Eighty";
                if (v2 != '0')
                    result += " " + DigitName(v2);
            }
            else if (v1 == '9')
            {
                result = "Ninety";
                if (v2 != '0')
                    result += " " + DigitName(v2);
            }

            return result;
        }

        private string DigitName(char digit)
        {
            string result;

            if (digit == '0')
                result = "Zero";
            else if (digit == '1')
                result = "One";
            else if (digit == '2')
                result = "Two";
            else if (digit == '3')
                result = "Three";
            else if (digit == '4')
                result = "Four";
            else if (digit == '5')
                result = "Five";
            else if (digit == '6')
                result = "Six";
            else if (digit == '7')
                result = "Seven";
            else if (digit == '8')
                result = "Eight";
            else // if (digit == '9')
                result = "Nine";

            return result;
        }
    }
}
