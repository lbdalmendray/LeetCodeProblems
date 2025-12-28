namespace FindtheOriginalTypedStringII;

/// <summary>
/// NOT GOOD ENOUGH SOLUTION (Time Limit Exceeded)
/// </summary>
public class Solution
{
    public const long Modulo = 1000_000_007L;

    public int PossibleStringCount(string word, int k)
    {
        List<long> counter = GetCounterFromWord(word);
        counter.Sort((a, b) => (int)(b - a));
        long[] sum = GetSumFrom(counter);
        long[] products = GetProductsFrom(counter);
        long?[,] solutions = new long?[k + 1, k + 1];
        long result = GetSolution(0, k, solutions, products, sum, counter);
        result = result % Modulo;
        return (int)result;
    }

    private long GetSolution(int index, long k, long?[,] solutions, long[] products, long[] sum, List<long> counter)
    {
        if (solutions[index, k] != null)
            return solutions[index, k].Value;
        else
        {
            long result;
            if (products.Length - index >= k)
            {
                result = products[index];
            }
            else if (index == counter.Count - 1)
            {
                long count = counter[index];
                if (count >= k)
                    result = count - k + 1;
                else
                    result = 0;
            }
            else
            {
                long count = counter[index];
                if (count > k - 1)
                {
                    result = (count - k + 1) * products[index + 1];
                    result %= Modulo;
                }
                else
                    result = 0;
                for (long i = Math.Min(k - 1, count); i > 0; i--)
                {
                    if (sum[index + 1] < k - i)
                        break;
                    result += GetSolution(index + 1, k - i, solutions, products, sum, counter);
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

    public static long[] GetProductsFrom(List<long> counter)
    {
        long[] result = new long[counter.Count];
        result[counter.Count - 1] = counter[counter.Count - 1];

        for (int i = counter.Count - 2; i > -1; i--)
        {
            result[i] = counter[i] * result[i + 1];
            result[i] %= Modulo;
        }

        return result;
    }

    public static List<long> GetCounterFromWord(string word)
    {
        List<long> counter = new List<long>();

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
