namespace ModifyGraphEdgeWeights
{
    public class Solution
    {
        public int[][] ModifiedGraphEdges(int n, int[][] edges, int source, int destination, int target)
        {
            Graph graph = Graph.GeneratePositveGraphFrom(n, edges);
            int positiveGraphMinDistance = graph.CalculateMinDistance(source, destination, out _);
            if (positiveGraphMinDistance < target)
                return new int[][] { };
            else
            {
                var variableEdges = edges.Where(e => e[2] == -1).ToArray();
                if (positiveGraphMinDistance == target)
                {
                    foreach (var edge in variableEdges)
                    {
                        graph.AddEdge(new int[] { edge[0], edge[1], positiveGraphMinDistance });
                    }
                }
                else
                {
                    foreach (var edge in variableEdges)
                    {
                        graph.AddEdge(new int[] { edge[0], edge[1], 1 }, true);
                    }

                    int minDistance = graph.CalculateMinDistance(source, destination, out var minDistTree);
                    while (minDistance < target)
                    {
                        var minDistTreeInverse = minDistTree.Inverse();
                        LinkedList<(int[],bool)> edgeList = new LinkedList<(int[],bool)>();
                        IEnumerable<int[]> inverseEdgesFromVertex = minDistTreeInverse.GetEdgesFromVertex(destination);
                        while (inverseEdgesFromVertex?.Any() ?? false)
                        {
                            var firstInverseEdge = inverseEdgesFromVertex.FirstOrDefault();
                            if (firstInverseEdge != null)
                            {
                                var firstEdge = new int[] { firstInverseEdge[1], firstInverseEdge[0], firstInverseEdge[2] };
                                edgeList.AddFirst((firstEdge, minDistTreeInverse.IsVariableEdge(firstInverseEdge[0], firstInverseEdge[1])));
                                inverseEdgesFromVertex = minDistTreeInverse.GetEdgesFromVertex(firstInverseEdge[1]);
                            }
                            else
                            {
                                inverseEdgesFromVertex = null;
                            }
                        }

                        int[] variableMinDisTreeEdge = edgeList.First(e => e.Item2).Item1;
                        
                        if (variableMinDisTreeEdge != null)
                        {
                            var newEdgeWeight = variableMinDisTreeEdge[2] + target - minDistance;
                            variableMinDisTreeEdge[2] = newEdgeWeight;
                            graph.UpdateEdgeWeight(variableMinDisTreeEdge);

                            HashSet<(int, int)> goodVariableEdges = new HashSet<(int, int)>(edgeList.Select(e => (e.Item1[0], e.Item1[1])));
                            IEnumerable<int[]> badVariableEdges = graph.GetVariableEdgesWithNoWeight()
                                .Where(e => !goodVariableEdges.Contains((e[0], e[1])) && !goodVariableEdges.Contains((e[1], e[0])))
                                .ToArray();
                            
                            foreach (var badVariableEdge in badVariableEdges)
                            {
                                graph.UpdateEdgeWeight(new int[] { badVariableEdge[0], badVariableEdge[1], target });
                                graph.ChangeVariableEdgeToNot(badVariableEdge[0], badVariableEdge[1]);
                            }

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

                return graph.ToEdgeArray();
            }
        }
    }

    public class Graph
    {
        private readonly bool undirectGraph;
        private readonly Dictionary<int, int>[] edgeWeightList;
        private readonly HashSet<(int, int)> VariableEdges = new HashSet<(int, int)>();
        public int VertexAmount { get => edgeWeightList.Length; }
        public int EdgesAmount 
        {
            get; private set;
        }

        public Graph(int n, IEnumerable<int[]> edges, bool undirectGraph = true)
        {
            this.undirectGraph = undirectGraph;
            this.edgeWeightList = Enumerable.Range(0,n).Select(_=> new Dictionary<int, int>()).ToArray();
            foreach (var edge in edges)
            {
                AddEdge(edge);
            }
        }

        public void AddEdge(int[] edge, bool isVariableEdge = false)
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

        public bool IsVariableEdge(int vertex1, int vertex2)
        {
            return VariableEdges.Contains((vertex1, vertex2));
        }

        public static Graph GeneratePositveGraphFrom(int n, int[][] edges)
        {
            return new Graph(n, edges.Where(e =>
            {
                return e[2] > 0;
            }));
        }

        public int CalculateMinDistance(int source, int destination, out Graph minDistTree, bool stopOnDestination = false )
        {
            int?[] location = new int?[edgeWeightList.Length];
            SortedDictionary<int, Dictionary<int, int>> sortedDict = new SortedDictionary<int, Dictionary<int, int>>();
            List<int[]> edges = new List<int[]>();

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
                edges.Add(new int[] { kv.Value, kv.Key, kvSortedDict.Key });
                if (stopOnDestination && kv.Value == destination)
                    break;
                AddEdgesToSortedDictFrom(kv.Key, sortedDict, location, kvSortedDict.Key);
            }

            minDistTree = new Graph(edgeWeightList.Length, new int[][] {}, false);
            foreach (var edge in edges)
                minDistTree.AddEdge(edge, IsVariableEdge(edge[0], edge[1]));

            var result  = location[destination].HasValue ? location[destination].Value : int.MaxValue;
            return result;
        }

        private void AddEdgesToSortedDictFrom(int vertex, SortedDictionary<int, Dictionary<int, int>> sortedDict, int?[] location, int vertexDistance)
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
                        dict = new Dictionary<int, int>();
                        sortedDict[newDistance] = dict;
                    }
                    dict.Add(edgeWeight.Key, vertex);
                }
            }
        }

        public int[][] ToEdgeArray()
        {
            HashSet<(int, int, int)> result = new HashSet<(int, int, int)>();
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
            return result.Select(e => new int[] { e.Item1,e.Item2, e.Item3 }).ToArray();
        }

        internal bool ContainsEdge(int v1, int v2, out int[] result)
        {
            if( edgeWeightList[v1]?.TryGetValue(v2, out var weight) ?? false )
            {
                result = new int[] { v1, v2, weight };
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        internal void UpdateEdgeWeight(int[] variableMinDisTreeEdge)
        {
            edgeWeightList[variableMinDisTreeEdge[0]][variableMinDisTreeEdge[1]] = variableMinDisTreeEdge[2];
            if (undirectGraph)
                edgeWeightList[variableMinDisTreeEdge[1]][variableMinDisTreeEdge[0]] = variableMinDisTreeEdge[2];
        }

        internal Graph Inverse()
        {
            var inverseEdges = this.ToEdgeArray().Select(e => new int[] { e[1], e[0], e[2] });
            Graph graph = new Graph(edgeWeightList.Length, new int[][] { }, undirectGraph);
            foreach (var item in inverseEdges)
            {
                graph.AddEdge(item, IsVariableEdge(item[1], item[0]));
            }
            return graph;
        }

        internal IEnumerable<int[]> GetEdgesFromVertex(int vertex1)
        {
           return this.edgeWeightList[vertex1].Select(kv => new int[] { vertex1, kv.Key, kv.Value });
        }

        internal IEnumerable<int[]> GetVariableEdgesWithNoWeight()
        {
            return VariableEdges.Select(e => new int[] { e.Item1, e.Item2 });
        }

        internal void ChangeVariableEdgeToNot(int vertex1, int vertex2)
        {
            VariableEdges.Remove((vertex1, vertex2));
        }
    }
}