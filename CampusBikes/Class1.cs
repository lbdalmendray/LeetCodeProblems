using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CampusBikes
{
    public class Solution
    {
        public int[] AssignBikes(int[][] workers, int[][] bikes)
        {
            Info[] workerBikeList = new Info[workers.Length * bikes.Length];

            int j = 0;

            for (int i = 0; i < workers.Length; i++)
            {
                for (int k = 0; k < bikes.Length; k++)
                {
                    Info info = new Info 
                    {
                        Distance = CalculateDistance(workers[i]  , bikes[k]  ),
                        WorkerIndex = i,
                        BikeIndex = k
                    };
                    workerBikeList[j] = info;
                    j++;
                }
            }

            var workerBikeListSorted = workerBikeList
                .OrderBy(e => e.Distance)
                .ThenBy(e => e.WorkerIndex)
                .ThenBy(e => e.BikeIndex).ToArray();

            bool[] workersSelected = new bool[workers.Length];
            bool[] bikesSelected = new bool[bikes.Length];
            List<Info> infoResult = new List<Info>(workers.Length);
            for (int i = 0; i < workerBikeListSorted.Length; i++)
            {
                var info = workerBikeListSorted[i];
                if (workersSelected[info.WorkerIndex] ||
                    bikesSelected[info.BikeIndex])
                    continue;
                workersSelected[info.WorkerIndex] = true;
                bikesSelected[info.BikeIndex] = true;
                infoResult.Add(info);
            }

            int[] result = new int[workers.Length];

            foreach (var item in infoResult)
                result[item.WorkerIndex] = item.BikeIndex;

            return result;
        }

        int CalculateDistance(int [] v1  , int [] v2  )
        {
            int result = Math.Abs(v1[0] - v2[0]) + Math.Abs(v1[1] - v2[1]);
            return result;
        }
    }

    class Info
    {
        public int Distance { get; set; }
        public int WorkerIndex { get; set; }
        public int BikeIndex { get; set; }
    }
}
