using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankTeamsbyVotes
{
    public class Solution
    {
        public string RankTeams(string[] votes)
        {
            Dictionary<char, int[]> dictionary = new Dictionary<char, int[]>(votes[0].Length);

            for (int i = 0; i < votes[0].Length; i++)
            {
                dictionary.Add(votes[0][i], new int[votes[0].Length]);
            }

            foreach (var vote in votes )
            {
                for (int i = 0; i < vote.Length; i++)
                {
                    dictionary[vote[i]][i]++;
                }
            }

            var keyValues = dictionary.ToArray();

            Array.Sort(keyValues,
                delegate ( KeyValuePair<char,int[]> e1, KeyValuePair<char, int[]> e2)
             {
                 int i = 0;
                 for (; i < e1.Value.Length; i++)
                 {
                     if (e1.Value[i] != e2.Value[i])
                         break;
                 }

                 if ( i == e1.Value.Length)
                 {
                     return Comparer<char>.Default.Compare(e1.Key, e2.Key);
                 }

                 return Comparer<int>.Default.Compare(e2.Value[i], e1.Value[i]);
             });

            return new string(keyValues.Select(e => e.Key).ToArray());

        }
    }
}
