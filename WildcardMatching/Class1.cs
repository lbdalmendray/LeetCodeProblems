using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildcardMatching
{
    public class Solution
    {
        public bool IsMatch(string s, string p)
        {
            if (p == null || p.Length == 0)
                return (s == null || s.Length == 0);
            if (p.Where(e => e != '*').Count() > s.Length)
                return false;
            LinkedList<char> reducerExpression = new LinkedList<char>();
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i]=='*' && reducerExpression.Count != 0 && reducerExpression.Last.Value == '*')
                {
                    continue;
                }
                reducerExpression.AddLast(p[i]);
            }

            p = new string(reducerExpression.ToArray());

            LinkedList<Info> states = new LinkedList<Info>();
            states.AddLast(new Info());

            while (states.Count != 0 )
            {
                var currentState = states.Last.Value;

                if (ItMatches(currentState,  s,  p))
                {
                    var firstIndexNotMatched = 0;
                    if (p[currentState.PIndex] == '*')
                        firstIndexNotMatched = currentState.SIndex + currentState.Length;
                    else
                        firstIndexNotMatched = currentState.SIndex + 1;

                    if ( firstIndexNotMatched == s.Length)
                    {
                        if (RestIsEmptyExpression(currentState.PIndex+1 , p ))
                        {
                            return true;
                        }
                        else
                        {
                            FindNextStateNotMatches(states, s, p);
                            // if (states.Count == 0)
                            //    return false;
                        }
                    }
                    else
                    {
                        if (currentState.PIndex + 1 == p.Length)
                        {
                            if (p[currentState.PIndex] == '*')
                                currentState.Length++;
                            else
                            {
                                FindNextStateNotMatches(states, s, p);
                                // if (states.Count == 0)
                                //    return false;
                            }
                        }
                        else
                            states.AddLast(new Info { SIndex = firstIndexNotMatched, PIndex = currentState.PIndex + 1 });
                    }                    
                }
                else
                {
                    FindNextStateNotMatches(states, s, p);
                    // if (states.Count == 0)
                    //    return false;
                }
            }

            return false;
        }

        private bool RestIsEmptyExpression(int index, string p)
        {
            if (index == p.Length)
                return true;
            for (int i = index; i < p.Length; i++)
            {
                if (p[i] != '*')
                    return false;
            }

            return true;
        }

        private void FindNextStateNotMatches(LinkedList<Info> states, string s, string p)
        {
            var currentState = states.Last.Value;
            
            if ( p[currentState.PIndex] == '*')
            {
                states.RemoveLast();
            }

            while(states.Count != 0)
            {
                currentState = states.Last.Value;
                if( p[ currentState.PIndex] == '*')
                {
                    currentState.Length++;
                    break;
                }
                else
                {
                    states.RemoveLast();
                }
            }
        }

        private bool ItMatches(Info currentState, string s, string p)
        {
            if (p[currentState.PIndex] == '*')
            {
                return true;
            }
            else if (currentState.SIndex < s.Length)
            { 
                if (p[currentState.PIndex] == '?')
                    return true;

                return s[currentState.SIndex] == p[currentState.PIndex];

            }
            return false;
        }
    }

    public class Info
    {
        public bool IsNull ;
        public int SIndex { get; set; }
        public int PIndex { get; set; }
        public int Length { get; internal set; }
    }
}
