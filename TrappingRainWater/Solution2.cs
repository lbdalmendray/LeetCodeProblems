using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TrappingRainWater
{
    public class Solution2
    {
        /// <summary>
        /// Complexity Time = O(N)
        /// Complexity Space or Auxiliary Space = O(N) 
        /// IDEA : Think the height array as a continue math function;
        /// Think to calculate the differents local maximum peaks 
        /// After that it is just think to find the maximum of maximum local peaks 
        /// Now, Divide the problem going to right and other going to left .
        /// Think about going to right : (Left is the same) . With the maximum of maximum local peaks
        /// find the 2nd maximum of maximum of local peaks to the right part . With these two peaks , 
        /// calculate the water between them . Then do the same with the 2nd maximum of local peaks and
        /// next maximum to the right part to the this 2nd, and so on... 
        /// The Left is the same that the right . 
        /// Find Sequently 
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int Trap(int[] height)
        {
            if (height.Length == 0)
                return 0;
            /// FIND PEAKS LIKE A CONTINUE FUNCTION BASE ON MOUNTAIN PLATEUS ( MESETAS : SPANISH ) 
            int[][] peaks = FindMaxPeaks(height);
            if (peaks.Length <= 1)
                return 0;

            /// CALCULATING MAXPEAKS TO RIGHT AND TO LEFT 

            int[] maxPeaksIndexesToLeft = new int[peaks.Length];
            maxPeaksIndexesToLeft[0] = 0;
            for (int i = 1; i < peaks.Length; i++)
            {
                if (height[peaks[maxPeaksIndexesToLeft[i - 1]][0]] <= height[peaks[i][0]])
                    maxPeaksIndexesToLeft[i] = i;
                else
                    maxPeaksIndexesToLeft[i] = maxPeaksIndexesToLeft[i - 1];
            }

            int[] maxPeaksIndexesToRight = new int[peaks.Length];
            maxPeaksIndexesToRight[peaks.Length-1] = peaks.Length - 1;
            for (int i = peaks.Length - 2; i > -1 ; i--)
            {
                if (height[peaks[maxPeaksIndexesToRight[i + 1]][0]] <= height[peaks[i][0]])
                    maxPeaksIndexesToRight[i] = i;
                else
                    maxPeaksIndexesToRight[i] = maxPeaksIndexesToRight[i + 1];
            }


            ///

            LinkedList<int[]> problems = new LinkedList<int[]>();
            int maxPeakIndex;
            //maxPeakIndex = GetMaximumPeak(peaks, height, 0, peaks.Length-1);
            maxPeakIndex = maxPeaksIndexesToRight[0];

            /// LEFT PART 
            int from = 0; int to = maxPeakIndex - 1; int isRigthSide = 1;     
            problems.AddLast(new int[] { maxPeakIndex, from, to , isRigthSide });
            /// RIGHT PART
            from = maxPeakIndex + 1 ; to = peaks.Length - 1;  isRigthSide = 0;
            problems.AddLast(new int[] { maxPeakIndex, from, to, isRigthSide });

            int result = 0;

            while(problems.Count != 0)
            {
                int[] problem = problems.First.Value;
                problems.RemoveFirst();

                var maxPeakIndexP = problem[0];
                var fromP = problem[1];
                var toP = problem[2];
                var isRigthSideP = problem[3];
                if (fromP > toP)
                    continue;

                //maxPeakIndex = GetMaximumPeak(peaks, height, fromP, toP);
                //// FIND FIRSTHEIGHT TO CALCULTE WATER 
                
                if ( isRigthSideP == 1)
                {
                    maxPeakIndex = maxPeaksIndexesToLeft[toP];
                    int firstHeightIndexToUse = peaks[maxPeakIndexP][0];
                    int indexFromRight = peaks[maxPeakIndex][1];
                    for (int i = firstHeightIndexToUse - 1 ; i > indexFromRight; i--)
                    {
                        if (height[i] < height[indexFromRight])
                            break;
                        firstHeightIndexToUse = i;
                    }
                    result += CalculateWater(height, indexFromRight, firstHeightIndexToUse);
                    /////////////////

                    /// CREATING MORE PROBLEMS 
                    /// 
                    from = 0 ; to = maxPeakIndex - 1 ; isRigthSide = 1;
                    problems.AddLast(new int[] { maxPeakIndex, from, to, isRigthSide });
                }
                else
                {
                    maxPeakIndex = maxPeaksIndexesToRight[fromP];
                    int firstHeightIndexToUse = peaks[maxPeakIndexP][1];
                    int indexFromLeft = peaks[maxPeakIndex][0];

                    for (int i = firstHeightIndexToUse + 1; i < indexFromLeft; i++)
                    {
                        if (height[i] < height[indexFromLeft])
                            break;
                        firstHeightIndexToUse = i;
                    }
                    result += CalculateWater(height,firstHeightIndexToUse, indexFromLeft);

                    /////////////////

                    /// CREATING MORE PROBLEMS 
                    /// 
                    from = maxPeakIndex + 1; to = peaks.Length-1; isRigthSide = 0;
                    problems.AddLast(new int[] { maxPeakIndex, from, to, isRigthSide });
                }
            }

            return result;
        }

        public int CalculateWater(int [] height , int index1 , int index2)
        {
            int minHeight = Math.Min(height[index1], height[index2]);

            int result = 0;

            for (int i = index1+1; i < index2; i++)
            {
                result += minHeight - height[i];
            }

            return result;
        }

        private int GetMaximumPeak(int[][] peaks, int [] heigth, int index1, int index2)
        {
            int result = index1;
            int resultHeigth = heigth[peaks[index1][0]];
            for (int i = index1+1; i <= index2; i++)
            {
                int currentHeigth = heigth[peaks[i][0]];

                if( currentHeigth > resultHeigth)
                {
                    resultHeigth = currentHeigth;
                    result = i;
                }                
            }

            return result;
        }


        public int[][] FindMaxPeaks(int[] height)
        {
            LinkedList<int[]> result = new LinkedList<int[]>();

            bool goingUp = true;
            int lastValue = 0;
            LinkedList<int> equalRange = new LinkedList<int>();

            for (int i = 0; i < height.Length; i++)
            {
                int currentValue = height[i];

                if (currentValue == lastValue)
                {
                    if( goingUp) /// JUST MATTER WHEN GOING UP 
                        equalRange.AddLast(i);
                }
                else if (lastValue < currentValue)
                {
                    if (goingUp)
                    {
                        equalRange.Clear();
                        equalRange.AddLast(i);
                    }
                    else
                    {
                        equalRange.Clear();
                        equalRange.AddLast(i);
                        goingUp = true;
                    }
                }
                else
                {
                    if(goingUp) // THIS IS A PEAK 
                    {
                        goingUp = false;
                        result.AddLast(new int[] { equalRange.First.Value, equalRange.Last.Value });
                        equalRange.Clear();
                    }
                    else
                    {
                        equalRange.Clear();
                    }
                }
                lastValue = currentValue;
            }

            if (goingUp) /// THE LAST CASE COULD BE A PEAK IF IS GOING UP 
            {
                result.AddLast(new int[] { equalRange.First.Value, equalRange.Last.Value });
            }

            return result.ToArray();
        }
    }
}
