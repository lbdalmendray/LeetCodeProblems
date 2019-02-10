using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindRedundantDirectedConnection
{
    public class Solution
    {
        public int[] FindRedundantDirectedConnection(int[,] edges)
        {
            int lastVertex = -1;
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
                if (edges[i, 0] == edges[i, 1])
                    return new int[] { edges[i, 0], edges[i, 1] };
            }

            Dictionary<int, int> dictEdges = new Dictionary<int, int>(edges.GetLength(0) * 2);
            int[,] edgesBig = new int[edges.GetLength(0) * 2, 2];

            for (int i = 0; i < edges.GetLength(0); i++)
            {
                dictEdges.Add(i,i);
                dictEdges.Add(edges.GetLength(0) + i, i);

                edgesBig[i, 0] = edges[i, 0];
                edgesBig[i, 1] = lastVertex + 1 + i;
                edgesBig[edges.GetLength(0) + i, 0] = lastVertex + 1 + i;
                edgesBig[edges.GetLength(0) + i, 1] = edges[i, 1];
            }

            Graph graph = new Graph(edgesBig, true, lastVertex + edges.Length, true);
            bool hasFather;
            int fatherVertex;
            int childVertex;

            

            var cycle = graph.DFSGetFirstCycle(out hasFather, out fatherVertex, out childVertex);

            if (hasFather)
            {
                EdgeInfo edgeInfoBad1 = null;
                EdgeInfo edgeInfoBad2 = null;
                EdgeInfo EdgeInfoLastIndex = null;
                if (AllSameDirectionCycle(cycle, out edgeInfoBad1, out edgeInfoBad2, out EdgeInfoLastIndex))
                {
                    foreach (var edge in cycle)
                    {
                        if (edge.Vertex2 == childVertex)
                        {
                            int index = dictEdges[edge.EdgeIndex];
                            return new int[2] { edges[index,0], edges[index, 1] };
                            //return new int[2] { edge.Vertex1, edge.Vertex2 };

                        }
                    }
                }
                else
                {
                    var edgeInfoMax = edgeInfoBad1;
                    if (edgeInfoBad1.EdgeIndex < edgeInfoBad2.EdgeIndex)
                    {
                        edgeInfoMax = edgeInfoBad2;
                    }
                    int index = dictEdges[edgeInfoMax.EdgeIndex];
                    return new int[2] { edges[index, 0], edges[index, 1] };
                    //return new int[2] { edgeInfoMax.Vertex1, edgeInfoMax.Vertex2 };
                }
            }
            else
            {
                EdgeInfo edgeInfoBad1 = null;
                EdgeInfo edgeInfoBad2 = null;
                EdgeInfo EdgeInfoLastIndex = null;
                if (AllSameDirectionCycle(cycle, out edgeInfoBad1, out edgeInfoBad2, out EdgeInfoLastIndex))
                {
                    int index = dictEdges[EdgeInfoLastIndex.EdgeIndex];
                    return new int[2] { edges[index, 0], edges[index, 1] };
                    //return new int[2] { EdgeInfoLastIndex.Vertex1, EdgeInfoLastIndex.Vertex2 };
                }
                else
                {
                    var edgeInfoMax = edgeInfoBad1;
                    if (edgeInfoBad1.EdgeIndex < edgeInfoBad2.EdgeIndex)
                    {
                        edgeInfoMax = edgeInfoBad2;
                    }
                    int index = dictEdges[edgeInfoMax.EdgeIndex];
                    return new int[2] { edges[index, 0], edges[index, 1] };
                    //return new int[2] { edgeInfoMax.Vertex1, edgeInfoMax.Vertex2 };
                }
            }

            return null;
        }

        private bool AllSameDirectionCycle(LinkedList<EdgeInfo> cycle,out EdgeInfo edgeInfoBad1, out EdgeInfo edgeInfoBad2, out EdgeInfo EdgeInfoLastIndex)
        {
            int direction = 0;
            bool result = true;
            var cycleArray = cycle.ToArray();

            edgeInfoBad1 = null;
            edgeInfoBad2 = null;
            EdgeInfoLastIndex = cycleArray[0];

            for (int i = 0; i < cycleArray.Length-1; i++)
            {
                if (EdgeInfoLastIndex.EdgeIndex < cycleArray[i].EdgeIndex)
                    EdgeInfoLastIndex = cycleArray[i];

                //if ( cycle[i,0] == cycle[i+1,0] )
                //{
                //    result = false;
                //}

                    if (cycleArray[i].Vertex2 == cycleArray[i + 1].Vertex2)
                {
                    edgeInfoBad1 = cycleArray[i];
                    edgeInfoBad2 = cycleArray[i+1];
                    result = false; // si hay uno con tipo x->y == w <-z es por existe uno con tipo  y <-x == w -> z y son únicos 
                }
            }

            if (EdgeInfoLastIndex.EdgeIndex < cycleArray[cycleArray.Length - 1].EdgeIndex)
                EdgeInfoLastIndex = cycleArray[cycleArray.Length - 1];

            if (cycleArray[cycleArray.Length - 1].Vertex2 == cycleArray[0].Vertex2)
            {
                edgeInfoBad1 = cycleArray[cycleArray.Length - 1];
                edgeInfoBad2 = cycleArray[0];
                result = false; // si hay uno con tipo x->y == w <-z es por existe uno con tipo  y <-x == w -> z y son únicos 
            }


            return result;
        }
    }

    
}
