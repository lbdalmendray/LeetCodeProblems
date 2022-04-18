using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpressiveWords
{
    public class Solution
    {
        public int ExpressiveWords(string s, string[] words)
        {
            var sList = GetWordList(s).ToArray();
            int result = 0;

            foreach (var word in words)
            {
                var wordList = GetWordList(word).ToArray();
                if( sList.Length ==  wordList.Length)
                {
                    bool isGood = true;
                    for (int i = 0; i < sList.Length; i++)
                    {
                        if( sList[i].Item1 != wordList[i].Item1)
                        {
                            isGood = false;
                            break;
                        }
                        else
                        {
                            if( sList[i].Item2 > 2)
                            {
                                continue;
                            }
                            else
                            {
                                if ( sList[i].Item2 != wordList[i].Item2)
                                {
                                    isGood = false;
                                    break;
                                }
                            }
                        }
                    }
                    if (isGood)
                        result++;
                }
            }

            return result;
        }

        public LinkedList<(char,int)> GetWordList( string word)
        {
            LinkedList<(char, int)> result = new LinkedList<(char, int)>();

            for (int i = 0; i < word.Length; i++)
            {
                var charValue = word[i];
                var charCounter = 0;

                int lastIndex = i;
                for (int j = lastIndex+1; j < word.Length; j++)
                {
                    if (word[j] == word[lastIndex])
                        lastIndex = j;
                    else
                        break;
                }

                charCounter = lastIndex - i + 1;
                result.AddLast((charValue, charCounter));
                i = lastIndex;
            }
            return result;
        }
    }
}
