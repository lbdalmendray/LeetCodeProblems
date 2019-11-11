using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxLengthConcatenatedStringUniqueCharacters // Maximum Length of a Concatenated String with Unique Characters
{
    public class Solution
    {
        public int MaxLength(IList<string> arr)
        {
            var infos = new Info[arr.Count];
            MaxLength(arr, infos);
            int result = 0;
            foreach (var item in infos)
            {
                foreach (var item2 in item.Solutions)
                {
                    if (item2.Length > result)
                        result = item2.Length;
                }
            }

            return result;
        }

        private  void MaxLength(IList<string> arr, Info[] infos)
        {
            var solutions = new LinkedList<Sol>();
            if(NotRepeatedLetters(arr[arr.Count - 1]))
            {
                solutions.AddLast(new Sol { Length = arr[arr.Count - 1].Length, Letters = GetLetters(arr[arr.Count - 1]) });
            }
            else
                solutions.AddLast(new Sol { Length = 0, Letters = GetLetters("") });

            infos[arr.Count - 1] = new Info { Solutions = solutions };

            for (int i = infos.Length-2; i >= 0; i --)
            {
                solutions = new LinkedList<Sol>();
                infos[i] = new Info { Solutions = solutions };
                if (NotRepeatedLetters(arr[i]))
                {
                    solutions.AddLast(new Sol { Length = arr[i].Length, Letters = GetLetters(arr[i]) });
                }
                else
                {
                    solutions.AddLast(new Sol { Length = 0, Letters = GetLetters("") });
                    continue;
                }

                for (int j = i+1; j < infos.Length ; j++)
                {
                    foreach (var item in infos[j].Solutions)
                    {
                        if (AreCompatible(arr[i], item))
                        {
                            solutions.AddLast(new Sol { Length = item.Length + arr[i].Length, Letters = GetLetters(arr[i], item.Letters) }    )  ;
                        }
                    }
                    
                }
            }
        }

        private bool NotRepeatedLetters(string v)
        {
            bool[] letters = new bool[26];
            foreach (var item in v)
            {
                if (letters[item - 'a'])
                    return false;
                letters[item - 'a'] = true;
            }

            return true;
        }

        private bool AreCompatible(string value, Sol item)
        {
            return !value.Any(v => item.Letters[v - 'a']);
        }

        private bool[] GetLetters(string value, bool [] result = null)
        {
            if (result == null)
                result = new bool[26];
            else
            {
                result = result.Select(v=>v).ToArray();
            }
            foreach (var item in value)
            {
                result[item - 'a'] = true;
            }
            return result;
        }
    }

    internal class Sol
    {
        public bool [] Letters { get; set; }
        public int Length { get; set; }
    }

    internal class Info
    {
        public LinkedList<Sol> Solutions { get; internal set; }
    }
}
