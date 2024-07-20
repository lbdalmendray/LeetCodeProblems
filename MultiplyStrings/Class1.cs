namespace MultiplyStrings;

public class Solution
{
    public string Multiply(string num1, string num2)
    {
        if (num1[0] == '0' || num2[0] == '0')
            return "0";
        else
        {
            char[] result = Enumerable.Repeat('0', num1.Length + num2.Length)
                                  .ToArray();

            for (int num2Index = num2.Length - 1 ; num2Index > -1 ; num2Index--)
            {
                char [] currentArray = Multiply(num1, num2[num2Index]);
                Sum(currentArray, result, result.Length - 1 - (num2.Length - 1 - num2Index));
            }

            if (result[0] == '0')
                return new string(result.Skip(1).ToArray());
            else
            {
                return new string(result);
            }
        }        
    }

    public static void Sum(char[] currentArray, char[] result, int resultIndex)
    {
        int rest = 0;
        int i = currentArray.Length - 1;
        for (; i > -1; i--)
        {
            char resultCharValue = result[resultIndex - (currentArray.Length - 1 - i)];
            int resultIntValue = resultCharValue - '0';

            char currentArrayCharValue = currentArray[i];
            int currentArrayIntValue = currentArrayCharValue - '0';

            var intDigitSum = resultIntValue + currentArrayIntValue + rest;
            rest = intDigitSum / 10;
            result[resultIndex - (currentArray.Length - 1 - i)] = (char)(intDigitSum % 10 + '0');
        }

        if (rest > 0)
        {
            result[resultIndex - (currentArray.Length - 1 - i)] = (char)(rest + '0');
        }
    }

    private char[] Multiply(string num1, char v)
    {
        char[] result = Enumerable.Repeat('0', num1.Length + 1)
                                  .ToArray();
        int rest = 0;
        int intV = v - '0';

        int i = num1.Length - 1;
        for (; i > -1; i--)
        {
            var charValue = num1[i];
            int intValue = charValue - '0';

            var intDigitMultiply = intValue * intV + rest;
            rest = intDigitMultiply / 10;
            result[result.Length - 1 - (num1.Length - 1 - i)] = (char)(intDigitMultiply % 10 + '0');
        }

        if (rest > 0)
        {
            result[result.Length - 1 - (num1.Length - 1 - i)] = (char)(rest + '0');
            return result;
        }
        else
        {
            return result.Skip(1).ToArray();
        }
    }
}
