using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateaStringWithCharactersThatHaveOddCounts
{
    public class Solution
    {
        public string GenerateTheString(int n)
        {
            var isNotOdd = n % 2 == 0;
            var sb = new StringBuilder();
            if (isNotOdd)
            {
                sb.Append('b');
                var nlessOne = n - 1;
                for (int i = 0; i < nlessOne; i++)
                {
                    sb.Append('a');
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    sb.Append('a');
                }
            }

            return sb.ToString();
        }
    }
}
