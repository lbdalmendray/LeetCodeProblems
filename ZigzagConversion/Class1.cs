using System.Runtime.CompilerServices;
using System.Text;

namespace ZigzagConversion;
/*
Constraints:
1 <= s.length <= 1000
s consists of English letters (lower-case and upper-case), ',' and '.'.
1 <= numRows <= 1000
*/


public class Solution
{
    public string Convert(string s, int numRows)
    {
        if (numRows > s.Length)
            return s; 
        else if (numRows == 1)
            return s;
        else
            return new string(ConvertEnumerable(s, numRows));
    }

    private Char[] ConvertEnumerable(string s, int numRows)
    {
        Char[] result = new char[s.Length];
        int m = 0;
        for (int i = 0; i < numRows; i++)
        {
            if (i == 0 || i == numRows - 1)
            {
                int j = i;
                while (j < s.Length)
                {
                    result[m++] = s[j];
                    j += 2 * (numRows - 1);
                }
            }
            else
            {
                bool IsGoingToSecondPart = true;
                int j = i;
                int secondPartDelta = 2 * (numRows - 1 - i);
                int firstPartDelta = 2 * i;
                while (j < s.Length)
                {
                    result[m++] = s[j];

                    if (IsGoingToSecondPart)
                    {
                        j += secondPartDelta;
                        IsGoingToSecondPart = false;
                    }
                    else
                    {
                        j += firstPartDelta;
                        IsGoingToSecondPart = true;
                    }
                }
            }
        }

        return result;
    }
}
