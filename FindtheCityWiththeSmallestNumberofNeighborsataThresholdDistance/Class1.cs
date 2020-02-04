using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindtheCityWiththeSmallestNumberofNeighborsataThresholdDistance
{
    public class Solution
    {
        public int FindTheCity(int n, int[][] edges, int distanceThreshold)
        {
            LinkedList<(int, int)>[] graph = CreateGraph(n, edges);

            (int,int) result = (0, Dijkstra_Counter(graph, 0, distanceThreshold));

            for (int i = 1; i < n; i++)
            {
                var currentResult = Dijkstra_Counter(graph, i , distanceThreshold);
                if (currentResult <= result.Item2)
                    result = (i, currentResult);
            }
            return result.Item1;            
        }
        private int Dijkstra_Counter(LinkedList<(int, int)>[] graph, int index, int distanceThreshold)
        {
            int result = 0;
            SortedDictionary<int, LinkedList<int>> edgeSortedList = new SortedDictionary<int, LinkedList<int>>();

            int [] pathLengths = Enumerable.Repeat(-1,graph.Length).ToArray();
            pathLengths[index] = 0;

            foreach (var item in graph[index])
            {
                if (item.Item2 > distanceThreshold)
                    continue;

                if ( !edgeSortedList.TryGetValue(item.Item2, out var list))
                {
                    list = new LinkedList<int>();
                    edgeSortedList.Add(item.Item2, list);
                }

                ///         CurrentPathLength   index to item.Item1
                list.AddLast(item.Item1);
            }
            while( edgeSortedList.Count != 0  )
            {
                var firstKeyValue = edgeSortedList.First();
                if(firstKeyValue.Value.Count == 1)
                    edgeSortedList.Remove(firstKeyValue.Key);

                var list = firstKeyValue.Value;
                var firstListValue = list.First.Value;
                list.RemoveFirst();

                if (pathLengths[firstListValue] != -1)
                    continue;

                pathLengths[firstListValue] = firstKeyValue.Key;
                result++;

                foreach (var item in graph[firstListValue])
                {
                    var distance = firstKeyValue.Key + item.Item2;

                    if (distance > distanceThreshold)
                        continue;

                    if (!edgeSortedList.TryGetValue(distance, out list))
                    {
                        list = new LinkedList<int>();
                        edgeSortedList.Add(distance, list);
                    }

                    list.AddLast(item.Item1);
                }              
            }

            return result;
        }

        private LinkedList<(int,int)>[] CreateGraph(int n, int[][] edges)
        {
            LinkedList<(int,int)>[] result = new LinkedList<(int, int)>[n];

            for (int i = 0; i < n; i++)
            {
                result[i] = new LinkedList<(int, int)>();
            }

            for (int i = 0; i < edges.Length; i++)
            {
                result[edges[i][0]].AddLast((edges[i][1], edges[i][2] ));
                result[edges[i][1]].AddLast((edges[i][0], edges[i][2] ));
            }

            return result;
        }
    }
}
