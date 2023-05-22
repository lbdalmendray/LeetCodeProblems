namespace LexicographicallySmallestPalindrome
{
    public class Solution
    {
        public string MakeSmallestPalindrome(string s)
        {
            int index = s.Length / 2 - 1;
            char[] sArray = s.ToArray();

            for (; index > -1; index--)
            {
                if (sArray[index] < sArray[sArray.Length - 1 - index])
                {
                    sArray[sArray.Length - 1 - index] = sArray[index];
                }
                else
                {
                    sArray[index] = sArray[sArray.Length - 1 - index];
                }
            }

            return new string(sArray);
        }
    }
}