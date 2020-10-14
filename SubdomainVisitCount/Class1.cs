using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubdomainVisitCount
{
    public class Solution
    {
        public IList<string> SubdomainVisits(string[] cpdomains)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            foreach (var item in cpdomains)
            {
                var splits = item.Split(' ');
                int number = int.Parse(splits[0]);
                var parts = splits[1].Split('.');
                string stringValue = parts[parts.Length - 1];
                if( result.TryGetValue(stringValue,out var cNumber))
                {
                    result[stringValue] = cNumber + number;
                }
                else
                    result.Add(stringValue, number);

                for (int i = parts.Length - 2; i > -1 ; i--)
                {
                    stringValue = $"{parts[i]}.{stringValue}";
                    if (result.TryGetValue(stringValue, out cNumber))
                        result[stringValue] = cNumber + number;
                    else
                        result.Add(stringValue, number);
                }
            }

            return result.Select(kv => $"{kv.Value} {kv.Key}").ToList();
        }
    }
}
