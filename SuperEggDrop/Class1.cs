using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperEggDrop
{
    public class Solution
    {
        /// <summary>
        /// O( K*N*Log(N) )
        /// </summary>
        /// <param name="K"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public int SuperEggDrop(int K, int N)
        {
            int?[,] infos = new int?[14+1, 10002];
            int NPlus1 = N + 1;
            int[] potences = CreatePotence(NPlus1);
            
            for (int i = 2; i <= NPlus1 ; i++)
            {
                infos[1, i] = i - 1;
            }

            for (int i = 2; i <= NPlus1; i++)
            {
                infos[potences[i], i] = potences[i];
            }

            return SuperEggDrop(K, NPlus1, infos,potences);
        }
        private int SuperEggDrop(int K, int N, int?[,] infos, int[] potences)
        {
            if (K > potences[N])
                return SuperEggDrop(potences[N], N, infos, potences);

            if (infos[K, N].HasValue)
                return infos[K, N].Value;

            int half = N / 2;

            int result = SuperEggDrop(K, half, infos, potences);
            var result2 = SuperEggDrop(K - 1, N - half, infos, potences);
            if (result < result2)
            {
                int NLess2 = N - 2;
                int getMinResult = GetInvertValueVertexBinarySearch( half, NLess2, K , N, infos, potences);
                if (getMinResult != -1)
                {
                    result = Math.Min(result2, getMinResult);
                }
                else
                {
                    result = SuperEggDrop(K - 1, N - NLess2, infos, potences);
                }
            }
            result++;
            infos[K, N] = result;
            return result;
        }
        private int GetInvertValueVertexBinarySearch(int firstValue, int lastValue, int K, int N, int?[,] infos, int[] potences)
        {
            while(lastValue - firstValue > 1)
            {
                int sum = firstValue + lastValue;
                bool isEven = sum % 2 == 0;
                int mid = (sum) / 2 + (isEven ? 0 : -1);

                int result = SuperEggDrop(K, mid, infos, potences);
                var result2 = SuperEggDrop(K - 1, N - mid, infos, potences);

                if ( result > result2)
                {
                    lastValue = mid;
                }
                else
                {
                    firstValue = mid + 1;
                }
            }

            if(lastValue - firstValue == 0)
            {
                int cResult = SuperEggDrop(K, lastValue, infos, potences);
                var cResult2 = SuperEggDrop(K - 1, N - lastValue, infos, potences);

                if (cResult > cResult2)
                {
                    if (lastValue > 2)
                    {
                       cResult = Math.Min ( cResult , GetMax(lastValue - 1, K, N, infos, potences));
                    }
                    if (lastValue < N-2)
                    {
                        cResult = Math.Min(cResult, GetMax(lastValue + 1, K, N, infos, potences));
                    }
                    return cResult;
                }
                else
                    return -1;
            }
            else
            {
                int result11 = SuperEggDrop(K, firstValue, infos, potences);
                var result12 = SuperEggDrop(K - 1, N - firstValue, infos, potences);
                var max1 = Math.Max(result11, result12);

                int result21 = SuperEggDrop(K, lastValue, infos, potences);
                var result22 = SuperEggDrop(K - 1, N - lastValue, infos, potences);
                var max2 = Math.Max(result21, result22);

                int minR = max1 < max2 ? max1 : max2;

                if ( result11 > result12 )
                {
                    if (firstValue == 1)
                    {
                        return minR;
                    }
                    else
                    {
                        var max3 = GetMax(firstValue - 1, K, N, infos, potences);
                        return max3 < minR ? max3 : minR;
                    }
                }
                else if (result21 > result22)
                {
                    if(lastValue + 1 > N -2 )
                    {
                        return minR;
                    }

                    var max3 = GetMax(lastValue + 1, K, N, infos, potences);
                    return max3 < minR ? max3 : minR;
                }
                else
                {
                    return -1;
                }
            }
        }
        private int GetMax(int value, int K, int N , int?[,] infos, int[] potences)
        {
            int result = SuperEggDrop(K, value, infos, potences);
            var result2 = SuperEggDrop(K - 1, N - value, infos, potences);
            var max = Math.Max(result, result2);

            return max;
        }
        private int SuperEggDrop1(int K, int N, int?[,] infos, int[] potences)
        {
            if (K > potences[N])
                return SuperEggDrop1(potences[N], N, infos, potences);

            if (infos[K, N].HasValue)
                return infos[K, N].Value;

            int half =  N / 2;

            int result = SuperEggDrop1(K, half, infos, potences);
            var result2 = SuperEggDrop1(K-1, N - half, infos, potences);
            if (result < result2)
            {
                result = result2;
                int NLess2 = N - 2;
                for (int i = half + 1; i <= NLess2; i++)
                {
                    var cResult = SuperEggDrop1(K, i, infos, potences);
                    var cResult2 =  SuperEggDrop1(K - 1, N - i, infos, potences);
                    if( cResult >= cResult2)
                    {
                        result = Math.Min(cResult,result);
                        break;
                    }
                    else
                        result = Math.Min(cResult2, result);
                }
            }
            result ++;
            infos[K, N] = result;
            return result;
        }
        private int[] CreatePotence(int N)
        {
            int[] result = new int[N+1];
            int pow = 2;
            int pow2 = 4;
            int potenceIndex = 2;
            result[2] = 1;

            while (pow < N)
            {
                int maxNumber = Math.Min(N, pow2);
                for (int i = pow+1; i <= maxNumber; i++)
                {
                    result[i] = potenceIndex;
                }
                pow  *= 2;
                pow2 *= 2;
                potenceIndex++;
            }

            return result;
        }
    }
}
