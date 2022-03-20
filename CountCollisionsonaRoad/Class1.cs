using System;

namespace CountCollisionsonaRoad
{

    public class Solution
    {
        public int CountCollisions(string directions)
        {
            int result = 0;
            int firstNotLeft = 0;

            for (; firstNotLeft < directions.Length; firstNotLeft++)
            {
                if ( directions[firstNotLeft] != 'L')
                {
                    break;
                }
            }

            for (int i = firstNotLeft; i < directions.Length; i++)
            {
                if (directions[i] == 'R')
                {
                    for (int j = i + 1; j < directions.Length; j++)
                    {
                        if (directions[j] != 'R')
                        {
                            if (directions[j] == 'L')
                            {
                                result += 2 + (j - 1 - i);
                            }
                            else
                            {
                                result += (j - i);
                            }
                            i = j;
                            break;
                        }
                    }
                }
                else if (directions[i] == 'L')
                {
                    result += 1;
                    //if (directions[i - 1] == 'L')
                    //{
                    //    result += 1;
                    //}
                    //else if (directions[j] != 'R') // will not happpend
                    //{
                    //
                    //}
                    //else // directions[j] != 'S'
                    //{
                    //    result += 1;
                    //}
                }
                //else if ( directions[i] == 'S') // do nothing
                //{
                //
                //}
            }

            return result;
        }
    }

}

