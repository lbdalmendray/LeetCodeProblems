namespace MinimumAdjacentSwapstoMakeaValidArray;

public class Solution
{
    public int MinimumSwaps(int[] nums)
    {
        int minIndex = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] < nums[minIndex])
            {
                minIndex = i;
            }
        }

        int maxIndex = nums.Length - 1;
        for (int i = nums.Length - 2; i > -1; i--)
        {
            if (nums[i] > nums[maxIndex])
            {
                maxIndex = i;
            }
        }

        if (minIndex == maxIndex)
            return 0;
        if ( minIndex < maxIndex)
            return (nums.Length - 1 - maxIndex) + ( minIndex); 
        else
            return (nums.Length - 1 - maxIndex) + (minIndex) - 1;
    }
}
