using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPositionAfterTSeconds
{
    public class Solution
    {
        public double FrogPosition(int n, int[][] edges, int t, int target)
        {
           LinkedList<int>[] graph =  CreateGraph(n, edges);

            LinkedList<int> path = new LinkedList<int>();
            if (!CalculatePathToTarget(graph, 1,0, target, path))
                return 0.0;
            int countLess1 = path.Count - 1;
            graph[1].AddLast(0);
            if (countLess1 > t || (countLess1 < t && graph[path.Last.Value].Count > 1 ))
                return 0.0;            

            var result = CalculateProbability(path, graph, 1.0);
            return result;

        }

        private double CalculateProbability(LinkedList<int> path, LinkedList<int>[] graph, double currentResult)
        {
            if (path.Count == 1)
                return currentResult;
            double relProb = 1.0 / (graph[path.First.Value].Count-1);
            path.RemoveFirst();
            return CalculateProbability(path, graph, currentResult * relProb);
        }

        private bool CalculatePathToTarget(LinkedList<int>[] graph,  int vertex, int pather, int target, LinkedList<int> path)
        {
            path.AddLast(vertex);

            if (target == vertex)
                return true;

            foreach (var item in graph[vertex].Where(e=>e!=pather))
            {
                if (CalculatePathToTarget(graph, item,vertex, target, path))
                    return true;
            }

            path.RemoveLast();
            return false;
        }

        private LinkedList<int>[] CreateGraph(int n, int[][] edges)
        {
            LinkedList<int>[] result = new LinkedList<int>[n+1];
            for (int i = 1; i < n+1; i++)
            {
                result[i] = new LinkedList<int>();
            }

            for (int i = 0; i < edges.Length; i++)
            {
                result[edges[i][0]].AddLast(edges[i][1]);
                result[edges[i][1]].AddLast(edges[i][0]);
            }

            return result;
        }
    }
}
