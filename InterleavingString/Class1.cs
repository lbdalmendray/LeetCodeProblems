using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterleavingString
{
    public class Solution
    {
        public bool IsInterleave(string s1, string s2, string s3)
        {
            if (s1 == "")
                return s2 == s3;
            if (s2 == "")
                return s1 == s3;

            if (s1.Length + s2.Length != s3.Length)
                return false;

            Dictionary<char, int[]> dictionaryList = GenerateDictionaryList(s3);

            Dictionary<char,int> dictCount = CreateDictCount(dictionaryList);
            
            if( !Count(dictCount,s1,s2))
            {
                return false;
            }

            Dictionary<char, int[]> forwards = null;

            if(dictionaryList.Count * s3.Length < 10000000 )
            {
                forwards = CreateFowards(s3, dictionaryList);
            }

            Dictionary<int, bool>[] s1S3infos = new Dictionary<int, bool>[s1.Length];
            for (int i = 0; i < s1S3infos.Length; i++)
            {
                s1S3infos[i] = new Dictionary<int, bool>();
            }

            Dictionary<int, Dictionary<int,bool>>[] s2S3infos = new Dictionary<int, Dictionary<int, bool>>[s2.Length];
            for (int i = 0; i < s2S3infos.Length; i++)
            {
                s2S3infos[i] = new Dictionary<int, Dictionary<int, bool>>();
            }

            int commonS2S3SufixCount = 0;
            for (int i = 0; i< s2.Length && i<s3.Length ; i++)
            {
                if (s2[s2.Length - 1 - i] != s3[s3.Length - 1 - i])
                    break;
                commonS2S3SufixCount++;
            }

            for (int j = s1.Length-1; j > 0; j--)
            {
                var s1_j_array = dictionaryList[s1[j]];
                bool AllS3PrefixIndexVerifiedJ = true;
                bool isNotOutOfMemoryJ = true;
                for (int i = 0; i < s1_j_array.Length; i++)
                {
                     if (!AllS3PrefixIndexVerifiedJ)
                        break;
                    IsInterleave(ref isNotOutOfMemoryJ, j, s1_j_array[i], i, false, 0, 0, s1S3infos, dictionaryList, s1, s2, s3, commonS2S3SufixCount, out AllS3PrefixIndexVerifiedJ, forwards, s2S3infos);
                }
            }
            var s1_0_array = dictionaryList[s1[0]];
            bool AllS3PrefixIndexVerified = true;
            bool isNotOutOfMemory = true;
            for (int i = 0; i < s1_0_array.Length; i++)
            {
                if (!AllS3PrefixIndexVerified)
                    return false;
                if (IsInterleave(ref isNotOutOfMemory, 0, s1_0_array[i], i, false, 0,0, s1S3infos, dictionaryList , s1, s2, s3, commonS2S3SufixCount,out AllS3PrefixIndexVerified, forwards,s2S3infos))
                    return true;
            }

            return false;
        }

        private Dictionary<char, int[]> CreateFowards(string s3, Dictionary<char, int[]> dictionaryList)
        {
            Dictionary<char, int[]> result = new Dictionary<char, int[]>(dictionaryList.Count);
            foreach (var keyValue in dictionaryList)
            {
                var currentArray = new int[s3.Length];
                int index = 0;
                for (int i = 0; i < keyValue.Value.Length; i++)
                {
                    for (; index <= keyValue.Value[i]; index++)
                    {
                        currentArray[index] = i;
                    }
                }
                for (int i = index; i <s3.Length; i++)
                {
                    currentArray[i] = -1;
                }
                result.Add(keyValue.Key, currentArray);
            }
            return result;
        }

        private bool IsInterleave(ref bool isNotOutOfMemory, int s1Index, int s3Index, int dictionaryList_s1_s1Index_Index, bool verifyIndexes, int lastS3IndexNotVerified, int lastS2IndexNotVerified, Dictionary<int, bool>[] s1S3infos, Dictionary<char, int[]> dictionaryList, string s1, string s2, string s3, int commonS2S3SufixCount, out bool AllS3PrefixIndexVerified, Dictionary<char, int[]> forwards, Dictionary<int, Dictionary<int, bool>>[] s2S3infos)
        {
            AllS3PrefixIndexVerified = true;
            if (verifyIndexes)
            {
                if (lastS2IndexNotVerified + (s3Index - lastS3IndexNotVerified) - 1 < s2.Length)
                {
                    if (isNotOutOfMemory  && s2S3infos[lastS2IndexNotVerified].TryGetValue(lastS3IndexNotVerified, out var resultDict) && resultDict.TryGetValue(s3Index - lastS3IndexNotVerified,out AllS3PrefixIndexVerified))
                    {
                        if (!AllS3PrefixIndexVerified)
                            return false;
                    }
                    else
                    {
                        if (isNotOutOfMemory)
                        {
                            try
                            {
                                AllS3PrefixIndexVerified = Calculate(lastS2IndexNotVerified, lastS3IndexNotVerified, s3Index - lastS3IndexNotVerified, s2S3infos, s2, s3);
                                if (!AllS3PrefixIndexVerified)
                                    return false;
                            }
                            catch(System.OutOfMemoryException)
                            {
                                isNotOutOfMemory = false;
                                FreeMemory(s2S3infos);
                                for (int i = lastS3IndexNotVerified, j = lastS2IndexNotVerified; i < s3Index; i++, j++)
                                {
                                    if (s2[j] != s3[i])
                                    {
                                        AllS3PrefixIndexVerified = false;
                                        return false;
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int i = lastS3IndexNotVerified, j = lastS2IndexNotVerified; i < s3Index; i++, j++)
                            {
                                if (s2[j] != s3[i])
                                {
                                    AllS3PrefixIndexVerified = false;
                                    return false;
                                }
                            }
                        }
                    }
                }
                else
                {
                    AllS3PrefixIndexVerified = false;
                    
                    return false;
                }
            }

            if (isNotOutOfMemory && s1S3infos[s1Index].TryGetValue(s3Index, out bool result1))
            {
                //AllS3PrefixIndexVerified = result1;
                return result1;
            } 

            if (s1Index < s1.Length - 1)
            {
                if (forwards!=null && GetNext(s3Index + 1, forwards[s1[s1Index + 1]], out int firstIndex)  ||  BinarySearch(s3Index+1, dictionaryList[s1[s1Index + 1]], out  firstIndex))
                {
                    var s1_s1IndexPlus1_array = dictionaryList[s1[s1Index + 1]];
                    bool AllS3PrefixIndexVerifiedLevel2 = true;

                    for (int i = firstIndex; i < s1_s1IndexPlus1_array.Length; i++)
                    {
                        if (!AllS3PrefixIndexVerifiedLevel2)
                        {
                            if (isNotOutOfMemory)
                                s1S3infos[s1Index].Add(s3Index, false);
                            return false;
                        }
                        
                        var s2IndexToVerify = (s3Index - s1Index) ;  
                        try
                        {
                            if (IsInterleave(ref isNotOutOfMemory, s1Index + 1, s1_s1IndexPlus1_array[i], i, s3Index + 1 < s1_s1IndexPlus1_array[i] && s2IndexToVerify > -1, s3Index + 1, s2IndexToVerify, s1S3infos, dictionaryList, s1, s2, s3, commonS2S3SufixCount, out AllS3PrefixIndexVerifiedLevel2, forwards,s2S3infos))
                            {
                                if (isNotOutOfMemory)
                                    s1S3infos[s1Index].Add(s3Index, true);
                                return true;
                            }
                        }
                        catch (System.OutOfMemoryException)
                        {
                            isNotOutOfMemory = false;
                            FreeMemory(s1S3infos);
                            if (IsInterleave(ref isNotOutOfMemory, s1Index + 1, s1_s1IndexPlus1_array[i], i, s3Index + 1 < s1_s1IndexPlus1_array[i] && s2IndexToVerify > -1, s3Index + 1, s2IndexToVerify, s1S3infos, dictionaryList, s1, s2, s3, commonS2S3SufixCount, out AllS3PrefixIndexVerifiedLevel2, forwards, s2S3infos))
                            {
                                if (isNotOutOfMemory)
                                    s1S3infos[s1Index].Add(s3Index, true);
                                return true;
                            }
                        }
                        
                    }
                    if (isNotOutOfMemory)
                        s1S3infos[s1Index].Add(s3Index, false);
                    return false;
                }
                else
                {
                    if (isNotOutOfMemory)
                        s1S3infos[s1Index].Add(s3Index, false);
                    return false;
                }
            }

            var result = commonS2S3SufixCount >= s2.Length - (s3Index - s1Index);
            if (isNotOutOfMemory)
                s1S3infos[s1Index].Add(s3Index, result);
            return result;
        }

        private void FreeMemory(Dictionary<int, Dictionary<int, bool>>[] s2S3infos)
        {
            for (int i = 0; i < s2S3infos.Length; i++)
            {
                s2S3infos[i] = null;
            }
        }



        private bool Calculate(int s2Index, int s3Index, int length, Dictionary<int, Dictionary<int, bool>>[] s2S3infos, string s2, string s3)
        {
            if(!s2S3infos[s2Index].TryGetValue(s3Index, out Dictionary<int, bool>  resultDict))
            {
                resultDict = new Dictionary<int, bool>();
                s2S3infos[s2Index].Add(s3Index, resultDict);
            }

            if (resultDict.TryGetValue(length, out bool AllS3PrefixIndexVerified) )
            {
                return AllS3PrefixIndexVerified;
            }
            var result = s2[s2Index] == s3[s3Index];
            if(result && length > 1)
                result = Calculate(s2Index + 1, s3Index + 1, length - 1, s2S3infos, s2, s3);
            resultDict[length] = result;
            return result;
        }

        private void FreeMemory(Dictionary<int, bool>[] s1S3infos)
        {
            for (int i = 0; i < s1S3infos.Length; i++)
            {
                s1S3infos[i] = null;
            }
        }

        private bool GetNext(int index, int[] fowardArrayIndexes, out int firstIndex)
        {
            firstIndex = index < fowardArrayIndexes.Length ? fowardArrayIndexes[index] : -1;
            return firstIndex != -1;
        }

        private bool BinarySearch(int value, int[] array, out int firstIndex)
        {
            if (array == null || array.Length == 0)
            {
                firstIndex = -1;
                return false;
            }
            return BinarySearch(value, array, 0, array.Length - 1, out firstIndex);
        }
        private bool BinarySearch(int value, int [] array,int index1, int index2, out int firstIndex)
        {
            if ( index1 == index2)
            {
                if (array[index1] >= value)
                {
                    firstIndex = index1;
                    return true;
                }
                firstIndex = -1;
                return false;
            }
            
            int medIndex = (index2 + index1) / 2;
            if ( array[medIndex] < value )
            {
                return BinarySearch(value, array, medIndex + 1, index2, out firstIndex);
            }
            else
            {
                return BinarySearch(value, array, index1, medIndex, out firstIndex);
            }
        }

        private bool Count(Dictionary<char, int> dictCount, string s1, string s2)
        {
            if (!Count(dictCount, s1))
                return false;
            if (!Count(dictCount, s2))
                return false;
            return true;
        }

        private bool Count(Dictionary<char, int> dictCount, string s1)
        {
            for (int i = 0; i < s1.Length; i++)
            {
                if (dictCount.TryGetValue(s1[i], out int value))
                {
                    if (value == 1)
                        dictCount.Remove(s1[i]);
                    else
                        dictCount[s1[i]]--;
                }
                else
                    return false;
            }
            return true;
        }

        private Dictionary<char, int> CreateDictCount(Dictionary<char, int[]> dictionaryList)
        {
            Dictionary<char, int> result = new Dictionary<char, int>(dictionaryList.Count);
            foreach (var item in dictionaryList)
            {
                result.Add(item.Key, item.Value.Count());
            }

            return result;
        }

        private Dictionary<char, int[]> GenerateDictionaryList(string stringValue)
        {
            Dictionary<char, LinkedList<int>> dictionary = new Dictionary<char, LinkedList<int>>(26);

            for (int i = 0; i < stringValue.Length; i++)
            {
                if( !dictionary.ContainsKey(stringValue[i]))
                {
                    dictionary.Add(stringValue[i], new LinkedList<int>());
                }

                dictionary[stringValue[i]].AddLast(i);
            }

            var result = new Dictionary<char, int[]>();

            foreach (var item in dictionary)
            {
                result.Add(item.Key, item.Value.ToArray());
            }

            return result;
        }
    }
}
