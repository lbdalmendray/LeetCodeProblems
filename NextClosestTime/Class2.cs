using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextClosestTime
{
    public class Solution2
    {
        public string NextClosestTime(string time)
        {
            var timeSplit = time.Split(':').Select(i=>int.Parse(i)).ToArray();
            var timeValue = new Tuple<int, int>(timeSplit[0], timeSplit[1]);
            var times = GenerateTimes
                (
                time.Where(e=>e!=':')
                .Select(k=>int.Parse(k.ToString()))).ToArray();

            int i = 0;
            for (; i < times.Length; i++)
            {
                var cTimeValue = times[i];
                if (cTimeValue.Item1 == timeValue.Item1
                    && cTimeValue.Item2 == timeValue.Item2)
                    break;
            }

            var resultTime = i < times.Length - 1 ? times[i + 1] : times[0];

            string result = "";
            if (resultTime.Item1 < 10)
                result += "0" + resultTime.Item1;
            else
                result += resultTime.Item1;
            result += ":";
            if (resultTime.Item2 < 10)
                result += "0" + resultTime.Item2;
            else
                result += resultTime.Item2;

            return result;
        }

        public IEnumerable<Tuple<int, int>> GenerateTimes(IEnumerable<int> digits)
        {
            for (int i = 0; i < 24; i++)
            {
                if (DigitsDoNotContainElementDigits(digits, i))
                    continue;

                for (int j = 0; j < 60; j++)
                {
                    if (DigitsDoNotContainElementDigits(digits, j))
                        continue;

                    yield return new Tuple<int, int>(i, j);
                }
            }
        }

        private bool DigitsDoNotContainElementDigits(IEnumerable<int> digits, int number)
        {
            bool result = false;
            var numberString = number < 10 ? $"0{number}" : number.ToString();
            foreach (var item in numberString.Select(e => int.Parse(e.ToString())))
            {
                if (!digits.Contains(item))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}
