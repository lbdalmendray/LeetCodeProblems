namespace NumberofProvinces
{
    public class Solution
    {
        public int FindCircleNum(int[][] isConnected)
        {
            int length = isConnected.Length;

            bool[] selected = new bool[length];
            int result = 0;
            for (int i = 0; i < length; i++)
            {
                if (!selected[i])
                {
                    DFS(isConnected, i, selected, length);
                    result++;
                }
            }
            return result;
        }

        private void DFS(int[][] connected,int vertex, bool[] selected, int length )
        {
            selected[vertex] = true;
            for (int i = 0; i < length; i++)
            {
                if (i == vertex || selected[i] || connected[vertex][i] == 0)
                    continue;
                DFS(connected, i, selected, length);
            }
        }
    }
}