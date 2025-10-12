using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GenerateParentheses;

public class Solution
{
    public IList<string> GenerateParenthesis(int n)
    {
        /// DO NOT WANT TO FIX THE RESULTS IN THE CODE BECAUSE THAT 
        /// IS NOT A FEAR SOLUTION. THIS IS BASED ON THE FACT THAT 
        /// 1<= n <= 8 

        List<string> result = new List<string>();
        IEnumerable<char[]> allPossibilities = GenerateParenthesis(n * 2, '(', ')');
        foreach (var item in allPossibilities)
        {
            if (IsAGoodPossibility(item))
                result.Add(new string(item));
        }

        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private bool IsAGoodPossibility(char[] charArrayValue)
    {
        int openCounter = 0;
        for (int i = 0; i < charArrayValue.Length; i++)
        {
            if (charArrayValue[i] == '(')
                openCounter++;
            else
            {
                openCounter--;
            }
            if (openCounter < 0)
                return false;
        }

        return openCounter == 0;    
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private List<char[]> GenerateParenthesis(int length, char charValue1, char charValue2)
    {
        List<char[]> result = new List<char[]>();

        char[] line = new char[length];
        line[0] = charValue1;
        line[length - 1] = charValue2;
        GenerateParentheses(line, 1, length - 2, result);
        return result;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void GenerateParentheses(char[] line, int index1, int lastIndex, List<char[]> result)
    {
        if (index1 > lastIndex)
        {
            result.Add((char[])line.Clone());
        }
        else
        {
            line[index1] = '(';
            GenerateParentheses(line, index1 + 1, lastIndex, result);
            line[index1] = ')';
            GenerateParentheses(line, index1 + 1, lastIndex, result);
        }
    }
}
