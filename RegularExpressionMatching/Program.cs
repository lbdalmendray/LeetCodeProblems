using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegularExpressionMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            //var text1 = "aabaabaa";
            //var kmpA = s.KMP(".", text1, 0, text1.Length-1).ToArray();
            Tuple<string, string, bool>[] relations = new Tuple<string, string, bool>[]
            {
                //"aaa" "aaaa"
                new Tuple<string,string, bool>("abce","abc.*..",false),
                new Tuple<string,string, bool>("aa","*",false),
                new Tuple<string,string, bool>("aaa","aaaa",false),
                new Tuple<string,string, bool>("aa","a",false),
                new Tuple<string,string, bool>("aa","aa",true),
                new Tuple<string,string, bool>("aaa","aa",false),
                new Tuple<string,string, bool>("aa","a*",true),
                new Tuple<string,string, bool>("aa",".*",true),
                new Tuple<string,string, bool>("ab",".*",true),
                new Tuple<string,string, bool>("aab","c*a*b",true),
                new Tuple<string,string, bool>("aaaaaaaaaaaaab","c*a*a*b",true),
                new Tuple<string,string, bool>("aaaaaaaabbbbbbbbzaaaaab","c*a*b*a*b",false),
                new Tuple<string,string, bool>("","ba*",false),
                new Tuple<string,string, bool>("","a*",true),
                new Tuple<string,string, bool>("aa","",false),
                new Tuple<string,string, bool>("","",true),
                new Tuple<string,string, bool>("aaaa","",false),
                new Tuple<string,string, bool>("aaaa","a.*a.*",true),
                new Tuple<string,string, bool>("aa", ".*",true),
                new Tuple<string,string, bool>("aa", ".*",true),
                new Tuple<string,string, bool>("aa", ".a*b.",false),
                new Tuple<string,string, bool>("aaac", ".aa*b.*caa.*u*...e*p*aa*nnj*o*c",false),
                new Tuple<string,string, bool>("aabcbcbcaccbcaabc", ".*a*aa*.*b*.c*.*a*",true),
                new Tuple<string,string, bool>("aaa", "ab*ac*a",true),
                new Tuple<string,string, bool>("a", "ab*a",false),
                new Tuple<string,string, bool>("a", "ab*a",false),
                new Tuple<string,string, bool>("aa", "ab*c*a",true),
                new Tuple<string,string, bool>("aaa", "ab*c*a",false),
                new Tuple<string,string, bool>("abba", "ab*bc*a",true),
                new Tuple<string,string, bool>("abba", "ab*bc*a*",true),
                new Tuple<string,string, bool>("abcba", "ab*bc*a*",false),
                new Tuple<string,string, bool>("abcba", "ab*bc*.a*",true),
                new Tuple<string,string, bool>("abcba", "ab*bc*.a*",true),
                new Tuple<string,string, bool>("abcccccccccccccccccccbaaaaaaaaaa", "ab*bcccccccc*.....aaaaa*",true),
                new Tuple<string,string, bool>("abcccccccccccccccccccbaaaaaaaaaa", "ab*bcccccccc*..*...z*aaaaa*",true),
                new Tuple<string,string, bool>("abcccccccccccccccccccbaaaaaaaaaa", "..*.*..*..*..*.",true),
                new Tuple<string,string, bool>("bbcbbcbcbbcaabcacb", "a*.*ac*a*a*.a..*.*",false), // Este es de ellos y les da false, a mi me da true 

            };

            for (int i = 0; i < relations.Length; i++)
            {
                Console.WriteLine( (relations[i].Item1 =="" ? "\"\"": relations[i].Item1) + " " + (relations[i].Item2 == "" ? "\"\"" : relations[i].Item2) + " " + relations[i].Item3);
                var result = s.IsMatch(relations[i].Item1, relations[i].Item2);
                Console.WriteLine("Answer:" + result + (result != relations[i].Item3 ? "-------DIFFERENT RESULTS --------- " : ""));
            }

            Console.ReadLine();
        }
    }
}
