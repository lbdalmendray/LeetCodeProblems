using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweetCountsPerFrequency
{
    public class TweetCounts
    {
        Dictionary<string, SortedSet<int>> tweets;
        public TweetCounts()
        {
            tweets = new Dictionary<string, SortedSet<int>>();
        }

        public void RecordTweet(string tweetName, int time)
        {
            if (!tweets.TryGetValue(tweetName, out var sorted))
            {
                sorted = new SortedSet<int>();
                tweets.Add(tweetName, sorted);
            }
            sorted.Add(time);
        }

        public IList<int> GetTweetCountsPerFrequency(string freq, string tweetName, int startTime, int endTime)
        {
            int interval;
            // minute, hour, or day
            if ( freq == "minute")
            {
                interval = 60;
            }
            else if (freq == "hour")
            {
                interval = 60 * 60;
            }
            else
            {
                interval = 60 * 60 * 24;
            }
            
            if ( !tweets.TryGetValue(tweetName, out var sorted))
            {
                return new List<int>();
            }

            int amount = ((endTime - startTime)) / interval;


            int lastTime = Math.Min(startTime + (amount+1) * interval, endTime + 1);
            var arr = sorted.Where(e => e >= startTime && e < lastTime).ToArray();
            int[] result = new int[10002];

            for (int i = 0; i < arr.Length; i++)
            {
                var currentTime = arr[i];
                var noRelativeTime = currentTime - startTime;
                result[noRelativeTime / interval]++;
            }

            return result.Take(amount + 1).ToList();
            
            //return arr.Where(e=> e>= startTime && e < lastTime ).ToList();
        }
    }
}
