using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriticalConnectionsinaNetwork
{
    public class Solution2
    {
        public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
        {
            if (n == 0 || n == 1)
                return (IList<IList<int>>)(new List<List<int>>());

            var graph = GenerateGraph(n, connections);
            DFS(0, -1 , graph, 0, new int?[n]);
            return graph.GetNotMarkedEdges();
        }

        internal int DFS(int vertex,int parent, Graph graph, int index,  int? [] vertexPositions)
        {
            if (vertexPositions[vertex].HasValue)
                return vertexPositions[vertex].Value;

            vertexPositions[vertex] = index;

            int result = index;

            foreach (var kv in graph.Connections[vertex].Where(kv=>kv.Key != parent))
            {
                int cResult = DFS(kv.Key, vertex ,  graph, index + 1, vertexPositions);
                if (cResult <= index)
                    kv.Value.Marked = true;

                result = Math.Min(cResult, result);
            }

            return result;
        }

        private Graph GenerateGraph(int n, IList<IList<int>> connections)
        {
            return new Graph(n, connections);
        }
    }

    internal class Graph
    {
        public Dictionary<int, EdgeInfo>[] Connections { get; private set; }

        public Graph(int n, IList<IList<int>> connections)
        {
            Connections = new Dictionary<int, EdgeInfo>[n];
            for (int i = 0; i < n; i++)
                Connections[i] = new Dictionary<int, EdgeInfo>();

            foreach (var connection in connections)
            {
                Connections[connection[0]].Add(connection[1], new EdgeInfo());
                Connections[connection[1]].Add(connection[0], new EdgeInfo());
            }
        }

        public IList<IList<int>> GetNotMarkedEdges()
        {
            List<List<int>> result = new List<List<int>>();

            for (int i = 0; i < Connections.Length ; i++)
            {
                foreach (var kv in Connections[i].ToArray())
                {
                    if (!kv.Value.Marked)
                    {
                        result.Add(new int[] { i, kv.Key }.ToList());
                    }
                    Connections[kv.Key].Remove(i);
                }
            }

            return result.Select(e=>(IList<int>)e).ToList();
        }
    }

    internal class EdgeInfo
    {
        public bool Marked { get; set; }  
    }

}
