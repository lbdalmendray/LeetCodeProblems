using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEmptySlots
{
    public class Solution2
    {
        /// <summary>
        /// O (N)
        /// </summary>
        /// <param name="bulbs"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int KEmptySlots(int[] bulbs, int k)
        {
            int[] bulbDays = new int[bulbs.Length];
            for (int i = 0; i < bulbs.Length; i++)
            {
                bulbDays[bulbs[i]-1] = i + 1;
            }

            Info2[] infos = new Info2[bulbs.Length];
            int? result = null;

            for (int i = bulbs.Length - 1; i > -1; i--)
            {
                int index = bulbs[i]-1;
                Info2 info = new Info2 { Index1 = index, Index2 = index };
                infos[index] = info;
                if (index > 0 && infos[index - 1] != null)
                {
                    var info1 = infos[index - 1];
                    infos[info1.Index1].Index2 = info.Index2;
                    info.Index1 = info1.Index1;
                }

                if (index < bulbs.Length - 1 && infos[index + 1] != null)
                {
                    var info1 = infos[index + 1];
                    infos[info1.Index2].Index1 = info.Index1;
                    info.Index2 = info1.Index2;
                }

                if (info.Index1 > 0 && info.Index2 < bulbs.Length - 1 &&
                    info.Index2 - info.Index1 + 1 == k)
                {
                    int cResult = Math.Max(bulbDays[info.Index1 - 1], bulbDays[info.Index2 + 1]);
                    if (!result.HasValue)
                        result = cResult;
                    else
                        result = Math.Min(result.Value, cResult);
                }
            }
            if (result.HasValue)
                return result.Value;
            else
                return -1;
        }
    }

    public class Info2
    {
        public int Index1 { get; set; }
        public int Index2 { get; set; }
    }
}
