using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumNumberofTapstoOpentoWateraGarden
{
    public class Solution
    {
        public int MinTaps(int n, int[] ranges)
        {
            int result = 0;

            int index = 0;
            int lastSolutionIndex = -1;
            
            while(true)
            {
                var info = GetSolution(index, lastSolutionIndex, ranges, n);
                if (info == null)
                    return -1;
                else
                {
                    result++;
                    if (info.Index >= n)
                        break;
                    index = info.Index;
                    lastSolutionIndex = info.LastSolutionIndex; 
                }
            }    

            return result;
        }

        private Info GetSolution(int index, int lastSolutionIndex, int[] ranges, int n)
        {
            Info info  = null;

            for (int i = lastSolutionIndex + 1; i <= n ; i++)
            {
                if ( ranges[i] > 0)
                {
                    if ( i >= index ? RangeContains(i-ranges[i], i+ranges[i], index) : ( i + ranges[i]> index ))
                    {
                        if ( info == null)
                        {
                            info = new Info { Index = i+ranges[i] , LastSolutionIndex = i  };
                        }
                        else
                        {
                            if(info.Index < i+ ranges[i])
                            {
                                info = new Info { Index = i + ranges[i], LastSolutionIndex = i };
                            }
                        }
                    }
                }
            }

            return info;            
        }

        private bool RangeContains(int index1, int index2, int index)
        {
            return index1 <= index && index <= index2;
        }
    }

    internal class Info
    {
        public int Index { get; internal set; }
        public int LastSolutionIndex { get; internal set; }
    }
}
