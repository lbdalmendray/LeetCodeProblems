using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestValidParentheses
{
    public class Solution
    {
        public int LongestValidParentheses(string s)
        {
            if (s == null || s.Length <= 1)
                return 0;

            int[] solutions = new int[s.Length];
            //solutions[s.Length - 1] = 0;

            for (int i = s.Length-2; i >= 0; i--)
            {
                if (s[i] == ')')
                    solutions[i] = 0;
                else
                {
                    if ( solutions[i+1] != 0)
                    {
                        if (solutions[i + 1] < s.Length - 1 && s[solutions[i + 1] + 1] == ')')
                        {
                            solutions[i] = solutions[i + 1] + 1;
                            if (solutions[i] + 1 < s.Length && solutions[solutions[i] + 1] != 0)
                                solutions[i] = solutions[solutions[i] + 1];
                        }
                        else
                            solutions[i] = 0;
                    }
                    else
                    {
                        if (s[i + 1] == ')')
                        {
                            if (i + 2 < s.Length && solutions[i + 2] != 0)
                                solutions[i] = solutions[i + 2];
                            else
                                solutions[i] = i + 1;
                        }
                        else
                            solutions[i] = 0;
                    }
                }
            }

            int result = 0;
            for (int i = 0; i < solutions.Length; i++)
            {
                if (solutions[i]!= 0)
                {
                    var currentLength = solutions[i] - i + 1;
                    if (currentLength > result)
                        result = currentLength;
                }
            }
            return result;
        }
    }
}
