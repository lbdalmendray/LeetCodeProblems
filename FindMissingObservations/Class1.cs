namespace FindMissingObservations;

public class Solution
{
    public int[] MissingRolls(int[] rolls, int mean, int n)
    {
        int m = rolls.Length;
        int GoalMN = (m + n) * mean;

        int SumM = rolls.Sum();

        int minLimit = SumM + n;
        int maxLimit = SumM + n * 6;

        if ( minLimit<= GoalMN && GoalMN <= maxLimit)
        {
            int[] result = Enumerable.Repeat(1, n).ToArray();

            int rest = GoalMN - minLimit;

            for (int i = 0; i < n && rest > 0; i++)
            {
                var increment = Math.Min(rest, 5);
                result[i] += increment;
                rest -= increment;
            }

            return result;
        }
        else
        {
            return [];
        }
    }
}
