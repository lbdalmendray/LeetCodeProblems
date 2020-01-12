using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberofOperationstoMakeNetworkConnected
{
    public class Solution
    {
        public int MakeConnected(int n, int[][] connections)
        {
            bool[] selected = new bool[n];
            LinkedList<int>[] connected = new LinkedList<int>[n];
            for (int i = 0; i < n; i++)
            {
                connected[i] = new LinkedList<int>();
            }
            foreach (var item in connections)
            {
                connected[item[0]].AddLast(item[1]);
                connected[item[1]].AddLast(item[0]);
            }
            int connectedComponentCount = 0;
            for (int i = 0; i < n; i++)
            {
                if(!selected[i])
                {
                    connectedComponentCount++;
                    DFS(i, connected, selected);
                }
            }

            if (connectedComponentCount == 1)
                return 0;

            int edgesNeeded = connectedComponentCount - 1;

            if (connections.Length >= n - 1)
                return edgesNeeded;

            return -1;
        }

        private void DFS(int i, LinkedList<int>[] connected, bool[] selected)
        {
            selected[i] = true;
            foreach (var item in connected[i].Where(e=>!selected[e]))
            {
                DFS(item, connected, selected);
            }
        }
    }
}
