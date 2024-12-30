using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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
    public unsafe string Convert(string s, int numRows)
    {
        if (numRows > s.Length)
            return s;
        else if (numRows != 1)
        {
            char* result = (char*)Marshal.AllocHGlobal((s.Length + 1) * sizeof(char));
            result[s.Length] = '\0';

            var numRowsLess1 = numRows - 1;
            int m = 0;
            int j;
            var delta = 2 * (numRowsLess1);
            
            //// CASE INDEX == 0
            j = 0;
            while (j < s.Length)
            {
                result[m++] = s[j];
                j += delta;
            }

            //// CASE : INTERNAL INDEXES 

            for (int i = 1; i < numRowsLess1; i++)
            {
                bool IsGoingToSecondPart = true;
                j = i;
                int secondPartDelta = 2 * (numRowsLess1 - i);
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

            //// CASE INDEX == numRows - 1

            j = numRowsLess1;
            while (j < s.Length)
            {
                result[m++] = s[j];
                j += delta;
            }

            return new string(result);
        }
        else
            return s;
    }

    public unsafe string Convert2(string s, int numRows)
    {
        if (numRows > s.Length)
            return s;
        else if (numRows != 1)
            return new string(ConvertEnumerable(s, numRows));
        else
            return s;
    }

    private unsafe char* ConvertEnumerable(string s, int numRows)
    {
        char* result = (char*)Marshal.AllocHGlobal((s.Length + 1) * sizeof(char));
        result[s.Length] = '\0';

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
