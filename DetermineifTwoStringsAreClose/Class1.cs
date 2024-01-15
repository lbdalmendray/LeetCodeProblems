
namespace DetermineifTwoStringsAreClose
{
    public class Solution
    {
        public bool CloseStrings(string word1, string word2)
        {
            if (word1.Length != word2.Length)
                return false;

            Dictionary<char, int> word1CharCounter = GenerateCharCounterFrom(word1);
            Dictionary<int, HashSet<char>> word1CounterChar = GenerateCounterCharFrom(word1);

            Dictionary<char, int> word2CharCounter = GenerateCharCounterFrom(word2);

            foreach (var keyValue in word2CharCounter)
            {
                var charValue = keyValue.Key;
                var count = keyValue.Value;

                if (!word1CharCounter.TryGetValue(charValue, out var word1CharValueCount))
                    return false;
                else if (word1CharValueCount == count) /// IF BOTH WORDS CONTAINS THE SAME LETTER AND THE SAME AMOUNT AT HE SAME TIME
                {
                    word1CharCounter.Remove(charValue);
                    var hashSet = word1CounterChar[count];
                    hashSet.Remove(charValue);
                    if (hashSet.Count == 0)
                        word1CounterChar.Remove(count);
                }
                else if (word1CounterChar.TryGetValue(count, out var countHashSet)) //// IF BOTH WORDS CONTAINS THE SAME LETTER BUT DIFFERENT AMOUNT IT HAS TO TRANSFORM
                {
                    var otherLetter = countHashSet.First();
                    countHashSet.Remove(otherLetter);
                    if (countHashSet.Count == 0)
                        word1CounterChar.Remove(count);
                    word1CharCounter[otherLetter] = word1CharValueCount;
                    if ( word1CounterChar.TryGetValue(word1CharValueCount, out var hashSet))
                    {
                        hashSet.Remove(charValue);
                        hashSet.Add(otherLetter);
                    }
                    word1CharCounter.Remove(charValue);
                }
                else //// IT BOTH CONTAINS THE SAME LETTER BUT THERE IS NO OTHER LETTER WITH THE SAME COUNT IN WORD1
                    return false;
            }

            return true;
        }

        private Dictionary<int, HashSet<char>> GenerateCounterCharFrom(string word)
        {
           var groups = word.GroupBy(charValue => charValue);

            Dictionary<int, HashSet<char>> result = new Dictionary<int, HashSet<char>>();

            foreach (var group in groups)
            {
                var count = group.Count();
                if (! result.TryGetValue(count, out var hashSet))
                {
                    hashSet = new();
                    result[count] = hashSet;
                }

                hashSet.Add(group.Key);
            }

            return result;
        }

        private Dictionary<char, int> GenerateCharCounterFrom(string word)
        {
            var result = word
                            .GroupBy(charValue => charValue)
                            .ToDictionary( g=>g.Key, g=>g.Count() );

            return result;
        }
    }
}
