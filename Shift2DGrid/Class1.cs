using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift2DGrid
{
    public class Class1
    {
        public class Solution
        {
            public IList<IList<int>> ShiftGrid(int[][] grid, int k)
            {
                LinkedList<int> elements = new LinkedList<int>();

                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        elements.AddLast(grid[i][j]);
                    }
                }

                var currentNode = elements.First;
                k = k % elements.Count;

                for (int i = 0; i < k; i++)
                {
                    if (currentNode.Previous != null)
                        currentNode = currentNode.Previous;
                    else
                        currentNode = elements.Last;
                }

                LinkedList<LinkedList<int>> result = new LinkedList<LinkedList<int>>();

                for (int i = 0; i < grid.Length; i++)
                {
                    LinkedList<int> currentLinkedList = new LinkedList<int>();

                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        currentLinkedList.AddLast(currentNode.Value);
                        if (currentNode.Next != null)
                            currentNode = currentNode.Next;
                        else
                            currentNode = elements.First;
                    }
                    result.AddLast(currentLinkedList);
                }

                return result.Select(e => e.ToList() as IList<int>).ToList() as IList<IList<int>>;
                     
            }
        }
    }
}
