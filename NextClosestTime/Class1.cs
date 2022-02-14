using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NextClosestTime
{
    public class Solution
    {
        public string NextClosestTime(string time)
        {
            char[] numValues = time.Distinct().ToArray();
            Array.Sort(numValues);
            char[] timeChars = time.ToArray();
            // TODO 
            IEnumerable<char[]> timesNotVerified = GetAllPosibleTimeNotVerified(numValues);
            // TODO
            char[][] times = timesNotVerified.Where(t => IsValidTime(t)).ToArray();
            int i = 0;
            for (; i < times.Length; i++)
                if (AreEqual(times[i], timeChars))
                    break;

            if ( i == times.Length)
                return new string(times[0]);
            else
                return new string(times[i + 1]);
        }

        private IEnumerable<char[]> GetAllPosibleTimeNotVerified(char[] numValues)
        {
            char[] currentValues = new char[] { numValues[0], numValues[0], numValues[0], numValues[0] };
            char[] zeros = new char[] { numValues[0], numValues[0], numValues[0], numValues[0] };
            yield return currentValues.Select(e => e).ToArray();
            while (true)
            {
                currentValues = GetNext(currentValues, numValues);
                if (AreEqual(currentValues, zeros))
                    break;
                yield return currentValues.Select(e => e).ToArray();
            }
        }

        private char[] GetNext(char[] currentValues, char[] numValues)
        {
            char[] result = numValues.Select(e=>e).ToArray();

            for (int i = currentValues.Length - 1; i > -1; i--)
            {
                if (currentValues[i] == numValues[numValues.Length - 1])
                {
                    result[i] = numValues[numValues.Length - 1];
                }
                else
                {
                    for (int j = 0; j < numValues.Length-1; j++)
                    {
                        if (result[i] == numValues[j])
                        {
                            result[i] = numValues[j + 1];
                            break;
                        }
                    }
                    break;
                }
            }

            return result;
        }

        private bool AreEqual(char[] time1 , char [] time2)
        {
            for (int i = 0; i < time1.Length; i++)
                if(time1[i] != time2[i])
                    return false;
            return true;
        }

        private bool IsValidTime(char [] input)
        {
            int h = int.Parse(input[0].ToString() + input[1]);
            if (h < 0 || h > 23)
                return false;

            int m = int.Parse(input[2].ToString() + input[3]);
            if (m < 0 || m > 59)
                return false;

            return true;
        }


    }
}
