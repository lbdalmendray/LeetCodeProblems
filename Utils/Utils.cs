using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class Utils
    {
        public static void Do<T>(this T[] array, Action<T> action)
        {
            foreach (var element in array)
            {
                action(element);
            }
        }
        static public IEnumerable<int[]> GeneratePermutations(int length)
        {
            if (length == 0 || length < 1)
            {
                yield return new int[0];
            }
            else
            {
                yield return Enumerable.Range(0, length).ToArray();
                int[] result = Enumerable.Range(0, length).ToArray();
                bool[] selected = Enumerable.Repeat(true, length).ToArray();
                int count = Factorial(length) - 1;
                for (int i = 0; i < count; i++)
                {
                    var res = GetNextPermutation(length - 1, result, selected);
                    yield return res;
                    result = res.Clone() as int[];
                }
            }
        }

        private static int[] GetNextPermutation(int index, int[] result, bool[] selected)
        {
            if (index == result.Length)
                return result;
            if (result[index] > -1)
                selected[result[index]] = false;

            for (int i = result[index] + 1; i < result.Length; i++)
            {
                if (selected[i])
                    continue;
                result[index] = i;
                selected[i] = true;
                return GetNextPermutation(index + 1, result, selected);
            }
            result[index] = -1;
            return GetNextPermutation(index - 1, result, selected);
        }

        private static int Factorial(int N)
        {
            if (N == 0)
                return 1;
            int result = 1;
            for (int i = 2; i <= N; i++)
            {
                result *= i;
            }
            return result;
        }
        public static IEnumerable<bool[]> GetAllSelections(int length)
        {
            bool[] selection = new bool[length];
            return GetAllSelections(selection, 0);
        }
        private static IEnumerable<bool[]> GetAllSelections(bool[] selection, int index)
        {
            if (index == selection.Length)
            {
                yield return selection.Select(v => v).ToArray();
            }
            else
            {
                selection[index] = true;
                foreach (var item in GetAllSelections(selection, index + 1))
                {
                    yield return item;
                }

                selection[index] = false;
                foreach (var item in GetAllSelections(selection, index + 1))
                {
                    yield return item;
                }
            }
        }
    }
}
