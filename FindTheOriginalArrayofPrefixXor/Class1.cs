using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTheOriginalArrayofPrefixXor
{
    public class Solution
    {
        public int[] FindArray(int[] pref)
        {
            int[] result = new int[pref.Length] ;
            int[] bitResult = new int[pref.Length] ;
            result[0] = pref[0];
            bitResult[0] = pref[0];

            for (int i = 1; i < pref.Length; i++)
            {
                result[i] = bitResult[i-1] ^ pref[i];
                bitResult[i] = result[i] ^ bitResult[i - 1];
            }

            return result;
        }
    }
}
