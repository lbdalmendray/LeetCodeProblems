using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngleBetweenHandsofaClock
{
    public class Solution
    {
        public double AngleClock(int hour, int minutes)
        {
            double angMinute = GetAngleMinute(minutes);
            double angHour = GetAngleHour(hour,minutes);

            double maxAng = Math.Max(angMinute, angHour);
            double minAng = Math.Min(angMinute, angHour);

            return Math.Min(maxAng - minAng, minAng + 360 - maxAng);

        }

        private double GetAngleHour(double hour, double minutes)
        {
            return 360d * ((hour + (minutes / 60)) / 12) ;
        }

        private double GetAngleMinute(double minutes)
        {
            return 360d * (minutes / 60);
        }
    }
}
