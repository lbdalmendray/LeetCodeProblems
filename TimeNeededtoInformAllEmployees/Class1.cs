using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeNeededtoInformAllEmployees
{
    public class Solution
    {
        public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime)
        {
            LinkedList<int>[] graph = CreateGraph(n, headID, manager);

            return NumOfMinutes(graph, headID, informTime);
        }

        private int NumOfMinutes(LinkedList<int>[] graph, int vertex, int[] informTime)
        {
            int result = informTime[vertex];
            if (graph[vertex].Count > 0)
            {
                int currentResult = NumOfMinutes(graph,graph[vertex].First.Value,informTime);
                foreach (var item in graph[vertex].Skip(1))
                {
                    var ccResult = NumOfMinutes(graph, item, informTime);
                    if (ccResult > currentResult)
                        currentResult = ccResult;
                }

                result += currentResult;
            }
            return result;
        }

        private LinkedList<int>[] CreateGraph(int n, int headID, int[] manager)
        {
            LinkedList<int>[] result = new LinkedList<int>[n];
            for (int i = 0; i < n ; i++)
            {
                result[i] = new LinkedList<int>();
            }

            for (int i = 0; i < manager.Length; i++)
            {
                if (i == headID)
                    continue;
                result[manager[i]].AddLast(i);
            }

            return result;
        }
    }
}
