using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DecodeWaysII
{
    public class Solution
    {
        public int NumDecodings(string s)
        {
            /*
             if (ExistZeroInValid(s))
                return 0;
                */
                
            ulong[] solutions = new ulong[s.Length + 1];
            solutions[s.Length] = 1;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                NumDecodings(i, solutions, s);
            }

            return (int)(solutions[0]);
        }

        private ulong NumDecodings(int index, ulong[] solutions, string s)
        {
            ulong result = 0;
            if (s[index] == '*')
            {
                result += 9 * solutions[index + 1];
                if (index < s.Length - 1)
                {
                    if (s[index + 1] == '*')
                    {
                        result += 15 * solutions[index + 2];
                    }
                    else if (s[index + 1] <= '6')
                    {
                        result += 2 * solutions[index + 2];
                    }
                    else
                    {
                        result += solutions[index + 2];
                    }
                }
            }
            else if (s[index] != '0')
            {
                result += solutions[index + 1];

                if (index < s.Length - 1 && s[index] <= '2')
                {
                    if (s[index + 1] == '*')
                    {
                        if (s[index] == '1')
                            result += 9 * solutions[index + 2];
                        else
                            result += 6 * solutions[index + 2];
                    }
                    else
                    {
                        if (s[index] == '1')
                            result += solutions[index + 2];
                        else
                        {
                            if (s[index + 1] <= '6')
                                result += solutions[index + 2];
                        }
                    }
                }
            }

            solutions[index] = result % (1000000007);

            return result;
        }

    }
}
