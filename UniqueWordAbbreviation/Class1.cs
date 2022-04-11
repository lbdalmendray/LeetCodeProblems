using System;
using System.Collections.Generic;

namespace UniqueWordAbbreviation
{
    public class ValidWordAbbr
    {
        Dictionary<string, Info> infoContainer = new Dictionary<string, Info>();
        public ValidWordAbbr(string[] dictionary)
        {
            if (dictionary != null)
            {
                foreach (var item in dictionary)
                {
                   var abbreviation = GetAbbreviation(item);
                   if(!infoContainer.TryGetValue(abbreviation, out var info))
                   {
                        info = new Info { RefWord = item };
                        infoContainer.Add(abbreviation, info);
                   }
                    info.Counter++;
                }
            }
        }

        public string GetAbbreviation( string word )
        {
            if (word.Length<3)
            {
                return word;
            }
            else
            {
                return $"{word[0]}{word.Length-2}{word[word.Length-1]}";
            }
        }

        public bool IsUnique(string word)
        {
            var abbreviation = GetAbbreviation(word);
            if (infoContainer.TryGetValue(abbreviation, out var info))
            {
                if ( info.Counter == 1)
                {
                    return word == info.RefWord;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }

    public class Info
    {
        public string RefWord { get; set; }
        public int Counter { get; set; }
    }

    /**
     * Your ValidWordAbbr object will be instantiated and called as such:
     * ValidWordAbbr obj = new ValidWordAbbr(dictionary);
     * bool param_1 = obj.IsUnique(word);
     */
}
