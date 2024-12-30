using System.Text;

namespace ReverseInteger;

public class Solution
{
    const string int32MinValueString = "-2147483648";
    const string int32MaxValueString = "2147483647";
    public int Reverse(int x)
    {
        string xString = x.ToString();
        StringBuilder xStringBuilder = new StringBuilder(xString.Length);
        if (x < 0)
        {
            xStringBuilder.Append('-');
            for (int i = xString.Length - 1; i > 0; i--)
                xStringBuilder.Append(xString[i]);
        }
        else
        {
            for (int i = xString.Length - 1; i > -1; i--)
                xStringBuilder.Append(xString[i]);
        }

        string int32MinMaxValueString = x >= 0 
            ? int32MaxValueString
            : int32MinValueString;

        if (int32MinMaxValueString.Length < xStringBuilder.Length)
        {
            return 0;
        }
        else if (int32MinMaxValueString.Length > xStringBuilder.Length)
            return int.Parse(xStringBuilder.ToString());
        else
        {
            for (int i = 0 ; i < xStringBuilder.Length; i++)
            {
                if (int32MinMaxValueString[i] == xStringBuilder[i])
                    continue;
                else if (int32MinMaxValueString[i] < xStringBuilder[i])
                    return 0;
                else
                    break;
            }
            return int.Parse(xStringBuilder.ToString());
        }
    }
}
