using System.Runtime.InteropServices;
using System.Text;

namespace ReverseInteger;

public class Solution
{
    const string int32MinValueString = "-2147483648";
    const string int32MaxValueString = "2147483647";
    public unsafe int Reverse(int x)
    {
        string xString = x.ToString();
        //char[] xResultString = new char[xString.Length];

        char* xResultString = (char*)Marshal.AllocHGlobal((xString.Length + 1) * sizeof(char));
        xResultString[xString.Length] = '\0';

        if (x < 0)
        {
            xResultString[0] = '-';
            for (int i = xString.Length - 1; i > 0; i--)
                xResultString[xString.Length - i] = xString[i];
        }
        else
        {
            for (int i = xString.Length - 1; i > -1; i--)
                xResultString[xString.Length - 1 - i] = xString[i];
        }

        string int32MinMaxValueString = x >= 0 
            ? int32MaxValueString
            : int32MinValueString;

        if (int32MinMaxValueString.Length < xString.Length)
        {
            return 0;
        }
        else if (int32MinMaxValueString.Length > xString.Length)
            return int.Parse(new string(xResultString));
        else
        {
            for (int i = 0 ; i < xString.Length; i++)
            {
                if (int32MinMaxValueString[i] == xResultString[i])
                    continue;
                else if (int32MinMaxValueString[i] < xResultString[i])
                    return 0;
                else
                    break;
            }
            return int.Parse(new string(xResultString));
        }
    }
}
