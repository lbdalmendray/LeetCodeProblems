using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TweetCountsPerFrequency;

namespace TweetCountsPerFrequencyTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            TweetCounts tweetCounts = new TweetCounts();
            tweetCounts.RecordTweet("tweet3", 0);
            tweetCounts.RecordTweet("tweet3", 60);
            tweetCounts.RecordTweet("tweet3", 10);

            var result = tweetCounts.GetTweetCountsPerFrequency("minute", "tweet3", 0, 59); // return [2]. The frequency is per minute (60 seconds), so there is one interval of time: 1) [0, 60> - > 2 tweets.
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0], 2);

            result = tweetCounts.GetTweetCountsPerFrequency("minute", "tweet3", 0, 60); // return [2, 1]. The frequency is per minute (60 seconds), so there are two intervals of time: 1) [0, 60> - > 2 tweets, and 2) [60,61> - > 1 tweet.
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0], 2);
            Assert.AreEqual(result[1], 1);

            tweetCounts.RecordTweet("tweet3", 120);                            // All tweets correspond to "tweet3" with recorded times at 0, 10, 60 and 120.
            result = tweetCounts.GetTweetCountsPerFrequency("hour", "tweet3", 0, 210);

            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0], 4);




        }

        [TestMethod]
        public void TestMethod2()
        {
            /*
            
            ["TweetCounts","recordTweet","recordTweet","recordTweet","recordTweet","recordTweet","getTweetCountsPerFrequency","recordTweet","recordTweet","recordTweet","getTweetCountsPerFrequency","recordTweet","recordTweet"]
[[],["tweet0",12],["tweet1",39],["tweet2",81],["tweet3",11],["tweet4",45],["day","tweet2",11,1532],["tweet3",14],

["tweet4",90],["tweet3",13],["hour","tweet2",14,2203],["tweet4",87],["tweet2",74]]

            [null,null,null,null,null,null,[1],null,null,null,[1],null,null]

             */

            TweetCounts tweetCounts = new TweetCounts();
            tweetCounts.RecordTweet("tweet0", 12);
            tweetCounts.RecordTweet("tweet1", 39);
            tweetCounts.RecordTweet("tweet2", 81); //
            tweetCounts.RecordTweet("tweet3", 11);
            tweetCounts.RecordTweet("tweet4", 45);

            var result = tweetCounts.GetTweetCountsPerFrequency("day", "tweet2", 11, 1532);
            Assert.AreEqual(result.Count, 1);
            Assert.AreEqual(result[0], 1);

            tweetCounts.RecordTweet("tweet3", 14);
            tweetCounts.RecordTweet("tweet4", 90);
            tweetCounts.RecordTweet("tweet3", 13);

            result = tweetCounts.GetTweetCountsPerFrequency("hour", "tweet2", 14, 2203);
            Assert.AreEqual(result[0], 1);

            tweetCounts.RecordTweet("tweet4", 87);
            tweetCounts.RecordTweet("tweet2", 74);


        }
    }
}
