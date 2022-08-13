using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace StringTransformsIntoAnotherString
{
    public class Solution
    {
        public bool CanConvert(string str1, string str2)
        {
            if (str1.Length != str2.Length)
                return false;
            else
            {
                Dictionary<char, char> charRelation = new Dictionary<char, char>();
                //// CHECK SAME STR1 CHAR VALUES RELATION WITH STR2 IS UNIQUE
                for (int i = 0; i < str1.Length; i++)
                {
                    if (charRelation.TryGetValue(str1[i], out var str2Value))
                    {
                        if (str2Value != str2[i]) /// the same str1 value has two different str2 value related 
                            return false;
                    }
                    else
                    {
                        charRelation[str1[i]] = str2[i];
                    }
                }

                //////////////////////////////////////////////////////////////

                ///// NO ONE STR1 VALUE HAS TWO DIFFERENT STR2 VALUES //// 

                //// MERGE ALL DIFFERENT STR1 VALUES(STR1EQUALlIST) WITH THE SAME STR2 VALUE INTO 
                //// JUST ONE OF THAT STR1 VALUES PRIORITIZING THE SAME STR2 VALUE
                //// IF EXISTS IN THE SAME STR1EQUALIST
                Dictionary<char, char> inverseUnionRelation = new Dictionary<char, char>();
                foreach (var keyValue in charRelation)
                {
                    if (inverseUnionRelation.TryGetValue(keyValue.Value, out var relateValue))
                    {
                        if( relateValue != keyValue.Key)
                        {
                            /// THIS MEAN THAT I WILL JOIN TWO STR1 groups that have the same 
                            /// STR2 related value. 
                            /// Then I will have an extra letter outside the letters used to 
                            /// do all the swapping letter I need
                            return true;
                        }
                    }
                    else
                    {
                        inverseUnionRelation[keyValue.Value] = keyValue.Key;
                    }
                }

                //// AFTERT THE MERGING 
                if (inverseUnionRelation.Count < 26)
                {
                    /// IT DOES NOT HAVE ALL THE LETTER AT THE SAME TIME
                    /// BECAUSE WE CAN USE AN OUTSIDE LETTER FROM THE INVERSEUNIONRELATION
                    /// AND USE IT TO SWAP LETTERS BETWEEN DIFFERENT STR1 VALUES DIFFERENT 
                    /// MERGING GROUPS
                    return true;
                }
                else
                {
                    if (inverseUnionRelation.All(e => e.Key == e.Value))
                    {
                        //// ALL THE STR1 VALUE HAS THE SAME STR2 VALUE IN THE SAME POSITION
                        return true;
                    }
                    else
                    {
                        /// ALL THE STR1 VALUE DOES NOT HAVE THE SAME STR2 VALUE IN THE SAME POSITION
                        return false;
                    }
                }
            }
        }

        public bool CanConvert1(string str1, string str2)
        {
            if (str1.Length != str2.Length)
                return false;
            else
            {
                Dictionary<char, char> charRelation = new Dictionary<char, char>();
                //// CHECK SAME STR1 CHAR VALUES RELATION WITH STR2 IS UNIQUE
                for (int i = 0; i < str1.Length; i++)
                {
                    if(charRelation.TryGetValue(str1[i], out var str2Value ))
                    {
                        if (str2Value != str2[i]) /// the same str1 value has two different str2 value related 
                            return false;
                    }
                    else
                    {
                        charRelation[str1[i]] = str2[i];
                    }
                }

                //////////////////////////////////////////////////////////////

                ///// NO ONE STR1 VALUE HAS TWO DIFFERENT STR2 VALUES //// 

                //// MERGE ALL DIFFERENT STR1 VALUES(STR1EQUALlIST) WITH THE SAME STR2 VALUE INTO 
                //// JUST ONE OF THAT STR1 VALUES PRIORITIZING THE SAME STR2 VALUE
                //// IF EXISTS IN THE SAME STR1EQUALIST
                Dictionary<char, char> inverseUnionRelation = new Dictionary<char, char>();
                foreach (var keyValue in charRelation)
                {
                    if(inverseUnionRelation.TryGetValue(keyValue.Value, out var relateValue))
                    {
                        if (keyValue.Key == keyValue.Value)
                            inverseUnionRelation[keyValue.Value] = keyValue.Value;
                    }
                    else
                    {
                        inverseUnionRelation[keyValue.Value] = keyValue.Key;
                    }
                }

                //// AFTERT THE MERGING 
                if (inverseUnionRelation.Count < 26)
                {
                    /// IT DOES NOT HAVE ALL THE LETTER AT THE SAME TIME
                    /// BECAUSE WE CAN USE AN OUTSIDE LETTER FROM THE INVERSEUNIONRELATION
                    /// AND USE IT TO SWAP LETTERS BETWEEN DIFFERENT STR1 VALUES DIFFERENT 
                    /// MERGING GROUPS
                    return true;
                }
                else
                {
                    if (inverseUnionRelation.All(e => e.Key == e.Value))
                    {
                        //// ALL THE STR1 VALUE HAS THE SAME STR2 VALUE IN THE SAME POSITION
                        return true;
                    }
                    else
                    {
                        /// ALL THE STR1 VALUE DOES NOT HAVE THE SAME STR2 VALUE IN THE SAME POSITION
                        return false;
                    }
                }
            }
        }
    }
}
