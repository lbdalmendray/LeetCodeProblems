using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumDistancetoTypeaWordUsingTwoFingers
{
    public class Solution
    {
        public int MinimumDistance(string word)
        {
            int[][] letterPositions = new int[27][];
            for (int i = 0; i < 26; i++)
            {
                int column = i % 6;
                int row = i / 6;

                letterPositions[i] = new int[] { row, column };
            }
            /// There are 26 possibilities of Letters for the First Hand
            /// Thre are 26 possibilities of Letters for the second Hand, but there is another possibility
            /// that is the second hand has not pressed any thing. Thats why 27 total possibilities . 
            /// Thre are word.Length possibilities to know what character has been pressed from left to right . 
            /// There are near 26*27*word.Length possibilities . 
            Info[,,] infos = new Info[26, 27, word.Length];

            int[] wordValues = word.Select(e => e - 'A').ToArray();

            /// The first letter of wordValues was pressed for the firstHand ( this is the same response value that if it would
            /// be pressed with the other hand) and the other Hand did not pressed any thing( thats why
            /// the value secondLetterIndex == 26) . 
            return MinimumDistance(wordValues, 1, wordValues[0], 26, infos, letterPositions);
        }

        private int MinimumDistance(int[] wordValues, int wordIndex, int firstLetterIndex, int secondLetterIndex, Info[,,] infos, int[][] letterPositions)
        {
            if (wordIndex == wordValues.Length)
            {
                return 0;
            }

            if (infos[firstLetterIndex, secondLetterIndex, wordIndex] != null)
                return infos[firstLetterIndex, secondLetterIndex, wordIndex].Result;
            /// Case : Press The new Letter ( wordValues[wordIndex] ) with the firstHand  
            int distance = Distance(letterPositions[firstLetterIndex], letterPositions[wordValues[wordIndex]]);
            distance += MinimumDistance(wordValues, wordIndex + 1, wordValues[wordIndex], secondLetterIndex, infos, letterPositions);
            Info info = new Info { Result = distance };
            
            /// Case : Press The new Letter ( wordValues[wordIndex] ) with the secondHand  
            distance = Distance(letterPositions[secondLetterIndex], letterPositions[wordValues[wordIndex]]);
            distance += MinimumDistance(wordValues, wordIndex + 1, firstLetterIndex , wordValues[wordIndex], infos, letterPositions);

            if (distance < info.Result)
                info.Result = distance;

            infos[firstLetterIndex, secondLetterIndex, wordIndex] = info;
            return info.Result;
        }

        private int Distance(int[] v1, int[] v2)
        {
            if (v1 == null) // This is the case when the hand has not pressed any thing yet . 
                return 0;
            return Math.Abs(v1[0] - v2[0]) + Math.Abs(v1[1] - v2[1]);
        }
    }

    internal class Info
    {
        public int Result { get; internal set; }
    }
}
