
using System;

namespace FindtheOriginalTypedStringII;

/// <summary>
/// NOT GOOD ENOUGH SOLUTION (Time Limit Exceeded)
/// </summary>
public class Solution2
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
            long?[,] solutions = new long?[counter.Count, k];

            for (int i = 1; i < counter.Count; i++)
                solutions[i, counter.Count - i] = 1;

            long result = GetNotSolution(0, k - 1, solutions, counter);
            if (products >= result)
                return (int)(products - result);
            else
                return (int)(Modulo + products - result);
        }
    }

    private long GetNotSolution(int index, long k, long?[,] solutions, List<long> counter)
    {
        if (solutions[index, k] != null)
            return solutions[index, k].Value;
        else
        {
            long result ;
            if ( index == counter.Count - 1 )
            {
                result = Math.Min(k, counter[index]);
            }
            else // if (k > 0)
            {
                result = 0;
                long limit = Math.Min(k - counter.Count + index + 1 , counter[index]);
                for (int currentK = 1; currentK <= limit; currentK++)
                {
                    result += GetNotSolution(index + 1, k - currentK, solutions, counter);
                    result %= Modulo;
                }
            }

            solutions[index, k] = result;
            return result;
        }
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
