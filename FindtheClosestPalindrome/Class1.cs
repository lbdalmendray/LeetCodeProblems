using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FindtheClosestPalindrome
{
    public class Solution
    {
        public string NearestPalindromic(string n)
        {
            BigInteger nValue = BigInteger.Parse(n);
            if (nValue == 0)
                return 1.ToString();
            else if ( nValue <= 10)
            {
                return (nValue - 1).ToString();
            }
            else if( nValue == 11 )
            {
                return 9.ToString();
            }
            else if ( nValue <= 16 )
            {
                return 11.ToString();
            }
            else if ( nValue < 20 )
            {
                return 22.ToString();
            }
            else if ( nValue < 99)
            {
                if ( n[0] == n[1])
                {
                    return (nValue - 11).ToString();
                }
                else
                {
                    long nValueLong = (long)nValue;
                    LinkedList<long> values = new LinkedList<long>();
                    if (n[0] != '9')
                    {
                        values.AddLast( ((nValueLong / 10 )+1)*10 + ((nValueLong / 10)+1) );
                    }

                    values.AddLast(((nValueLong / 10)) * 10 + ((nValueLong / 10)));
                    values.AddLast(((nValueLong / 10) - 1) * 10 + ((nValueLong / 10) - 1));

                    long result = 0;
                    long delta = long.MaxValue;
                    foreach (var item in values)
                    {
                        long currentDelta = Math.Abs((long)(nValueLong - item));
                        if ( delta > currentDelta)
                        {
                            result = item;
                            delta = currentDelta;
                        }
                    }

                    return result.ToString();
                }
            }

            else if ( nValue == 99)
            {
                return 101.ToString();
            }
            else
            {
                BigInteger[] nines = new BigInteger[] { 9, 99, 999, 9999, 99999, 999999, 9999999, 99999999, 999999999, 9999999999, 99999999999, 999999999999, 9999999999999, 99999999999999, 999999999999999, 9999999999999999, 99999999999999999, 999999999999999999, 9999999999999999999 };
                BigInteger[] tenPotences = new BigInteger[] { 1, 10, 100, 1000, 10000, 100000, 1000000, 10000000, 100000000, 1000000000, 10000000000, 100000000000, 1000000000000, 10000000000000, 100000000000000, 1000000000000000, 10000000000000000, 100000000000000000, 1000000000000000000 };
                var result = NearestPalindromicAux(nValue, n.Length-1, nines, tenPotences, isPalindrome(n),0,0,true);
                return result.ToString();
            }
        }

        public bool isPalindrome(string n)
        {
            for (int i = 0; i < n.Length/2; i++)
            {
                if (n[i] != n[n.Length - 1 - i])
                    return false;
            }

            return true;
        }

        private BigInteger NearestPalindromicAux(BigInteger nValue, int lengthLessOne, BigInteger[] nines, BigInteger[] tenPotences, bool isPalindrome, BigInteger difference, int currentTenPotence , bool isFirst )
        {
            if (lengthLessOne == 0)
            {
                    BigInteger delta0 = 9999999999999999999;
                    BigInteger result0 = 0;

                    BigInteger currentDelta = tenPotences[currentTenPotence] + difference;

                    var nValuePrev = nValue - 1;

                    if (Abs(currentDelta) < Abs(delta0) && nValuePrev >= 0)
                    {
                        result0 = nValuePrev;
                        delta0 = currentDelta;
                    }

                    currentDelta = difference;
                    
                    if( Abs(currentDelta) < Abs(delta0) && !isPalindrome)
                    {
                        result0 = nValue;
                        delta0 = currentDelta;
                    }                   

                    var nValueNext = nValue + 1; 
                
                    currentDelta = (-1) * tenPotences[currentTenPotence] + difference;

                    if (Abs(currentDelta) < Abs(delta0) && nValueNext <= 9)
                    {
                        result0 = nValueNext;
                        //delta0 = currentDelta;
                    }                    

                    return result0;
            }
            else if ( lengthLessOne == 1 && isPalindrome)
            {
                if (nValue / 10 > 0)
                    return nValue - 11;
                else
                    return 11;
            }                
            else if (lengthLessOne < 0)
                return 0;

            BigInteger firstDigitValue = nValue / tenPotences[lengthLessOne];
            BigInteger lastDigitValue = nValue % 10;
            BigInteger UpperValue = firstDigitValue == 9 ? 10 * tenPotences[lengthLessOne] + 1 : (firstDigitValue + 1) * tenPotences[lengthLessOne] + firstDigitValue + 1;
            BigInteger LowerValue = firstDigitValue == 1 ? nines[lengthLessOne-1] + ( isFirst ? 0 :-9 ) :( firstDigitValue == 0 ? 0 : (firstDigitValue - 1) * tenPotences[lengthLessOne] + firstDigitValue - 1 + (lengthLessOne> 1 ? nines[lengthLessOne-1] - 9: 0));

            BigInteger SameValueFirstLast = firstDigitValue * tenPotences[lengthLessOne] + firstDigitValue;
            BigInteger currentDifference = firstDigitValue * tenPotences[lengthLessOne] + lastDigitValue - SameValueFirstLast;
            BigInteger SameValue = SameValueFirstLast + NearestPalindromicAux((nValue - firstDigitValue * tenPotences[lengthLessOne]) / 10, lengthLessOne - 2, nines, tenPotences, isPalindrome, currentDifference * tenPotences[currentTenPotence] + difference,currentTenPotence+1,false) *10;

            BigInteger delta = 9999999999999999999;
            BigInteger result = 0;

            BigInteger currentdelta = (nValue - LowerValue) * tenPotences[currentTenPotence] + difference;
            if (Abs(currentdelta) < Abs(delta) /*lengthLessOne>=1*/ && LowerValue > 9 /*Not could have one digit here*/ )
            {
                result = LowerValue;
                delta = currentdelta;
            }

            currentdelta = (nValue - SameValue) * tenPotences[currentTenPotence] + difference;

            if (Abs(currentdelta) < Abs(delta))
            {
                result = SameValue;
                delta = currentdelta;
            }

            currentdelta = (nValue - UpperValue ) * tenPotences[currentTenPotence] + difference;
            if ( Abs(currentdelta) < Abs(delta))
            {
                result = UpperValue;
                //delta = currentdelta;
            }            

            return result; 
        }
        private BigInteger Abs(BigInteger bigInteger)
        {
            if (bigInteger.Sign > 0)
                return bigInteger;
            return bigInteger * (-1);
        }
    }
}
