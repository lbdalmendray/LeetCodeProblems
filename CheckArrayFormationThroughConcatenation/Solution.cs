using System;
using System.Collections.Generic;

namespace CheckArrayFormationThroughConcatenation
{
    public class Solution
    {
        public bool CanFormArray(int[] arr, int[][] pieces)
        {
            Dictionary<int, int> valuePositions = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                valuePositions.Add(arr[i], i);
            }

            for (int i = 0; i < pieces.Length; i++)
            {
                if (valuePositions.TryGetValue(pieces[i][0], out var position))
                {
                    if (position + pieces[i].Length > arr.Length)
                        return false;

                    for (int k = 1; k < pieces[i].Length; k++)
                    {
                        if (arr[k + position] != pieces[i][k])
                            return false;
                    }
                }
                else
                    return false;
            }

            return true;
        }
    }
}
