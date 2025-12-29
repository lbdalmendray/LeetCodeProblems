
using System;

namespace FindtheOriginalTypedStringII;

/// <summary>
/// Solution3
/// </summary>
public class Solution3
{
    public const long Modulo = 1000_000_007L;

    public int PossibleStringCount(string word, int k)
    {
        List<long> counter = GetCounterFromWord(word);
        long products = GetProductsFrom(counter);
        if (k <= counter.Count)
            return (int)(products % Modulo);
        else
        {
            long result = GetNotSolution(counter, k);
            var diff = products - result;
            if (diff >= 0)
                return (int)(diff % Solution3.Modulo);
            else
                return (int)(Modulo + diff);
        }
    }

    private long GetNotSolution(List<long> counter, int k)
    {
        long result = 0;

        long firstIndex = 1;
        long lastIndex = Math.Min((counter[0]), k-1);
        long[] noSolutions = new long[(int)(lastIndex + 1)];
        for (int i = 1; i < noSolutions.Length; i++)
            noSolutions[i] = 1L;
        
        for (int i = 1; i < counter.Count; i++)
        {
            long count = counter[i];
            long currentFirstIndex = firstIndex + 1;
            long currentLastIndex = Math.Min(lastIndex + count, k - 1);
            long[] currentNoSolutions = new long[currentLastIndex+1];

            long sum = noSolutions[firstIndex];

            long midLastIndex = Math.Min(currentLastIndex, noSolutions.Length-1);
            var restIndex = count - 2 + currentFirstIndex;

            for (long j = currentFirstIndex; j <= midLastIndex; j++)
            {
                currentNoSolutions[j] = sum;
                sum += noSolutions[j];

                //if (j + 1 - (currentFirstIndex - 1) > count)
                if (j > restIndex)
                {
                    sum -= noSolutions[j - count];
                }
                sum %= Modulo;
            }

            for (long j = midLastIndex+1; j <= currentLastIndex; j++)
            {
                currentNoSolutions[j] = sum;

                //if (j + 1 - (currentFirstIndex - 1) > count)
                if (j > restIndex)
                {
                    sum -= noSolutions[j - count];
                    sum %= Modulo;
                }
            }

            noSolutions = currentNoSolutions;
            firstIndex = currentFirstIndex;
            lastIndex = currentLastIndex;
        }

        for (int i = 1; i < noSolutions.Length; i++)
        {
            result += noSolutions[i];
            result %= Modulo;
        }
        if (result < 0)
            result += Modulo;
        return result;
    }

    public static long[] GetSumFrom(List<long> counter)
    {
        long[] result = new long[counter.Count];
        result[counter.Count - 1] = counter[counter.Count - 1];

        for (int i = counter.Count - 2; i > -1; i--)
        {
            result[i] = counter[i] + result[i + 1];
        }

        return result;
    }

    public static long GetProductsFrom(List<long> counter)
    {
        long result = counter[counter.Count - 1];
        
        for (int i = counter.Count - 2; i > -1; i--)
        {
            result = counter[i] * result;
            result %= Modulo;
        }

        return result;
    }

    public static List<long> GetCounterFromWord(string word)
    {
        List<long> counter = new List<long>(500);

        long currentCount = 1;
        int index = 1;

        for (; index < word.Length; index++)
        {
            if (word[index] != word[index - 1])
            {
                counter.Add(currentCount);
                currentCount = 1;
            }
            else
            {
                currentCount++;
            }
        }
        counter.Add(currentCount);
        return counter;
    }
}
