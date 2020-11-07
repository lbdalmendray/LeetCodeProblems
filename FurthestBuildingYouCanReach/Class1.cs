using System;
using System.Collections.Generic;
using System.Linq;

namespace FurthestBuildingYouCanReach
{
    public class Solution
    {
        public int FurthestBuilding(int[] heights, int bricks, int ladders)
        {
            int[] changes = new int[heights.Length];
            //changes[0] = heights[0];
            changes[0] = 0;
            for (int i = 1; i < heights.Length; i++)
            {
                changes[i] = heights[i] - heights[i - 1];
            }

            if (ladders >= heights.Length - 1)
                return heights.Length - 1;
            if ( ladders == 0)
            {
                for (int i = 0; i < changes.Length; i++)
                {
                    if (changes[i] > 0)
                        bricks -= changes[i];
                    if (bricks < 0)
                        return i - 1;
                }

                return changes.Length - 1;
            }            
            else
            {
                SortedDictionary<int,int> maxChanges = new SortedDictionary<int,int>();
                int maxChangeCount = 0;
                    int i = 0;
                for (; i < changes.Length; i++)
                {
                    if ( changes[i] > 0 )
                    {
                        if (maxChanges.TryGetValue(changes[i], out var value))
                        {
                            maxChanges[changes[i]]++;
                        }
                        else
                            maxChanges[changes[i]] = 1;

                        maxChangeCount++;
                        if (maxChangeCount == ladders)
                            break;
                    }                    
                }

                if (i == changes.Length)
                    return changes.Length - 1;

                for (int j = i + 1; j < changes.Length; j++)
                {
                    if ( changes[j] > 0 )
                    {
                        var keyValue = maxChanges.First();
                        var min = keyValue.Key;
                        if ( min >= changes[j])
                        {
                            bricks -= changes[j];
                            if (bricks < 0)
                                return j - 1;
                        }
                        else
                        {
                            var newValue = keyValue.Value - 1;
                            if (newValue == 0)
                                maxChanges.Remove(keyValue.Key);
                            else
                            {
                                maxChanges[keyValue.Key] = newValue;                                
                            }

                            bricks -= keyValue.Key;
                            if (bricks < 0)
                                return j - 1;
                            maxChanges.TryGetValue(changes[j], out var value1);
                            maxChanges[changes[j]] = value1 + 1;
                        }
                    }
                }

                return changes.Length - 1;
            }
        }
    }
}
