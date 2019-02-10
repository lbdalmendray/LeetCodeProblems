using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartitionLabels
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "ababcbacadefegdehijhklij";
            input = "ab";
            Solution s = new Solution();
            var result = s.PartitionLabels(input);
        }
    }
}
