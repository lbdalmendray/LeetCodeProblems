using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriticalConnectionsinaNetwork
{
    public class Solution3
    {
        public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
        {
            HashSet<int>[] graph = GenerateGraph(connections, n);
            HashSet<(int v1, int v2)> edgesProcessed = new HashSet<(int v1, int v2)>();
            Dictionary<int,int> vertexIndexListProcessed = new Dictionary<int, int>();
            int vertexIndex = 0;
            HashSet<(int, int)> edgesToFilter = GetEdgesFrom(graph); 
            DFS(-1, ref vertexIndex, 0, edgesProcessed, vertexIndexListProcessed, graph, edgesToFilter);
            return edgesToFilter.Select(e => new int[] { e.Item1, e.Item2 }.ToList() as IList<int>).ToList();
        }

        public int DFS (int prevVertex, ref int vertexIndex, int vertex 
            , HashSet<(int v1, int v2)> edgesProcessed
            , Dictionary<int, int> vertexIndexListProcessed
            , HashSet<int>[] graph
            ,HashSet<(int, int)> edgesToFilter)
        {
            vertexIndexListProcessed.Add(vertex, vertexIndex++);
            int result = vertexIndex;

            foreach (var vertexOther in graph[vertex])
            {
                if (prevVertex == vertexOther)
                    continue;

                (int vertex1, int vertex2) = GetEdgeSorted(vertex, vertexOther);
                if (edgesProcessed.Contains((vertex1, vertex2)))
                    continue;
                
                if (vertexIndexListProcessed.TryGetValue(vertexOther, out var vertexOtherIndex))
                {
                    result = Math.Min(result, vertexOtherIndex);
                    edgesToFilter.Remove((vertex1, vertex2));
                }
                else
                {
                   var cResult = DFS(vertex, ref vertexIndex, vertexOther, edgesProcessed
                        , vertexIndexListProcessed
                        , graph
                        , edgesToFilter);

                    if( cResult <= vertexIndex )
                    {
                        result = Math.Min(result, vertexIndexListProcessed[vertexOther]);
                        edgesToFilter.Remove((vertex1, vertex2));
                    }
                }
            }

            return result;
        }

        public HashSet<int> [] GenerateGraph( IList<IList<int>> connections , int n)
        {
            HashSet<int>[] result = new HashSet<int>[n];

            for (int i = 0; i < n; i++)
            {
                result[i] = new HashSet<int>();
            }

            foreach (var item in connections)
            {
                result[item[0]].Add(item[1]);
                result[item[1]].Add(item[0]);
            }

            return result;
        }

        HashSet<(int,int)> GetEdgesFrom(HashSet<int>[] graph)
        {
            HashSet<(int, int)> result = new HashSet<(int, int)>();

            for (int v1 = 0; v1 < graph.Length; v1++)
            {
                foreach (var v2 in graph[v1])
                {
                    var (v1Sorted, v2Sorted) = GetEdgeSorted(v1, v2);

                    result.Add((v1Sorted, v2Sorted)) ;
                }
            }

            return result;
        }

        public (int , int) GetEdgeSorted(int vertexInput1, int vertexInput2)
        {
            if (vertexInput1 > vertexInput2)
                return (vertexInput2, vertexInput1);
            else
                return (vertexInput1, vertexInput2);
        }
    }
}
