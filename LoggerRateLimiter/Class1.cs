using System;
using System.Collections.Generic;

namespace LoggerRateLimiter
{
    public class Logger
    {
        private readonly int delay;
        readonly Dictionary<string, int> messageTimeStamp = new Dictionary<string, int>();
        readonly LinkedList<(string,int)> messageListToPrint = new LinkedList<(string,int)>();
        public Logger(int delay)
        {
            this.delay = delay;
        }

        public bool ShouldPrintMessage(int timestamp, string message)
        {
            if (messageTimeStamp.TryGetValue(message, out int storedTimeStamp))
            {
                if (timestamp >= storedTimeStamp + delay)
                {
                    messageListToPrint.AddLast((message, timestamp));
                    messageTimeStamp[message] = timestamp;
                    return true;
                }
                else
                    return false;
            }
            else
            {
                messageListToPrint.AddLast((message, timestamp));
                messageTimeStamp[message] = timestamp;
                return true;
            }
        }
    }    

    /**
     * Your Logger object will be instantiated and called as such:
     * Logger obj = new Logger();
     * bool param_1 = obj.ShouldPrintMessage(timestamp,message);
     */
}
