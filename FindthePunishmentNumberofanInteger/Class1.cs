namespace FindthePunishmentNumberofanInteger
{
    public class Solution
    {
        public int PunishmentNumber(int n)
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