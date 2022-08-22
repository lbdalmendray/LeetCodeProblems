namespace SumofSubarrayRanges
{
    public class Solution
    {
        public long SubArrayRanges(int[] A)
        {
            long result = 0;
            //// substracting smallest values
            result += SubArrayRanges(A, (a, b) => a > b, (a) => -a);
            //// substracting biggest values
            result += SubArrayRanges(A, (a, b) => a < b, (a) => a);
            return result;
        }

        private long SubArrayRanges(int[] A, Func<int,int, bool> compareOp, Func<long,long> addOp)
        {
            long result = 0;
            LinkedList<int> indexes = new LinkedList<int>();
            indexes.AddLast(-1);
            indexes.AddLast(0);
            for (int i = 1; i <= A.Length; i++)
            {
                while (indexes.Count > 1 &&
                    (i < A.Length ?
                    compareOp(A[indexes.Last.Value] , A[i])
                    : true))
                {
                    var midIndex = indexes.Last.Value;
                    var midValue = IndexMinAt(A, midIndex);
                    indexes.RemoveLast();

                    var firstIndex = indexes.Last.Value;
                    result += addOp(midValue * (i - midIndex) * (midIndex - firstIndex));
                }
                indexes.AddLast(i);
            }

            return result;
        }

        public int IndexMinAt(int [] A, int index)
        {
            if (index == -1)
                return int.MinValue;
            else
                return A[index];
        }
        /// <summary>
        /// Solution1 
        /// O(n^2)
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public long SubArrayRanges1(int[] A)
        {
            (int, int)[,] solutions = new (int, int)[A.Length, A.Length];

            for (int i = 0; i < A.Length; i++)
            {
                solutions[i, i] = (A[i], A[i]);
            }

            long result = 0;

            for (int length = 2; length <= A.Length; length++)
            {
                for (int i = 0; i < A.Length - length + 1; i++)
                {
                    var min = Math.Min(A[i], solutions[i + 1, i + length - 1].Item1);
                    var max = Math.Max(A[i], solutions[i + 1, i + length - 1].Item2);
                    solutions[i, i + length - 1] = (min, max);
                    result += max - min;
                }
            }

            return result;
        }

    }
}