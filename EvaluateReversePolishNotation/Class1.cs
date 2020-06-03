using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace EvaluateReversePolishNotation
{
    public class Solution
    {
        public int EvalRPN(string[] tokens)
        {
            LinkedList<int> queue = new LinkedList<int>();

            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i].Length == 1 && !Char.IsDigit(tokens[i][0]))
                {
                    if ( tokens[i][0] == '+')
                    {
                        queue.Last.Previous.Value += queue.Last.Value;
                    }
                    else if (tokens[i][0] == '*')
                    {
                        queue.Last.Previous.Value *= queue.Last.Value;
                    }
                    else if (tokens[i][0] == '-')
                    {
                        queue.Last.Previous.Value -= queue.Last.Value;
                    }
                    else // if (tokens[i][0] == '/')
                    {
                        queue.Last.Previous.Value /= queue.Last.Value;
                    }
                    queue.RemoveLast();
                }
                else
                {
                    queue.AddLast(int.Parse(tokens[i]));
                }
            }

            return queue.Last.Value;
        }

        
    }

}
