namespace KeyboardRow;

public class Solution
{
    // In the American keyboard:
    // the first row consists of the characters "qwertyuiop",
    // the second row consists of the characters "asdfghjkl", and
    // the third row consists of the characters "zxcvbnm".
    static readonly int[] belongsTo = [1, 2, 2, 1, 0, 1, 1, 1, 0, 1, 1, 1, 2, 2, 0, 0, 0, 0, 1, 0, 0, 2, 0, 2, 0, 2,
                                        -1,-1,-1,-1,-1,-1, ///
                                       1, 2, 2, 1, 0, 1, 1, 1, 0, 1, 1, 1, 2, 2, 0, 0, 0, 0, 1, 0, 0, 2, 0, 2, 0, 2];


    public string[] FindWords(string[] words)
    {
        List<string> result = new List<string>(20);
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];
            int firstRow = belongsTo[word[0]-'A'];
            bool good = true;
            for (int j = 1; j < word.Length; j++)
            {
                if (belongsTo[word[j] - 'A'] != firstRow)
                {
                    good = false;
                    break;
                }
            }
            if ( good)
                result.Add(word);
        }
        return result.ToArray();
    }
}
