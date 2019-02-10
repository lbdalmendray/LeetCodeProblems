using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsNumber
{
    public class Solution
    {
        public bool IsNumber(string s)
        {
            if (s == "")
                return false;

            int index1 = -1;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ')
                {
                    index1 = i;
                    break;
                }
            }
            int index2 = index1;

            if (index1 == -1)
                return false;

            if ( index2 < s.Length)
            {
                for (; index2 < s.Length; index2++)
                {
                    if (s[index2] == ' ')
                    {
                        for (int j = index2+1; j < s.Length ; j++)
                        {
                            if (s[j] != ' ')
                                return false;
                        }
                        break;
                    }
                }
                index2--;
            }
            bool firstSign = false;
            if ( s[index1] == '+' || s[index1] == '-')
            {
                index1++;
                if (index1 > index2)
                    return false;
                firstSign = true;
            }
            
            s = s.Substring(index1, index2 - index1 + 1);

            var splitS = s.Split('e');
            if (splitS.Length > 2)
                return false;
            if (!IsNumberDotSimple(splitS[0]))
                return false;
            //if (firstSign && splitS[1].Length > 0 && (splitS[1][0] == '+' || splitS[1][0] == '-'))
            //    return false;
                
            if (splitS.Length == 2 && !IsNumberSimpleSign(splitS[1]))
                return false;

            return true;
        }

        public bool IsNumberDotSimple(string s)
        {
            if (s == "")
                return false;
            var splitS = s.Split('.');
            if (splitS.Length > 2)
                return false;

            if ( splitS.Length == 1 )
            {
                if (!IsNumberSimple(splitS[0]))
                    return false;
            }
            else if ( splitS.Length == 2 )
            {
                if (splitS[0] == "")
                {
                    if (IsNumberSimple(splitS[1]))
                        return true;
                    else
                        return false;
                }
                else if (splitS[1] == "")
                {
                    if (IsNumberSimple(splitS[0]))
                        return true;
                    else
                        return false;
                }
                else if (!IsNumberSimple(splitS[1]) || !IsNumberSimple(splitS[0]))
                    return false;
            }           

            return true;
        }

        private bool IsNumberSimpleCouldEmpty(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] > '9' || s[i] < '0')
                    return false;
            }
            return true;
        }

        private bool IsNumberSimple(string s)
        {
            if (s == "")
                return false;
            int i = 0;
            
            for (; i < s.Length; i++)
            {
                if (s[i] > '9' || s[i] < '0')
                    return false;
            }

            return true;
        }
        private bool IsNumberSimpleSign(string s)
        {
            if (s == "")
                return false;
            int i = 0;
            if (s[0] == '+' || s[0] == '-')
            {
                i++;
                if (i == s.Length)
                    return false;
            }
            for (; i < s.Length; i++)
            {
                if (s[i] > '9' || s[i] < '0')
                    return false;
            }

            return true;
        }
    }
}
