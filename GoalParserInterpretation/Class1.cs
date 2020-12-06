using System;
using System.Text;

namespace GoalParserInterpretation
{
    public class Solution
    {
        public string Interpret(string command)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < command.Length; i++)
            {
                if (command[i] == 'G')
                    result.Append('G');
                else // if ( command[i]=='(')
                {
                    i++;
                    if( command[i] == ')')
                    {
                        result.Append('o');
                    }
                    else
                    {
                        i+=2;
                        result.Append("al");
                    }
                }
            }

            return result.ToString();
        }
    }
}
