using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumEqualFrequency
{
    public class Solution
    {
        public int MaxEqualFreq(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            int result = 0;
            int[] frequencies = new int[100001];
            int[] frequencyCounters = new int[100001];
            LinkedList<int> frequencyCounterList = new LinkedList<int>();
            LinkedListNode<int>[] frecuencyCounterListNodes = new LinkedListNode<int>[100001];

            for (int i = 0; i < nums.Length; i++)
            {
                var value = nums[i];
                var frequency = frequencies[value];
                if(frequency > 0 )
                {
                    frequencyCounters[frequency]--;
                    if(frequencyCounters[frequency] == 0 )
                    {
                        var node = frecuencyCounterListNodes[frequency];
                        frequencyCounterList.Remove(node);
                        frecuencyCounterListNodes[frequency] = null;
                    }
                }
                // new frequency

                frequency++;
                frequencies[value]++;
                frequencyCounters[frequency]++;
                if(frecuencyCounterListNodes[frequency] == null )
                {
                    var node = frequencyCounterList.AddLast(frequency);
                    frecuencyCounterListNodes[frequency] = node;
                }
                               
                if( frequencyCounterList.Count == 1)
                {
                    var frequencyFirsValue = frequencyCounterList.First.Value;
                    if (frequencyFirsValue == 1)
                    {
                        result = i + 1;
                    }
                    else if ( frequencyCounters[frequencyFirsValue] == 1)
                    {
                        result = i + 1;
                    }
                }
                else if(frequencyCounterList.Count == 2 )
                {
                    
                    if( frequencyCounters[1] == 1)
                    {
                        result = i + 1;
                        continue;
                    }

                    var minFrequencyCounterListElement = frequencyCounterList.First.Value;
                    var maxFrequencyCounterListElement = frequencyCounterList.Last.Value;
                    if ( minFrequencyCounterListElement > maxFrequencyCounterListElement)
                    {
                        var aux = minFrequencyCounterListElement;
                        minFrequencyCounterListElement = maxFrequencyCounterListElement;
                        maxFrequencyCounterListElement = aux;
                    }
                    
                    if ( frequencyCounters[maxFrequencyCounterListElement] == 1 && maxFrequencyCounterListElement == minFrequencyCounterListElement +1 )
                    {
                        result = i + 1;
                        continue;
                    }
                }      
            }

            return result;
        }
    }
}
