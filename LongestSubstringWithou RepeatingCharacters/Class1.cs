namespace LongestSubstringWithou_RepeatingCharacters
{
    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            if (s.Length == 0)
                return 0;
            else
            {
                int[] nextPosition = GenerateNextPosition(s);
                int result = 1;
                int currentLength = 1;

                for (int i = s.Length - 2; i > -1; i--)
                {
                    if (nextPosition[i] != -1)
                    {
                        var currentFinalPosition = Math.Min(i + currentLength, nextPosition[i]-1);
                        currentLength = currentFinalPosition - i + 1;
                    }
                    else
                    {
                        currentLength++;
                    }
                    result = Math.Max(result, currentLength);
                }

                return result;
            }
        }

        private int[] GenerateNextPosition(string s)
        {
            int[] result = new int[s.Length];
            Dictionary<char, int> lastOne = new Dictionary<char, int>();
            result[s.Length - 1] = -1;
            lastOne[s[s.Length - 1]] = s.Length - 1;

            for (int i = s.Length - 2; i > -1 ; i--)
            {
                var charValue = s[i];
                if (lastOne.TryGetValue(charValue, out int nextOne))
                    result[i] = nextOne;
                else
                    result[i] = -1;
                lastOne[charValue] = i;
            }

            return result;
        }
    }
}