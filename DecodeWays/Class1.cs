using System.Collections.Generic;
using System.Linq;
using System;

namespace DecodeWays
{
    public class Solution
    {
        public int NumDecodings(string s)
        {
            if (s[0] == '0')
                return 0;
            if (s.Contains("00"))
                return 0;
            
            
            if (s.Length == 1)
            {
                if (s[0] == '0')
                    return 0;
                else if (s[0] == '1')
                    return 1;
            }
            HashSet<string> codes = new HashSet<string>(Enumerable.Range(10,17).Select(e=>e.ToString()));
            int[] solutions = new int[s.Length+1];

            solutions[s.Length] = 1;

            int value = int.Parse( s[s.Length-1].ToString());

            /*if (value == 0)
                solutions[s.Length - 1] = 0;
            *///if( value != 0) 
            if (s[s.Length - 1] != '0')
                solutions[s.Length - 1] = 1;

            for( int i = s.Length-2 ; i> -1 ; i--  )
            {
                if (s[i] == '0')
                    continue;

                solutions[i] += solutions[i + 1];

                if ( codes.Contains(s.Substring(i,2)))
                {
                    solutions[i] += solutions[i+2];
                }
            }
            
            return solutions[0];
        }        
    }
}
