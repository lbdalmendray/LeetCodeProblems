using System.Text;

namespace FaultyKeyboard;

public class Solution2
{
    public string FinalString(string s)
    {
        int iCounter = 0;
        for (int i = 1; i < s.Length; i++)
            if (s[i] == 'i')
                iCounter++;

        char[] characters = new char[s.Length - iCounter];
        int charBackIndex = characters.Length - 1;
        int charFrontIndex = 0;

        if (iCounter % 2 == 0)
        {
            bool fromBack = true;
            for (int i = s.Length - 1; i > 0; i--)
            {
                if (s[i] == 'i')
                    fromBack = !fromBack;
                else if (fromBack)
                {
                    characters[charBackIndex--] = s[i];
                }
                else
                {
                    characters[charFrontIndex++] = s[i];
                }
            }

            characters[charFrontIndex] = s[0];
        }
        else
        {
            bool fromFront = false;

            for (int i = s.Length - 1; i > 0; i--)
            {
                if (s[i] == 'i')
                    fromFront = !fromFront;
                else if (fromFront)
                {
                    characters[charFrontIndex++] = s[i];
                }
                else
                {
                    characters[charBackIndex--] = s[i];
                }
            }

            characters[charBackIndex] = s[0];
        }
        return new string(characters);
    }
}
