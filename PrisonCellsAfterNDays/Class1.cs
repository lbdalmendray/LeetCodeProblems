using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PrisonCellsAfterNDays
{
    public class Solution
    {
        public int[] PrisonAfterNDays(int[] cells, int n)
        {
            LinkedList<(int, int)> descriptorPath = GetPath(cells, out var firstCycleIndex );
            n--;
            if ( n < firstCycleIndex)
            {
                var intValue = descriptorPath.Skip(n - 1).First().Item2;
                return GetString8(intValue);
            } 
            else
            {
                var cycle = descriptorPath.Skip(firstCycleIndex).ToArray();
                n = n - firstCycleIndex;
                var rest = (n % cycle.Length);
                var result = cycle[rest].Item2;
                return GetString8(result);
            }
        }

        private int[] GetString8(int intValue)
        {
            var stringValue = intValue.ToString();
            if (stringValue.Length == 8)
                return stringValue.Select(e=>int.Parse(e.ToString())).ToArray();
            else
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < 8 - stringValue.Length ; i++)
                {
                    sb.Append('0');
                }
                sb.Append(stringValue);
                return sb.ToString().Select(e => int.Parse(e.ToString())).ToArray();
            }
        }

        private LinkedList<(int, int)> GetPath(int[] cells, out int firstCycleIndex)
        {
            LinkedList<(int, int)> result = new LinkedList<(int, int)>();
            Dictionary<int, int> relations = new Dictionary<int, int>();
            int currentInteger = GetInteger(cells);
            int[] currentCells = cells;
            firstCycleIndex = 0;
            while (true)
            {
                if (relations.ContainsKey(currentInteger))/// found a cycle and it has to break`
                {
                    break;
                }
                else
                {
                    currentCells = GetNextCells(currentCells);
                    var relValue = GetInteger(currentCells);
                    relations[currentInteger] = relValue;
                    result.AddLast((currentInteger, relValue));
                    currentInteger = relValue;
                }
            }

            var currentNode = result.First;

            while (currentNode.Value.Item1 != result.Last.Value.Item2)
            {
                firstCycleIndex++;
                currentNode = currentNode.Next;
            }

            return result;
        }

        private int GetInteger(int [] cells)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in cells)
            {
                sb.Append(item);
            }
            return int.Parse(sb.ToString());
        }

        private int [] GetNextCells(int [] cells)
        {
            int[] result = new int[cells.Length];

            for (int i = 1; i < cells.Length-1; i++)
            {
                if (cells[i - 1] == cells[i + 1])
                    result[i] = 1;
                //else // commented because of the default value 
                //{
                //    cells[i] = 0;
                //}
            }

            return result;
        }
    }
}
