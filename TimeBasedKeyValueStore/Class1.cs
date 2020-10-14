using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeBasedKeyValueStore
{
    public class TimeMap
    {
        Dictionary<string, List<Info>> dict = new Dictionary<string, List<Info>>();

        /** Initialize your data structure here. */
        public TimeMap()
        {

        }

        public void Set(string key, string value, int timestamp)
        {
            if( !dict.TryGetValue(key,out var list))
            {
                list = new List<Info>();
                dict.Add(key, list);
            }

            list.Add(new Info { Value = value, Timestamp = timestamp });
        }

        public string Get(string key, int timestamp)
        {
            if ( !dict.TryGetValue(key, out var list))
            {
                return "";
            }

            int index = BinarySearch(list, timestamp);

            if (index == -1)
                return "";

            return list[index].Value;
        }

        private int BinarySearch(List<Info> list, int timestamp)
        {
            int index1 = 0;
            int index2 = list.Count - 1;

            while( index2 - index1 > 3)
            {
                int mid = (index1 + index2) / 2;

                var cTimeStamp = list[mid].Timestamp;

                if ( cTimeStamp > timestamp)
                {
                    index2 = mid - 1;
                }
                else
                {
                    index1 = mid;
                }                
            }

            for (int i = index2; i >= index1; i--)
            {
                if (list[i].Timestamp <= timestamp)
                    return i;
            }
            return -1;
        }
    }

    internal class Info
    {
        public string Value { get; set; }
        public int Timestamp { get; set; }
    }

    /**
     * Your TimeMap object will be instantiated and called as such:
     * TimeMap obj = new TimeMap();
     * obj.Set(key,value,timestamp);
     * string param_2 = obj.Get(key,timestamp);
     */
}
