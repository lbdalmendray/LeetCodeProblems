using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumDifficultyofaJobSchedule
{
    public class Solution
    {
        public int MinDifficulty(int[] jobDifficulty, int d)
        {
            if (jobDifficulty == null || jobDifficulty.Length < d)
                return -1;

            int?[,] maximums = new int?[jobDifficulty.Length, jobDifficulty.Length];

            Info[,] infos = new Info[jobDifficulty.Length, d + 1];

            return Calculate(0, d, jobDifficulty, infos , maximums).Result;
            
        }

        private Info Calculate(int index, int d, int[] jobDifficulty, Info[,] infos, int?[,] maximums)
        {
            if (infos[index, d] != null)
                return infos[index, d];
            
            var info = new Info();
            infos[index, d] = info;

            if ( d == 1)
            {
                info.Result = GetMaximumFrom(index, jobDifficulty.Length - 1,jobDifficulty,  maximums);
            }
            else
            {
                int result = GetMaximumFrom(index, index, jobDifficulty, maximums);
                result += Calculate(index + 1, d - 1, jobDifficulty, infos, maximums).Result;

                for (int i = index+1; i < jobDifficulty.Length; i++)
                {
                    if (jobDifficulty.Length - (i+1)  < d - 1 )
                        break;

                    var cResult = GetMaximumFrom(index, i, jobDifficulty, maximums);
                    cResult += Calculate(i + 1, d - 1, jobDifficulty, infos, maximums).Result;
                    result = Math.Min(result, cResult);
                }

                info.Result = result;
            }

            return info;
        }

        public int MinDifficulty1(int[] jobDifficulty, int d)
        {
            if (jobDifficulty == null || jobDifficulty.Length < d)
                return -1;

            int?[,] maximums = new int?[jobDifficulty.Length, jobDifficulty.Length];

            Info[,,] infos = new Info[jobDifficulty.Length, jobDifficulty.Length, d+1];
            Info result;
            if (d == 1)
            {
                result = Calculate1(0, jobDifficulty.Length - 1, infos, jobDifficulty, d, maximums);
            }
            else
            {
                for (int i = 0; i < jobDifficulty.Length - (d - 1); i++)
                {
                    Calculate1(0, i, infos, jobDifficulty, d, maximums);
                }
                result = Calculate1(0, 0, infos, jobDifficulty, d, maximums);
                for (int i = 1; i < jobDifficulty.Length - (d - 1); i++)
                {
                    Info info = Calculate1(0, i, infos, jobDifficulty, d, maximums);
                    if (result.Result > info.Result)
                        result = info;
                }
            }

            return result.Result;
        }

        private Info Calculate1(int index1, int index2, Info[,,] infos, int[] jobDifficulty, int d, int?[,] maximums)
        {
            if (infos[index1, index2,d] != null)
                return infos[index1, index2,d];

            Info info = new Info();
            
            if ( d == 1 )
            {
                info.Result = GetMaximumFrom(index1, index2, jobDifficulty, maximums);

            }
            else
            {
                info.Result = GetMaximumFrom(index1, index2, jobDifficulty, maximums);

                int result = int.MaxValue;
                var newD= d-1;
                var newFirstIndex = index2+1;
                if (newD == 1)
                {
                    var cInfo = Calculate1(newFirstIndex, jobDifficulty.Length -1, infos, jobDifficulty, newD, maximums);
                    result = cInfo.Result;
                }
                else
                {
                    for (int i = newFirstIndex; i < jobDifficulty.Length - (newD - 1); i++)
                    {
                        var cInfo = Calculate1(newFirstIndex, i, infos, jobDifficulty, newD, maximums);
                        result = Math.Min(result, cInfo.Result);
                    }
                }

                info.Result += result;
            }

            infos[index1, index2, d] = info;
            return info;

        }

        private int GetMaximumFrom(int index1, int index2, int[] jobDifficulty, int?[,] maximums)
        {
            if (maximums[index1, index2].HasValue)
                return maximums[index1, index2].Value;
            int result;
            if (index1 == index2)
            {
                result = jobDifficulty[index1];
            }
            else
            {
                result = Math.Max(jobDifficulty[index2], GetMaximumFrom(index1, index2 - 1, jobDifficulty, maximums));
            }

            maximums[index1, index2] = result;
            return result;
        }
    }

    public class Info
    {
        public int Result { get; set; }
    }
}
