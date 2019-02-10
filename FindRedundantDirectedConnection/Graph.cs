using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindRedundantDirectedConnection
{
    public class Graph
    {
        LinkedList<int>[] Adj;
        LinkedList<int>[] AdjIndex;
        LinkedList<bool>[] AdjIsOriginal;
        int[,] OriginalEdges;

        public Graph(int[,] edges, bool hasLastVertex, int lastVertex, bool makeUndirictedFromDirected)
        {
            this.OriginalEdges = edges;
            if (!hasLastVertex)
            {
                for (int i = 0; i < edges.GetLength(0); i++)
                {
                    if (edges[i, 0] > lastVertex)
                    {
                        lastVertex = edges[i, 0];
                    }
                    if (edges[i, 1] > lastVertex)
                    {
                        lastVertex = edges[i, 1];
                    }
                }
            }

            int[] edgesIndex = null;
            bool[] isEdgesOriginal = null;

            if (makeUndirictedFromDirected)
            {
                bool[,] boolEdges = new bool[lastVertex, lastVertex];
                int[,] boolEdgesIndex = new int[lastVertex, lastVertex];
                bool[,] isEdgeOriginalMatrix = new bool[lastVertex, lastVertex];

                for (int i = 0; i < edges.GetLength(0); i++)
                {
                    boolEdges[edges[i, 0] - 1, edges[i, 1] - 1] = true;
                    boolEdges[edges[i, 1] - 1, edges[i, 0] - 1] = true;
                    isEdgeOriginalMatrix[edges[i, 0] - 1, edges[i, 1] - 1] = true;

                    boolEdgesIndex[edges[i, 0] - 1, edges[i, 1] - 1] = i;
                    boolEdgesIndex[edges[i, 1] - 1, edges[i, 0] - 1] = i;
                }

                int newEdgesCount = 0;
                for (int i = 0; i < lastVertex - 1; i++)
                {
                    for (int j = i + 1; j < lastVertex; j++)
                    {
                        if (boolEdges[i, j])
                        {
                            newEdgesCount += 2;
                        }
                    }
                }

                int[,] edgesNew = new int[newEdgesCount, 2];
                int[] edgesNewIndex = new int[newEdgesCount];
                bool[] isEdgesOriginalNew = new bool[newEdgesCount];

                for (int i = 0, newIndex = 0; i < lastVertex - 1; i++)
                {
                    for (int j = i + 1; j < lastVertex; j++)
                    {
                        if (boolEdges[i, j])
                        {
                            edgesNew[newIndex, 0] = i+1;
                            edgesNew[newIndex, 1] = j+1;

                            edgesNew[newIndex + 1, 0] = j+1;
                            edgesNew[newIndex + 1, 1] = i+1;

                            edgesNewIndex[newIndex] = boolEdgesIndex[i, j];
                            edgesNewIndex[newIndex + 1] = boolEdgesIndex[i, j];

                            isEdgesOriginalNew[newIndex] = isEdgeOriginalMatrix[i, j];
                            isEdgesOriginalNew[newIndex + 1] = isEdgeOriginalMatrix[j, i];


                            newIndex += 2;
                        }
                    }
                }

                edges = edgesNew;
                edgesIndex = edgesNewIndex;
                isEdgesOriginal = isEdgesOriginalNew;
            }
            else
            {
                edgesIndex = new int[edges.GetLength(0)];
                isEdgesOriginal = new bool[edges.GetLength(0)];
                for (int i = 0; i < edgesIndex.Length; i++)
                {
                    edgesIndex[i] = i;
                    isEdgesOriginal[i] = true;
                }
            }

            Adj = new LinkedList<int>[lastVertex];
            AdjIndex = new LinkedList<int>[lastVertex];
            AdjIsOriginal = new LinkedList<bool>[lastVertex];

            for (int i = 0; i < Adj.Length; i++)
            {
                Adj[i] = new LinkedList<int>();
                AdjIndex[i] = new LinkedList<int>();
                AdjIsOriginal[i] = new LinkedList<bool>();
            }

            for (int i = 0; i < edges.GetLength(0); i++)
            {
                Adj[edges[i, 0] - 1].AddLast(edges[i, 1] - 1);
                AdjIndex[edges[i, 0] - 1].AddLast(edgesIndex[i]);
                AdjIsOriginal[edges[i, 0] - 1].AddLast(isEdgesOriginal[i]);
            }
        }

        public Graph(int[,] edges, bool makeUndirictedFromDirected)
            : this(edges, false, 0, makeUndirictedFromDirected)
        {

        }

        public Graph(int[,] edges)
           : this(edges, false)
        {

        }

        public LinkedList<EdgeInfo> DFSGetFirstCycle(out bool hasFather, out int fatherVertex, out int childVertex)
        {
            bool[] vertexsArrived = new bool[Adj.GetLength(0)];
            LinkedList<EdgeInfo> resultwithCycle = new LinkedList<EdgeInfo>();
            fatherVertex = -1;
            childVertex = -1;
            hasFather = false;
            vertexsArrived[0] = true;
            bool[,] adjMatrix = new bool[Adj.GetLength(0), Adj.GetLength(0)];
            if (DFSGetFirstCycleAux(0, vertexsArrived, resultwithCycle, adjMatrix))
            {
                var beginCycleVertex = resultwithCycle.Last.Value.Vertex2;
                var node = resultwithCycle.Last;

                LinkedList<EdgeInfo> cycle = new LinkedList<EdgeInfo>();
                while (node.Value.Vertex1 != beginCycleVertex)
                {
                    cycle.AddFirst(node.Value);
                    node = node.Previous;
                }

                cycle.AddFirst(node.Value);

                if (CycleHasFather(cycle, out fatherVertex, out childVertex))
                {
                    fatherVertex++;
                    childVertex++;
                    hasFather = true;
                }
                return MakeOriginalCycle(cycle);
            }
            return null;
        }

        private LinkedList<EdgeInfo> MakeOriginalCycle(LinkedList<EdgeInfo> cycle)
        {
            LinkedList<EdgeInfo> result = new LinkedList<EdgeInfo>();
            
            foreach (var edgeInfo in cycle)
            {
                result.AddLast(new EdgeInfo { EdgeIndex = edgeInfo.EdgeIndex , Vertex1 = OriginalEdges[edgeInfo.EdgeIndex, 0] 
                    , Vertex2 = OriginalEdges[edgeInfo.EdgeIndex, 1]
                });
            }
            return result;
        }


        public bool CycleHasFather(LinkedList<EdgeInfo> cycle, out int fatherVertex, out int childVertex)
        {
            bool[] cycleVertex = new bool[Adj.Length];

            fatherVertex = -1;
            childVertex = -1;

            foreach (var edge in cycle)
            {
                cycleVertex[edge.Vertex1] = true;
            }

            for (int i = 0; i < Adj.Length; i++)
            {
                var node = Adj[i].First;
                var nodeIsOrig = AdjIsOriginal[i].First;
                
                while (node != null)
                {
                    if (nodeIsOrig.Value && !cycleVertex[i] && cycleVertex[node.Value])
                    {
                        fatherVertex = i;
                        childVertex = node.Value;
                        return true;
                    }
                    node = node.Next;
                    nodeIsOrig = nodeIsOrig.Next;
                }
            }

            return false;
        }

        private bool DFSGetFirstCycleAux(int vertex, bool[] vertexsArrived, LinkedList<EdgeInfo> result, bool[,] adjMatrix)
        {

            if (Adj[vertex].Count == 0)
                return false;

            var Node = Adj[vertex].First;
            var NodeIndex = AdjIndex[vertex].First;

            while (Node != null)
            {
                if (!adjMatrix[vertex, Node.Value])
                {
                    adjMatrix[vertex, Node.Value] = adjMatrix[Node.Value,vertex ] = true;
                    result.AddLast(new EdgeInfo { Vertex1 = vertex, Vertex2 = Node.Value, EdgeIndex = NodeIndex.Value });
                    if (vertexsArrived[Node.Value])
                    {
                        return true;
                    }

                    else
                    {
                        vertexsArrived[Node.Value] = true;
                        if (DFSGetFirstCycleAux(Node.Value, vertexsArrived, result,adjMatrix))
                            return true;
                        else
                        {
                            result.Remove(result.Last);
                        }
                    }
                }

                Node = Node.Next;
                NodeIndex = NodeIndex.Next;
            }

            return false;
        }


    }

    public class EdgeInfo
    {
        public int Vertex1;
        public int Vertex2;
        public int EdgeIndex;
    }
}
