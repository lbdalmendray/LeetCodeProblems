using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReconstructItinerary
{
    public class Solution
    {
        public IList<string> FindItinerary(IList<IList<string>> tickets)
        {
            var ticketEnumerable = Sort(tickets, 2);
            ticketEnumerable = Sort(ticketEnumerable, 1);
            ticketEnumerable = Sort(ticketEnumerable, 0);
            var graph = CreateGraph(ticketEnumerable);
            var jfkIndex = CalcualteVertexIndex("JFK");
            if (graph[jfkIndex] == null)
                return new List<string> { "JFK" };
            LinkedList<string> result = new LinkedList<string>();
            result.AddLast("JFK");
            DFS(graph, jfkIndex, result,0,tickets.Count);
            return result.ToList();
        }

        private bool DFS(Info[] graph, int index, LinkedList<string> result,int currentLength,int maxLength)
        {
            if (currentLength == maxLength)
                return true;

            if (graph[index] == null || graph[index].Edges.Count == 0)
                return false;
            var node = graph[index].Edges.First;
            
            while (node != null )
            {
                var nodePrevious = node.Previous;
                var value = node.Value;
                graph[index].Edges.Remove(node);

                result.AddLast(value.Item2);
                if (DFS(graph, value.Item1, result, currentLength + 1, maxLength))
                    return true;
                result.RemoveLast();
                if (nodePrevious == null)
                    graph[index].Edges.AddFirst(node);
                else
                    graph[index].Edges.AddAfter(nodePrevious, node);
                node = node.Next;
            }

            return false;
        }

        private Info[] CreateGraph(IEnumerable<IList<string>> ticketEnumerable)
        {
            Info[] result = new Info[26 * 26 * 26];

            foreach (var ticket in ticketEnumerable)
            {
                var vertexIndex = CalcualteVertexIndex(ticket[0]);
                if( result[vertexIndex] == null)
                {
                    result[vertexIndex] = new Info { Edges = new LinkedList<Tuple<int,string>>() };
                }

                result[vertexIndex].Edges.AddLast(new Tuple<int, string>(CalcualteVertexIndex(ticket[1]), ticket[1]));
            }

            foreach (var ticket in ticketEnumerable)
            {
                var vertexIndex = CalcualteVertexIndex(ticket[0]);
                if (result[vertexIndex].Selected == null)
                    result[vertexIndex].Selected = new bool[result[vertexIndex].Edges.Count];
            }

            return result;
        }

        private int CalcualteVertexIndex(string stringValue)
        {
            int result = 0;
            int pow = 1;
            for (int i = 0; i < 3; i++)
            {
                result += (stringValue[i] - 'A') * pow;
                pow *= 26;
            }
            return result;
        }

        private IEnumerable<IList<string>> Sort(IEnumerable<IList<string>> tickets, int index)
        {
            LinkedList<IList<string>>[] linkArray = new LinkedList<IList<string>>[26];
            for (int i = 0; i < 26; i++)
            {
                linkArray[i] = new LinkedList<IList<string>>();
            }
            foreach (var ticket in tickets)
            {
                var ticketIndex = ticket[1][index] - 'A';
                linkArray[ticketIndex].AddLast(ticket);
            }

            LinkedList<IList<string>> result = new LinkedList<IList<string>>();
            for (int i = 0; i < 26; i++)
            {
                if(linkArray[i] .Count != 0)
                {
                    foreach (var item in linkArray[i])
                    {
                        result.AddLast(item);
                    }
                }
            }

            return result;
        }
    }

    internal class Info
    {
        int lastNotSelectedIndex = 0;
        public IList<string> Ticket { get; internal set; }
        public LinkedList<Tuple<int, string>> Edges { get; internal set; }
        public bool[] Selected { get; internal set; }
        public Tuple<int, string>[] EdgesArray { get; internal set; }

        internal Tuple<int, string> getLastNotSelectedEdge()
        {
            return EdgesArray[lastNotSelectedIndex++];
        }

        internal bool HasNotSelectedIndex2()
        {
            return lastNotSelectedIndex < Selected.Length;
        }
    }
}
