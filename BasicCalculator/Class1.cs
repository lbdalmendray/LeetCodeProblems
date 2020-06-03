using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCalculator
{
    public class Solution
    {
        public int Calculate(string s)
        {
            LinkedList<object> tokens = GenerateTokens(s);
            var node = tokens.First;
            while(tokens.Count != 1)
            {
                var nodeString = (node.Value as string);
                if (nodeString == ")")
                {
                    node = node.Previous;
                    tokens.Remove(node.Next);
                    tokens.Remove(node.Previous);
                }
                else if ( new string[] { "(" , "+" , "-" }.Contains(nodeString) )
                {
                    node = node.Next;
                }
                else
                {
                    var nodePrevString = node.Previous != null ? node.Previous.Value as string : "(" ;
                    if( nodePrevString == "(")
                    {
                        node = node.Next;
                    }
                    else
                    {
                        node = node.Previous.Previous;
                        node.Value = ((int)node.Value) + (((node.Next.Value as string) == "+" ? 1 : -1) * ((int)node.Next.Next.Value));
                        tokens.Remove(node.Next);
                        tokens.Remove(node.Next);
                    }
                }
            }
            return (int)tokens.Last.Value;
        }

        private LinkedList<object> GenerateTokens(string s)
        {
            LinkedList<object> result = new LinkedList<object>();
            for (int i = 0; i < s.Length; i++)
            {
                var symbol = s[i];
                if (symbol == ' ')
                {
                    continue;
                }
                else if ( symbol == '(')
                {
                    result.AddLast(symbol.ToString());
                }
                else if (symbol == ')' )
                {
                    result.AddLast(symbol.ToString());
                }
                else if ( symbol == '+' || symbol == '-')
                {
                    if( i == 0 ||  s[i-1] == '(' )
                    {
                        int first = i;
                        int firstNot = i + 2;
                        for (; firstNot < s.Length; firstNot++)
                        {
                            if (!Char.IsDigit(s[firstNot]))
                            {
                                break;
                            }                                
                        }
                        var currentValue = int.Parse(s.Substring(first, firstNot - first));
                        result.AddLast(currentValue);
                        i = firstNot-1;
                    }
                    else
                    {
                        result.AddLast(symbol.ToString());
                    }
                }
                else // NUMBER 
                {
                    int first = i;
                    int firstNot = i+1;
                    for (; firstNot < s.Length; firstNot++)
                    {
                        if (!Char.IsDigit(s[firstNot]))
                        {
                            break;
                        }                            
                    }
                    var currentValue = int.Parse(s.Substring(first, firstNot - first));
                    result.AddLast(currentValue);
                    i = firstNot - 1;
                }
            }

            return result;
        }
    }
}
