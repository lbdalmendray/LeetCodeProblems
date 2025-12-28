using System.Text;

namespace FaultyKeyboard;

public class Solution
{
    public string FinalString(string s)
    {
        LinkedList<char> result = new LinkedList<char>();
        bool directWay = true;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == 'i')
                directWay = !directWay;
            else if (directWay)
                result.AddLast(s[i]);
            else
                result.AddFirst(s[i]);
        }

        StringBuilder stringBuilder = new StringBuilder();

        if ( directWay)
        {
            var node = result.First;
            while(node != null )
            {
                stringBuilder.Append(node.Value);
                node = node.Next;
            }
        }
        else
        {
            var node = result.Last;
            while (node != null)
            {
                stringBuilder.Append(node.Value);
                node = node.Previous;
            }
        }

        return stringBuilder.ToString();
    }
}
