using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseWordsinaString
{
    public class Solution
     {
        public string ReverseWords(string s)
        {
            if (s == null)
                return null;
            if (s == "")
                return "";

            LinkedList<LinkedList<char>> words = new LinkedList<LinkedList<char>>();

            int firstNotSpaceIndex = 0 ;
            
            for( ; firstNotSpaceIndex < s.Length ; firstNotSpaceIndex ++)
            {
                if ( s[firstNotSpaceIndex]!= ' ')
                {
                    break;
                }
            }               
        
            if ( firstNotSpaceIndex == s.Length)
            {
                return "";
            }
            words.AddLast(new LinkedList<char>());
            for ( int i = firstNotSpaceIndex ; i < s.Length ; i++)
            {
                if ( s[i]!= ' ')
                {
                    words.Last.Value.AddLast(s[i]);
                }
                else if(words.Last.Value.Count != 0)
                {
                   words.AddLast(new LinkedList<char>());
                }                            
            }
            if ( words.Last.Value.Count == 0)
            {
                words.RemoveLast();
            }
            StringBuilder sb = new StringBuilder();
            var node = words.Last ;
            bool firstWord = true;
            while( node != null)
            {
                var wordList = node.Value;
                
                if(!firstWord)
                {
                    sb.Append(' ');
                }
                else
                {
                    firstWord = false;
                }               
                
                foreach( var charValue in wordList)
                {
                    sb.Append(charValue);
                }
                
                node = node.Previous ;
            }

            return sb.ToString();
        }
    }
}
