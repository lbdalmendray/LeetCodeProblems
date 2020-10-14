using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AsteroidCollision
{
    public class Solution
    {
        /*
         Problem(i,N-1) = 
        case1 : if(asteroids[i] < 0) -> Result = asteroids[i] + Problem(i+1,N-1)
        case2 : if(asteroids[i] == 0) -> Result = Problem(i+1,N-1)[0] < 0 -> Result = Problem(i+1,N-1)
                                      -> Result = Problem(i+1,N-1)[0] >=0 -> Result = asteroids[i] + Problem(i+1,N-1)
        case3 : if(asteroids[i] > 0 ) -> Result = Problem(i+1,N-1)[0] < 0 && Abs(asteroids[i]) == Abs(Problem(i+1,N-1)[0]) -> Result = Problem(i+1,N-1).EliminateFirstElement()
                                      -> Result = Problem(i+1,N-1)[0] < 0 && Abs(asteroids[i]) < Abs(Problem(i+1,N-1)[j]) j = 0,...,k-1  -> Result = Problem(i+1,N-1).EliminateFirstKElements() OR just asteroids[i]
                                      -> Result = Problem(i+1,N-1)[0] > 0 -> Result = asteroids[i] + Problem(i+1,N-1)
                                      -> Result = Problem(i+1,N-1)[0] == 0 -> Result = asteroids[i] + Problem(i+1,N-1).EliminateFirstElement()
         */
        public int[] AsteroidCollision(int[] asteroids)
        {
            LinkedList<int> list = new LinkedList<int>();

            list.AddFirst(asteroids[asteroids.Length - 1]);

            for (int i = asteroids.Length - 2 ; i > -1 ; i--)
            {
                if (asteroids[i] == 0)
                {
                    if (list.Count != 0)
                    {
                        if (list.First.Value >= 0)
                        {
                            list.AddFirst(asteroids[i]);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        list.AddFirst(asteroids[i]);
                    }    
                }
                else if ( asteroids[i] < 0)
                {
                    list.AddFirst(asteroids[i]);
                }
                else // asteroids[i] > 0 
                {
                    while(list.Count != 0 && list.First.Value <= 0 && Math.Abs(asteroids[i]) > Math.Abs( list.First.Value )  )
                    {
                        list.RemoveFirst();
                    }

                    if( list.Count != 0 )
                    {
                        if (list.First.Value <= 0)
                        {
                            if (Math.Abs(asteroids[i]) == Math.Abs(list.First.Value))
                            {
                                list.RemoveFirst();
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            list.AddFirst(asteroids[i]);
                        }
                    }
                    else
                    {
                        list.AddFirst(asteroids[i]);
                    }
                }
            }

            return list.ToArray();
        }
    }

    
}
