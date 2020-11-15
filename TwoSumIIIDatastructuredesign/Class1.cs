using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSumIIIDatastructuredesign
{
    public class TwoSum
    {
        Dictionary<int, int[]> numbersFreq;

        /** Initialize your data structure here. */
        public TwoSum()
        {
            numbersFreq = new Dictionary<int, int[]>();
        }

        /** Add the number to an internal data structure.. */
        public void Add(int number)
        {
            if (!numbersFreq.TryGetValue(number, out var array))
            {
                array = new int[] { 1 };
                numbersFreq[number] = array;
            }
            else
            {
                array[0]++;
            }
        }

        /** Find if there exists any pair of numbers which sum is equal to the value. */
        public bool Find(int value)
        {
            foreach (var item in numbersFreq)
            {
                int other = value - item.Key ;
                if (other == item.Key)
                {
                    if (item.Value[0] > 1)
                        return true;
                }
                else if (numbersFreq.ContainsKey(other))
                    return true;
            }

            return false;
        }
    }

    /**
     * Your TwoSum object will be instantiated and called as such:
     * TwoSum obj = new TwoSum();
     * obj.Add(number);
     * bool param_2 = obj.Find(value);
     */
}
