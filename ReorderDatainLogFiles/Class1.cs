using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace ReorderDatainLogFiles
{
    public class Solution
    {
        public string[] ReorderLogFiles(string[] logs)
        {
            List<string> result = new List<string>(logs.Length);

            var groups = logs.Select(l =>
            {
                var info = GetInfoFrom(l);

                return info;
            })
            .GroupBy(i=>i.IsWord).ToArray() ;

            var wordGroup =  groups.FirstOrDefault(g => g.Key);             
            var numberGroup =  groups.FirstOrDefault(g => !g.Key);

            if( wordGroup != null)
            {
                var wordGroupOrdered= wordGroup
                     .OrderBy(w => w.Content)
                     .ThenBy(w => w.Identifier);

                result.AddRange(wordGroupOrdered.Select(i => i.Log));
            }

            if (numberGroup != null)
            {
                result.AddRange(numberGroup.Select(i=>i.Log));
            }
            return result.ToArray();
        }

        private Info GetInfoFrom(string log)
        {
            // CALCULATING THE IDENTIFIER 
            int identIndex1 = 0;
            for (int i = 0; i < log.Length; i++)
            {
                if(log[i] !=' ')
                {
                    identIndex1 = i;
                    break;
                }
            }
            int indentIndex2 = identIndex1;

            for (int i = identIndex1+1; i < log.Length; i++)
            {
                if( log[i] == ' ')
                {
                    indentIndex2 = i - 1;
                    break;
                }
            }


            string identifier = log.Substring(identIndex1, indentIndex2 - identIndex1 + 1);

            //////////////////// DETERMINING IF IS A WORD OR NOT 

            bool isWord = false;

            for (int i = indentIndex2 + 1 ; i < log.Length; i++)
            {
                if( log[i] != ' ')
                {
                    isWord = Char.IsLetter(log[i]);
                    break;
                }
            }

            //////////////////
            ///

            string content = log.Substring(indentIndex2 + 1);

            return new Info(identifier, isWord, content,log);
        }
    }

    public class Info
    {
        public string Identifier { get; }
        public bool IsWord { get; }
        public string Content { get; }
        public string Log { get; }
        public Info(string identifier, bool isWord, string content, string log )
        {
            Identifier = identifier;
            IsWord = IsWord;
            Content = content;
            Log = log;
        }
    }
}
