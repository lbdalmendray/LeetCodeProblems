using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsecutiveNumbersSum
{
    /*
            if there is a set of Consecutive Numbers that Sum N : n1 , n2 , n3 , ..., nk 
            N = n1 + ... + nk 

            then we can say that : n1 = a + 1 with "a" is a number 
            then N = n1 + ... + nk = (a + 1 ) + (a + 2 ) + ... + (a + k )
            N = a + ... + a   +  1 + .... + k
            N = a*k + sum(1,k)
            N - sum ( 1, k) = a*k
            (N- sum(1,k))/k = a
            
            If there is a set of "k" consecutive Numbers that sum N <=> "a" is an integer.

            if we try for all the k values from 1 to the infinite , which is the greatest
            possible k value ? If we calculate a upper constraint for k we could say that 
            if N = 10^9 then if k = 10^5 then k is greatest than the maximum possible k value.
            
            Demo: sum ( 1, k) = k*(k+1)/2  => k = 10^5 => sum(1,10^5) = 10^5*(10^5+1 )/2 >= 10^10/2
            10^10/2 = (10/2)*10^9 = 5*10^9 >= 10^9 
            Then we can calculate all the possible value of k in an acceptable time with current computer power .              
            This solution is O(sqrt(N)) . 
            kMin is the first k that Sum(1,kMin) >= N => sum(1,kMin) = kMin(kMin+1)/2 >= N
            sqrt(N) >= kMin why ? Because kMin(kMin+1)/2 >=N => kMin^2 + kMin >= 2N
            A value that is greater that kMin is sqrt(2)*sqrt(N)
            (sqrt(2)*sqrt(N))^2 + sqrt(2)*sqrt(N) >= kMin^2 + kMin >= 2N
            => 2*N + sqrt(2)*sqrt(N) >= kMin^2 + kMin = 2N
            => O(sqrt(2)*sqrt(N)) 
            => O(sqrt(N))
             
            
         */
    public class Solution
    {
        public int ConsecutiveNumbersSum(int N)
        {
            int result = 0;
            
            for (int k = 1, sumK = 1; sumK <= N ; k++ , sumK += k)
            {
                if ((N - sumK) % k == 0)
                    result++;
            }

            return result;
        }
    }
}
