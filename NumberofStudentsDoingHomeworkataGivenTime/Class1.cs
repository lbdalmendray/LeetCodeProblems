using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberofStudentsDoingHomeworkataGivenTime
{
    public class Solution
    {
        public int BusyStudent(int[] startTime, int[] endTime, int queryTime)
        {
            int result = 0;

            for (int i = 0; i < startTime.Length; i++)
            {
                if (queryTime >= startTime[i] && queryTime <= endTime[i])
                    result++;
            }

            return result;
        }
    }
}
