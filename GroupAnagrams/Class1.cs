using System.Collections.Immutable;
using System.Text;
using tuple26 = (int, int, int, int, int
             , int, int, int, int, int
             , int, int, int, int, int
             , int, int, int, int, int
             , int, int, int, int, int
             , int);

namespace GroupAnagrams;

public class Solution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<string, List<string>> resultDict = new (strs.Length);

        for (int i = 0; i < strs.Length; i++)
        {
            var currentString = strs[i];
            var stringKey = GetKey(currentString);
            if (!resultDict.TryGetValue(stringKey, out var list))
            {
                list = new List<string>();
                resultDict.Add(stringKey, list);
            }
            list.Add(currentString);
        }

        return resultDict.Values
                         .Select(e => (IList<string>)e)
                         .ToList();
    }

    private string GetKey(string stringValue)
    {
        var stringValueArray = stringValue.ToCharArray();
        Array.Sort(stringValueArray);

        StringBuilder stringBuilder = new();

        for (int i = 0; i < stringValueArray.Length; i++)
        {
            char currentCharValue = stringValueArray[i];
            int firstOneDifferent = i+1;
            for (; firstOneDifferent < stringValueArray.Length; firstOneDifferent++)
            {
                if (stringValueArray[firstOneDifferent] != currentCharValue)
                {
                    break;
                }
            }
            
            stringBuilder.Append(stringValueArray[i]);
            int lastOneEqual = firstOneDifferent - 1;
            if (lastOneEqual - i > 0)
            {
                stringBuilder.Append(lastOneEqual - i);
            }
            i = lastOneEqual;
        }

        return stringBuilder.ToString();
    }

    public IList<IList<string>> GroupAnagrams2(string[] strs)
    {
        Dictionary<tuple26, List<string>> resultDict = new Dictionary<tuple26, List<string>>(strs.Length);

        for (int i = 0; i < strs.Length; i++)
        {
            var currentString = strs[i];
            var tuple26 = ConvertToTuple(currentString);
            if ( !resultDict.TryGetValue(tuple26, out var list))
            {
                list = new List<string>();
                resultDict.Add(tuple26, list);
            }
            list.Add(currentString);
        }

        return resultDict.Values
                         .Select(e=>(IList<string>)e)
                         .ToList();
    }

    private tuple26 ConvertToTuple(string stringValue)
    {
        tuple26 result = new();

        for (int i = 0; i < stringValue.Length; i++)
        {
            var charValue = stringValue[i];
            var letterIndex = (charValue - 'a');
            switch (letterIndex)
            {
                case 0:
                    result.Item1++;
                    break;
                case 1:
                    result.Item2++;
                    break;
                case 2:
                    result.Item3++;
                    break;
                case 3:
                    result.Item4++;
                    break;
                case 4:
                    result.Item5++;
                    break;
                case 5:
                    result.Item6++;
                    break;
                case 6:
                    result.Item7++;
                    break;
                case 7:
                    result.Item8++;
                    break;
                case 8:
                    result.Item9++;
                    break;
                case 9:
                    result.Item10++;
                    break;
                case 10:
                    result.Item11++;
                    break;
                case 11:
                    result.Item12++;
                    break;
                case 12:
                    result.Item13++;
                    break;
                case 13:
                    result.Item14++;
                    break;
                case 14:
                    result.Item15++;
                    break;
                case 15:
                    result.Item16++;
                    break;
                case 16:
                    result.Item17++;
                    break;
                case 17:
                    result.Item18++;
                    break;
                case 18:
                    result.Item19++;
                    break;
                case 19:
                    result.Item20++;
                    break;
                case 20:
                    result.Item21++;
                    break;
                case 21:
                    result.Item22++;
                    break;
                case 22:
                    result.Item23++;
                    break;
                case 23:
                    result.Item24++;
                    break;
                case 24:
                    result.Item25++;
                    break;
                case 25:
                    result.Item26++;
                    break;
                default:
                    break;
            }
        }

        return result;
    }
}
