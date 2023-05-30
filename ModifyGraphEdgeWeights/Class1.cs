
namespace ModifyGraphEdgeWeights
{
    using number = System.Int64;

    public class Solution
    {
        public int[][] ModifiedGraphEdges(int n, int[][] edges, int source, int destination, int target)
        {
            Graph graph = Graph.GeneratePositveGraphFrom(n, edges.ToNumberNumberArray());
            number positiveGraphMinDistance = graph.CalculateMinDistance((number)source, (number)destination, out _);
            if (positiveGraphMinDistance < target)
                return new int[][] { };
            else
            {
                var variableEdges = edges.Where(e => e[2] == -1).ToArray();
                if (positiveGraphMinDistance == target)
                {
                    foreach (var edge in variableEdges)
                    {
                        graph.AddEdge(new number[] { edge[0], edge[1], positiveGraphMinDistance });
                    }
                }
                else
                {
                    foreach (var edge in variableEdges)
                    {
                        graph.AddEdge(new number[] { edge[0], edge[1], 1 }, true);
                    }

                    number minDistance = graph.CalculateMinDistance(source, destination, out var minDistTree);
                    while (minDistance < target)
                    {
                        var minDistTreeInverse = minDistTree.Inverse();
                        LinkedList<(number[],bool)> edgeList = new LinkedList<(number[],bool)>();
                        IEnumerable<number[]> inverseEdgesFromVertex = minDistTreeInverse.GetEdgesFromVertex(destination);
                        while (inverseEdgesFromVertex?.Any() ?? false)
                        {
                            var firstInverseEdge = inverseEdgesFromVertex.FirstOrDefault();
                            if (firstInverseEdge != null)
                            {
                                var firstEdge = new number[] { firstInverseEdge[1], firstInverseEdge[0], firstInverseEdge[2] };
                                edgeList.AddFirst((firstEdge, minDistTreeInverse.IsVariableEdge(firstInverseEdge[0], firstInverseEdge[1])));
                                inverseEdgesFromVertex = minDistTreeInverse.GetEdgesFromVertex(firstInverseEdge[1]);
                            }
                            else
                            {
                                inverseEdgesFromVertex = null;
                            }
                        }

                        number[] variableMinDisTreeEdge = edgeList.First(e => e.Item2).Item1;
                        
                        if (variableMinDisTreeEdge != null)
                        {
                            number currentWeight = graph.GetWeightFromEdge(variableMinDisTreeEdge[0], variableMinDisTreeEdge[1]);
                            var newEdgeWeight = currentWeight + target - minDistance;
                            variableMinDisTreeEdge[2] = newEdgeWeight;
                            graph.UpdateEdgeWeight(variableMinDisTreeEdge);

                            HashSet<(number, number)> goodVariableEdges 
                                = new HashSet<(number, number)>(
                                    edgeList
                                    .Where(e=>e.Item2)
                                    .Select(e => (e.Item1[0], e.Item1[1])));

                            IEnumerable<number[]> badVariableEdges = graph.GetVariableEdgesWithNoWeight()
                                .Where(e => !goodVariableEdges.Contains((e[0], e[1])) && !goodVariableEdges.Contains((e[1], e[0])))
                                .ToArray();
                            
                            foreach (var badVariableEdge in badVariableEdges)
                            {
                                graph.UpdateEdgeWeight(new number[] { badVariableEdge[0], badVariableEdge[1], target });
                                graph.ChangeVariableEdgeToNot(badVariableEdge[0], badVariableEdge[1]);
                            }

                            graph.ChangeVariableEdgeToNot(variableMinDisTreeEdge[0], variableMinDisTreeEdge[1]);

                            minDistance = graph.CalculateMinDistance(source, destination, out minDistTree);
                        }
                        else
                        {
                            break;
                        }                        
                    }

                    if (minDistance > target)
                    {
                        return new int[][] { };
                    }
                }

                return graph.ToEdgeArray()
                    .ToIntIntArray();
            }
        }
    }

    public class Graph
    {
        private readonly bool undirectGraph;
        private readonly Dictionary<number, number>[] edgeWeightList;
        private readonly HashSet<(number, number)> VariableEdges = new HashSet<(number, number)>();
        public int VertexAmount { get => edgeWeightList.Length; }
        public int EdgesAmount 
        {
            get; private set;
        }

        public Graph(int n, IEnumerable<number[]> edges, bool undirectGraph = true)
        {
            this.undirectGraph = undirectGraph;
            this.edgeWeightList = Enumerable.Range(0,n).Select(_=> new Dictionary<number, number>()).ToArray();
            foreach (var edge in edges)
            {
                AddEdge(edge);
            }
        }

        public void AddEdge(number[] edge, bool isVariableEdge = false)
        {
            var vertex1 = edge[0];
            var vertex2 = edge[1];
            var weight = edge[2];
            if (vertex1 < 0 || vertex1 >= edgeWeightList.Length
                || vertex2 < 0 || vertex2 >= edgeWeightList.Length)
                return;
            else
            {
                edgeWeightList[vertex1].Add(vertex2, weight);
                if (isVariableEdge)
                {
                    VariableEdges.Add((vertex1, vertex2));
                }
                if (undirectGraph)
                {
                    edgeWeightList[vertex2].Add(vertex1, weight);
                    if (isVariableEdge)
                    {
                        VariableEdges.Add((vertex2, vertex1));
                    }
                }
                EdgesAmount++;
            }
        }

        public bool IsVariableEdge(number vertex1, number vertex2)
        {
            return VariableEdges.Contains((vertex1, vertex2));
        }

        public static Graph GeneratePositveGraphFrom(int n, number[][] edges)
        {
            return new Graph(n, edges.Where(e =>
            {
                return e[2] > 0;
            }));
        }

        public number CalculateMinDistance(number source, number destination, out Graph minDistTree, bool stopOnDestination = false )
        {
            number?[] location = new number?[edgeWeightList.Length];
            SortedDictionary<number, Dictionary<number, number>> sortedDict = new SortedDictionary<number, Dictionary<number, number>>();
            List<number[]> edges = new List<number[]>();

            location[source] = 0;
            AddEdgesToSortedDictFrom(source, sortedDict, location , 0);

            while (sortedDict.Count != 0)
            {
                var kvSortedDict = sortedDict.First();
                var kv = kvSortedDict.Value.First();
                kvSortedDict.Value.Remove(kv.Key);
                if (kvSortedDict.Value.Count == 0)
                {
                    sortedDict.Remove(kvSortedDict.Key);
                }
                location[kv.Key] = kvSortedDict.Key;
                edges.Add(new number[] { kv.Value, kv.Key, kvSortedDict.Key });
                if (stopOnDestination && kv.Value == destination)
                    break;
                AddEdgesToSortedDictFrom(kv.Key, sortedDict, location, kvSortedDict.Key);
            }

            minDistTree = new Graph(edgeWeightList.Length, new number[][] {}, false);
            foreach (var edge in edges)
                minDistTree.AddEdge(edge, IsVariableEdge(edge[0], edge[1]));

            var result  = location[destination].HasValue ? location[destination].Value : (long) int.MaxValue;
            return result;
        }

        private void AddEdgesToSortedDictFrom(number vertex, SortedDictionary<number, Dictionary<number, number>> sortedDict, number?[] location, number vertexDistance)
        {
            foreach (var edgeWeight in edgeWeightList[vertex])
            {
                var newDistance = edgeWeight.Value + vertexDistance;
                if (!location[edgeWeight.Key].HasValue || newDistance < location[edgeWeight.Key])
                {
                    if (location[edgeWeight.Key].HasValue)
                    {
                        var oldDict = sortedDict[location[edgeWeight.Key].Value];
                        oldDict.Remove(edgeWeight.Key);
                        if (oldDict.Count == 0)
                            sortedDict.Remove(location[edgeWeight.Key].Value);
                    }

                    location[edgeWeight.Key] = newDistance;
                    if( !sortedDict.TryGetValue(newDistance, out var dict))
                    {
                        dict = new Dictionary<number, number>();
                        sortedDict[newDistance] = dict;
                    }
                    dict.Add(edgeWeight.Key, vertex);
                }
            }
        }

        public number[][] ToEdgeArray()
        {
            HashSet<(number, number, number)> result = new HashSet<(number, number, number)>();
            for (int i = 0; i < edgeWeightList.Length; i++)
            {
                foreach (var vertexWeight in edgeWeightList[i])
                {
                    if (undirectGraph)
                    {
                        var vMin = i < vertexWeight.Key ? i : vertexWeight.Key;
                        var vMax = i >= vertexWeight.Key ? i : vertexWeight.Key;
                        result.Add((vMin, vMax, vertexWeight.Value));
                    }
                    else
                    {
                        result.Add((i, vertexWeight.Key, vertexWeight.Value));
                    }
                }
            }
            return result.Select(e => new number[] { e.Item1,e.Item2, e.Item3 }).ToArray();
        }

        internal bool ContainsEdge(number v1, number v2, out number[] result)
        {
            if( edgeWeightList[v1]?.TryGetValue(v2, out var weight) ?? false )
            {
                result = new number[] { v1, v2, weight };
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        internal void UpdateEdgeWeight(number[] variableMinDisTreeEdge)
        {
            edgeWeightList[variableMinDisTreeEdge[0]][variableMinDisTreeEdge[1]] = variableMinDisTreeEdge[2];
            if (undirectGraph)
                edgeWeightList[variableMinDisTreeEdge[1]][variableMinDisTreeEdge[0]] = variableMinDisTreeEdge[2];
        }

        internal Graph Inverse()
        {
            var inverseEdges = this.ToEdgeArray().Select(e => new number[] { e[1], e[0], e[2] });
            Graph graph = new Graph(edgeWeightList.Length, new number[][] { }, undirectGraph);
            foreach (var item in inverseEdges)
            {
                graph.AddEdge(item, IsVariableEdge(item[1], item[0]));
            }
            return graph;
        }

        internal IEnumerable<number[]> GetEdgesFromVertex(number vertex1)
        {
           return this.edgeWeightList[vertex1].Select(kv => new number[] { vertex1, kv.Key, kv.Value });
        }

        internal IEnumerable<number[]> GetVariableEdgesWithNoWeight()
        {
            return VariableEdges.Select(e => new number[] { e.Item1, e.Item2 });
        }

        internal void ChangeVariableEdgeToNot(number vertex1, number vertex2)
        {
            VariableEdges.Remove((vertex1, vertex2));
            if( undirectGraph)
            {
                VariableEdges.Remove((vertex2, vertex1));
            }
        }

        internal number GetWeightFromEdge(number vertex1, number vertex2)
        {
            return edgeWeightList[vertex1][vertex2];
        }
    }

    public static class HelpClass
    {
        public static int[][] ToIntIntArray(this number[][] array )
        {
            return array.Select(e => e.Select(e1 => (int)e1).ToArray()).ToArray();
        }

        public static number[][] ToNumberNumberArray(this int[][] array)
        {
            return array.Select(e => e.Select(e1 => (number)e1).ToArray()).ToArray();
        }
    }
}