using System;
using System.Linq;
using System.Collections.Generic;

namespace CriticalConnectionsinaNetwork
{
    public class Solution
    {
        public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
        {
            HashSet<int>[] graph = GenerateGraph(n, connections);
            HashSet<(int, int)> hsConnections = GenerateHashSetConnections(connections);

            bool[] selected = new bool[n];
            int[] depths = new int[n];

            DFS(0, 0, -1, selected, depths, graph, hsConnections);

            return hsConnections.Select(e => (IList<int>)new int[] { e.Item1, e.Item2 }).ToList();

        }

        int DFS(int vertex, int depth, int parentVertex, bool[] selected, int[] depths, HashSet<int>[] graph, HashSet<(int, int)> hsConnections)
        {
            if (selected[vertex])
                return depths[vertex];
            selected[vertex] = true;
            depths[vertex] = depth;
            int result = vertex + 1;

            int depthP1 = depth + 1;

            foreach (var vertexChild in graph[vertex].Where(e => e != parentVertex))
            {
                var cResult = DFS(vertexChild, depthP1, vertex, selected, depths, graph, hsConnections);
                if (cResult <= vertex)
                {
                    hsConnections.Remove((Math.Min(vertex, vertexChild), Math.Max(vertex, vertexChild)));
                }
                result = Math.Min(cResult, result);
            }

            return result;
        }

        HashSet<int>[] GenerateGraph(int n, IList<IList<int>> connections)
        {
            HashSet<int>[] result = new HashSet<int>[n];
            for (int i = 0; i < n; i++)
                result[i] = new HashSet<int>();

            foreach (var connection in connections)
            {
                result[connection[0]].Add(connection[1]);
                result[connection[1]].Add(connection[0]);
            }

            return result;
        }

        HashSet<(int, int)> GenerateHashSetConnections(IList<IList<int>> connections)
        {
            HashSet<(int, int)> result = new HashSet<(int, int)>();

            foreach (var connection in connections)
            {
                result.Add((Math.Min(connection[0], connection[1]), Math.Max(connection[0], connection[1])));
            }
            return result;
        }

    }
}
