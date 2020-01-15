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
            if (connections.Length < n - 1)
                return -1;
            int connectedAmount = Math.Min(n, connections.Length + 1); // This value is greater than or equal to the amount of the vertexes that each one is connected by a connection with other one .
            Dictionary<int, LinkedList<int>> dictConnection = new Dictionary<int, LinkedList<int>>(connectedAmount);
            foreach (var item in connections)
            {
                if (!dictConnection.TryGetValue(item[0], out var currentLinkedList))
                {
                    currentLinkedList = new LinkedList<int>();
                    dictConnection.Add(item[0], currentLinkedList);
                }
                currentLinkedList.AddLast(item[1]);

                if (!dictConnection.TryGetValue(item[1], out currentLinkedList))
                {
                    currentLinkedList = new LinkedList<int>();
                    dictConnection.Add(item[1], currentLinkedList);
                }
                currentLinkedList.AddLast(item[0]);
            }
            int connectedComponentCount = 0;
            HashSet<int> selected = new HashSet<int>(connectedAmount);

            var keys = dictConnection.Keys.ToArray();
            foreach (var key in keys)
            {
                if (!selected.Contains(key))
                {
                    connectedComponentCount++;
                    DFS(key, dictConnection, selected);
                }
            }

            connectedComponentCount += n - keys.Length; // adding vertexes that are not in connections 

            //if (connectedComponentCount == 1)
            // return 0;

            int edgesNeeded = connectedComponentCount - 1;

            //if (connections.Length >= n - 1)
            return edgesNeeded;

            //return -1;
        }
        private void DFS(int key, Dictionary<int, LinkedList<int>> dicConnection, HashSet<int> selected)
        {
            selected.Add(key);
            foreach (var item in dicConnection[key].Where(e => !selected.Contains(e)))
            {
                DFS(item, dicConnection, selected);
            }
        }
    }
}
