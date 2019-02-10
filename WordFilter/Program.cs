using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = null;
            Tuple<string[], string, string, int> tuple = null;
            WordFilter wf;
            int resultF = 0;

            words = new string[] { "aaaaaabaaa", "aaaaabnderaaarrr", "gsbbbaaavd" };
            tuple = new Tuple<string[], string, string, int>(words, "aa", "", 1);

            wf = new WordFilter(words);
            resultF = wf.F(tuple.Item2, tuple.Item3);

            Console.WriteLine(resultF == tuple.Item4 ? resultF + " :BIEN" : resultF + "!=" + tuple.Item4 + "MAAAAAAAAAAALLLLLLL");
            Console.ReadLine();

            ///////////////////////////

            words = new string[] { "aaaaaabaaa", "aaaaabnder", "gsbbbaaavd" };
            tuple = new Tuple<string[], string, string, int>(words, "aa", "b", -1);

            wf = new WordFilter(words);
            resultF = wf.F(tuple.Item2, tuple.Item3);

            Console.WriteLine(resultF == tuple.Item4 ? resultF + " :BIEN" : resultF + "!=" + tuple.Item4 + "MAAAAAAAAAAALLLLLLL");
            Console.ReadLine();

            ///////////////////////////

            words = new string[] { "aaaaaabaaa", "aaaaabndeasdasdr", "gsbbbaaavdfggggggggggggggg" };
            tuple = new Tuple<string[], string, string, int>(words, "", "", 2);

            wf = new WordFilter(words);
            resultF = wf.F(tuple.Item2, tuple.Item3);

            Console.WriteLine(resultF == tuple.Item4 ? resultF + " :BIEN" : resultF + "!=" + tuple.Item4 + "MAAAAAAAAAAALLLLLLL");
            Console.ReadLine();

            ///////////////////////////

            words = CreateWords(15000, 10);
            tuple = new Tuple<string[], string, string, int>(words, "", "", 14999);

            wf = new WordFilter(words);
            resultF = wf.F(tuple.Item2, tuple.Item3);

            Console.WriteLine(resultF == tuple.Item4 ? resultF + " :BIEN" : resultF + "!=" + tuple.Item4 + "MAAAAAAAAAAALLLLLLL");
            Console.ReadLine();

            /////////////////////////////

            words = new string[] { "aaaaaabaaa", "aaaaabndeasdasdr", "gsbbbaaavdfggggggggggggggg" };
            tuple = new Tuple<string[], string, string, int>(words, "aaaaa", "", 1);

            wf = new WordFilter(words);
            resultF = wf.F(tuple.Item2, tuple.Item3);

            Console.WriteLine(resultF == tuple.Item4 ? resultF + " :BIEN" : resultF + "!=" + tuple.Item4 + "MAAAAAAAAAAALLLLLLL");
            Console.ReadLine();

            ///////////////////////////

            words = new string[] { "apple", "applee" };
            tuple = new Tuple<string[], string, string, int>(words, "a", "ee", 1);

            wf = new WordFilter(words);
            resultF = wf.F(tuple.Item2, tuple.Item3);

            Console.WriteLine(resultF == tuple.Item4 ? resultF + " :BIEN" : resultF + "!=" + tuple.Item4 + "MAAAAAAAAAAALLLLLLL");
            Console.ReadLine();


            ////////////////

            words = new string[] { "abbbababbb", "baaabbabbb", "abababbaaa", "abbbbbbbba", "bbbaabbbaa", "ababbaabaa", "baaaaabbbb", "babbabbabb", "ababaababb", "bbabbababa" };
            tuple = new Tuple<string[], string, string, int>(words, "", "abaa", 5);

            wf = new WordFilter(words);
            resultF = wf.F(tuple.Item2, tuple.Item3);

            Console.WriteLine(resultF == tuple.Item4 ? resultF + " :BIEN" : resultF + "!=" + tuple.Item4 + "MAAAAAAAAAAALLLLLLL");
            Console.ReadLine();
            ////////////////

            words = new string[] { "abbbababbb", "baaabbabbb", "abababbaaa", "abbbbbbbba", "bbbaabbbaa", "ababbaabaa", "baaaaabbbb", "babbabbabb", "ababaababb", "bbabbababa" };
            tuple = new Tuple<string[], string, string, int>(words, "babbab", "", 7);

            wf = new WordFilter(words);
            resultF = wf.F(tuple.Item2, tuple.Item3);

            Console.WriteLine(resultF == tuple.Item4 ? resultF + " :BIEN" : resultF + "!=" + tuple.Item4 + "MAAAAAAAAAAALLLLLLL");
            Console.ReadLine();

            ////////////////

            words = new string[] { "abbbababbb", "baaabbabbb", "abababbaaa", "abbbbbbbba", "bbbaabbbaa", "ababbaabaa", "baaaaabbbb", "babbabbabb", "ababaababb", "bbabbababa" };
            tuple = new Tuple<string[], string, string, int>(words, "ab", "baaa", 2);

            wf = new WordFilter(words);
            resultF = wf.F(tuple.Item2, tuple.Item3);

            Console.WriteLine(resultF == tuple.Item4 ? resultF + " :BIEN" : resultF + "!=" + tuple.Item4 + "MAAAAAAAAAAALLLLLLL");
            Console.ReadLine();

            ////////////////

            words = new string[] { "abbbababbb", "baaabbabbb", "abababbaaa", "abbbbbbbba", "bbbaabbbaa", "ababbaabaa", "baaaaabbbb", "babbabbabb", "ababaababb", "bbabbababa" };
            tuple = new Tuple<string[], string, string, int>(words, "baaabba", "b", 1);

            wf = new WordFilter(words);
            resultF = wf.F(tuple.Item2, tuple.Item3);

            Console.WriteLine(resultF == tuple.Item4 ? resultF + " :BIEN" : resultF + "!=" + tuple.Item4 + "MAAAAAAAAAAALLLLLLL");
            Console.ReadLine();

            ////////////////

            words = new string[] { "abbbababbb", "baaabbabbb", "abababbaaa", "abbbbbbbba", "bbbaabbbaa", "ababbaabaa", "baaaaabbbb", "babbabbabb", "ababaababb", "bbabbababa" };
            tuple = new Tuple<string[], string, string, int>(words, "abab", "abbaabaa", 5);

            wf = new WordFilter(words);
            resultF = wf.F(tuple.Item2, tuple.Item3);

            Console.WriteLine(resultF == tuple.Item4 ? resultF + " :BIEN" : resultF + "!=" + tuple.Item4 + "MAAAAAAAAAAALLLLLLL");
            Console.ReadLine();

            ////////////////

            words = new string[] { "abbbababbb", "baaabbabbb", "abababbaaa", "abbbbbbbba", "bbbaabbbaa", "ababbaabaa", "baaaaabbbb", "babbabbabb", "ababaababb", "bbabbababa" };
            tuple = new Tuple<string[], string, string, int>(words, "", "aa", 5);

            wf = new WordFilter(words);
            resultF = wf.F(tuple.Item2, tuple.Item3);

            Console.WriteLine(resultF == tuple.Item4 ? resultF + " :BIEN" : resultF + "!=" + tuple.Item4 + "MAAAAAAAAAAALLLLLLL");
            Console.ReadLine();

            ////////////////

            words = new string[] { "abbbababbb", "baaabbabbb", "abababbaaa", "abbbbbbbba", "bbbaabbbaa", "ababbaabaa", "baaaaabbbb", "babbabbabb", "ababaababb", "bbabbababa" };
            tuple = new Tuple<string[], string, string, int>(words, "", "bba", 3);

            wf = new WordFilter(words);
            resultF = wf.F(tuple.Item2, tuple.Item3);

            Console.WriteLine(resultF == tuple.Item4 ? resultF + " :BIEN" : resultF + "!=" + tuple.Item4 + "MAAAAAAAAAAALLLLLLL");
            Console.ReadLine();

            ////////////////

            words = new string[] { "abbbababbb", "baaabbabbb", "abababbaaa", "abbbbbbbba", "bbbaabbbaa", "ababbaabaa", "baaaaabbbb", "babbabbabb", "ababaababb", "bbabbababa" };
            tuple = new Tuple<string[], string, string, int>(words, "", "baaaaabbbb", 6);

            wf = new WordFilter(words);
            resultF = wf.F(tuple.Item2, tuple.Item3);

            Console.WriteLine(resultF == tuple.Item4 ? resultF + " :BIEN" : resultF + "!=" + tuple.Item4 + "MAAAAAAAAAAALLLLLLL");
            Console.ReadLine();

            ////////////////

            words = new string[] { "abbbababbb", "baaabbabbb", "abababbaaa", "abbbbbbbba", "bbbaabbbaa", "ababbaabaa", "baaaaabbbb", "babbabbabb", "ababaababb", "bbabbababa" };
            tuple = new Tuple<string[], string, string, int>(words, "ba", "aabbbb", 6);

            wf = new WordFilter(words);
            resultF = wf.F(tuple.Item2, tuple.Item3);

            Console.WriteLine(resultF == tuple.Item4 ? resultF + " :BIEN" : resultF + "!=" + tuple.Item4 + "MAAAAAAAAAAALLLLLLL");
            Console.ReadLine();

            ////////////////

            words = new string[] { "abbbababbb", "baaabbabbb", "abababbaaa", "abbbbbbbba", "bbbaabbbaa", "ababbaabaa", "baaaaabbbb", "babbabbabb", "ababaababb", "bbabbababa" };
            tuple = new Tuple<string[], string, string, int>(words, "baaa", "aabbabbb", 1);

            wf = new WordFilter(words);
            resultF = wf.F(tuple.Item2, tuple.Item3);

            Console.WriteLine(resultF == tuple.Item4 ? resultF + " :BIEN" : resultF + "!=" + tuple.Item4 + "MAAAAAAAAAAALLLLLLL");
            Console.ReadLine();

            //    [null,5,7,2,1,5,5,3,6,6,1]
            //    ["WordFilter","f","f","f","f","f","f","f","f","f","f"]
            //[[["abbbababbb","baaabbabbb","abababbaaa","abbbbbbbba","bbbaabbbaa","ababbaabaa","baaaaabbbb","babbabbabb","ababaababb","bbabbababa"]],
            //["","abaa"],["babbab",""],["ab","baaa"],["baaabba","b"],["abab","abbaabaa"],["","aa"],["","bba"],["","baaaaabbbb"],["ba","aabbbb"],["baaa","aabbabbb"]]


            /*
             * ["WordFilter","f","f","f","f","f","f","f","f","f","f"]
[[["abbbababbb","baaabbabbb","abababbaaa","abbbbbbbba","bbbaabbbaa","ababbaabaa","baaaaabbbb","babbabbabb","ababaababb","bbabbababa"]],
["","abaa"],["babbab",""],["ab","baaa"],["baaabba","b"],["abab","abbaabaa"],["","aa"],["","bba"],["","baaaaabbbb"],["ba","aabbbb"],["baaa","aabbabbb"]]
             * 
             */

        }

        private static string[] CreateWords(int count, int wordLength)
        {
            string[] result = new string[(int)Math.Min(count, Math.Pow(26, wordLength))];
            resultIndex = 0;
            CreateWordsRecursive(wordLength, result,0,new char[wordLength]);
            return result;
        }

        static int resultIndex = 0; 

        private static void CreateWordsRecursive(int wordLength, string[] result , int letterIndex,char [] currentWord)
        {
            if (letterIndex >= wordLength)
            {
                result[resultIndex] = new string(currentWord);
                resultIndex++;
                return;
            }
            for (int i = 0; i < 26 && resultIndex < result.Length ; i++)
            {
                currentWord[letterIndex] = (char)('a' + i);
                CreateWordsRecursive(wordLength, result, letterIndex+1, currentWord);
            }
        }
    }
}
