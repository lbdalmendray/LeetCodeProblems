namespace RemoveStonestoMinimizetheTotal
{
    public class Solution
    {
        /// <summary>
        /// O((K+N)*Log(N))
        /// </summary>
        /// <param name="piles"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinStoneSum(int[] piles, int k)
        {
            SortedDictionary<int, int[]> numberCounterDict = new SortedDictionary<int, int[]>(Comparer<int>.Create((a, b) => b - a));
            foreach (var pile in piles)
            {
                if( !numberCounterDict.TryGetValue(pile, out int[] value))
                {
                    value = new int[1];
                    numberCounterDict[pile] = value;
                }

                value[0]++;
            }
            int result = piles.Sum();
            for (int i = 0; i < k && result > 0; )
            {
                var numberCounter = numberCounterDict.First();
                var numberHalf = numberCounter.Key/2;
                if (numberHalf == 0) //// IF NUMBERHALF IS 0 THEN THE REST IS 0 SO NEVER WILL CHANGE THE RESULT
                    break;
                else
                {
                    int minCount = Math.Min(numberCounter.Value[0], k - i); //// TRY TO REMOVE AS MUCH AS POSSIBLE 
                    result -= numberHalf * minCount;
                    numberCounterDict.Remove(numberCounter.Key); //// THEN REMOVE THE NUMBER BECAUSE WHATEVER IS THE CASE IT IS TAKING ALL IT CAN AND NEVER WILL TRY AGAIN WITH THIS NUMBER 

                    //// ADDING THE NEWNUMBER OBTAINED AND ITS REPETITIONS ////////// 
                    
                    var newNumber = numberCounter.Key - numberHalf;
                    if (!numberCounterDict.TryGetValue(newNumber, out int[] value))
                    {
                        value = new int[1];
                        numberCounterDict[newNumber] = value;
                    }
                    value[0]+= minCount;
                    
                    //////////////////////////////////////////////////////////////////  
                    
                    i += minCount;
                }
            }

            return result;
        }
    }
}