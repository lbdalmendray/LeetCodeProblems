using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReorganizeString
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            string input = "aaabb";
            var r1 = s.ReorganizeString(input);
            var r2 = s.ReorganizeStringV2(input);
            bool equals = r1 == r2;
        }
    }
}
