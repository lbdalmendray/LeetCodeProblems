namespace FindthePunishmentNumberofanInteger
{
    public class Solution
    {
        /// <summary>
        /// Solution2
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int PunishmentNumber(int n)
        {
            var numberSumList = new (int number, int sum)[]
            {
                (1,1), (9,82), (10,182), (36,1478), (45,3503), (55,6528), (82,13252), (91,21533), (99,31334), (100,41334), (235,96559), (297,184768), (369,320929), (370,457829), (379,601470), (414,772866), (657,1204515), (675,1660140), (703,2154349), (756,2725885), (792,3353149), (909,4179430), (918,5022154), (945,5915179), (964,6844475), (990,7824575), (991,8806656), (999,9804657), (1000,10804657)
            };

            int resultIndex = BinarySearch(numberSumList, n);
            if (resultIndex == -1)
                return 0;
            else
            {
                int result = numberSumList[resultIndex].sum;
                return result;
            }
        }

        private int BinarySearch((int number, int sum)[] numberSumList, int n)
        {
            int index1 = 0;
            int index2 = numberSumList.Length - 1;
            while( index2 - index1 > 3 )
            {
                int mid = (index2 + index1) / 2;
                if ( numberSumList[ mid].number > n )
                {
                    index2 = mid - 1;
                }
                else if (numberSumList[mid].number < n )
                {
                    index1 = mid;
                }
                else
                {
                    return mid;
                }
            }

            for (int i = index2; i > -1; i--)
            {
                if (numberSumList[i].number <= n)
                    return i;
            }

            return -1;
        }

        /// <summary>
        /// Solution1
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int PunishmentNumber1(int n)
        {
            var numberSqrtList = new (int number, int sqrt)[]
            {
                (1,1), (9,81), (10,100), (36,1296), (45,2025), (55,3025), (82,6724), (91,8281), (99,9801), (100,10000), (235,55225), (297,88209), (369,136161), (370,136900), (379,143641), (414,171396), (657,431649), (675,455625), (703,494209), (756,571536), (792,627264), (909,826281), (918,842724), (945,893025), (964,929296), (990,980100), (991,982081), (999,998001), (1000,1000000)
            };

            int result = 0;

            for (int i = 0; i < numberSqrtList.Length; i++)
            {
                if (numberSqrtList[i].number <= n)
                    result += numberSqrtList[i].sqrt;
                else
                    break;
            }

            return result;
        }



        public static void FindSqrtNumberLessThan1000()
        {
            Console.Write("(1,1)");

            for (int i = 2; i <= 1000; i++)
            {
                int sqrt = i * i;
                if (Condition(sqrt, i))
                {
                    Console.Write($", ({i},{sqrt})");
                }
            }
        }

        public static void FindSumLessThan1000()
        {
            Console.Write("(1,1)");
            int sum = 1;
            for (int i = 2; i <= 1000; i++)
            {
                int sqrt = i * i;
                if (Condition(sqrt, i))
                {
                    sum += sqrt;
                    Console.Write($", ({i},{sum})");
                }
            }
        }

        private static bool Condition(int bigNumberToString, int number)
        {
            if (bigNumberToString == number)
                return true;
            else
            {
                string bigNumbString = bigNumberToString.ToString();
                for (int i = 0; i < bigNumbString.Length - 1; i++)
                {
                    var partString = bigNumbString.Substring(0, i + 1);
                    int partNumber = int.Parse(partString);
                    var part2String = bigNumbString.Substring(i + 1);
                    int partNumber2 = int.Parse(part2String);

                    if (partString.Length == bigNumbString.Length - 1)
                    {
                        return number == partNumber + partNumber2;
                    }
                    else if (number < partNumber)
                    {
                        return false;
                    }
                    else if (Condition(partNumber2, number - partNumber))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}