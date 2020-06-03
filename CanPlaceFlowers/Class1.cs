using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanPlaceFlowers
{
    public class Solution
    {
        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            if (n == 0)
                return true;

            for (int i = 0; i < flowerbed.Length ; i++)
            {
                if (flowerbed[i] == 0)
                {
                    if (i < flowerbed.Length - 1)
                    {
                        if (flowerbed[i + 1] == 0)
                        {
                            n--;
                            if (n == 0)
                                return true;
                            i++;
                        }
                    }
                    else
                    {
                        n--;
                        if (n == 0)
                            return true;
                        break;
                    }
                }
                else
                    i++;
            }

            return false;
        }
    }
}
