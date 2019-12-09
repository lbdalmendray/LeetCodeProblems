using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumNumberofFlipstoConvertBinaryMatrixtoZeroMatrix
{
    public class Solution
    {
        public int MinFlips(int[][] mat)
        {
            LinkedList<uint>[] relations = GenerateRelations(mat.Length, mat[0].Length) ;
            var matNew = new bool[mat.Length, mat[0].Length];
            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[0].Length; j++)
                {
                    matNew[i, j] = mat[i][j] == 1 ? true : false;
                }
            }

            var matNumber = GetNumber(matNew);

            return BFS(matNumber, 0,  relations);

        }

        private int BFS(uint matNumber, uint finish , LinkedList<uint>[] relations)
        {
            if (matNumber == finish)
                return 0;

            LinkedList<uint[]> queue = new LinkedList<uint[]>();
            bool[] selected = new bool[relations.Length];
            queue.AddLast(new uint[] { matNumber, 0 });
            selected[matNumber] = true;
            while (queue.Count!= 0)
            {
                var first =queue.First.Value;
                queue.RemoveFirst();

                if (first[0] == finish)
                    return (int) first[1];
                uint nextLevel = first[1] + 1;
                foreach (var item in relations[first[0]].Where(e=>!selected[e]))
                {
                    selected[item] = true;
                    queue.AddLast(new uint[] { item, nextLevel });
                }
            }

            return -1;
        }

        public LinkedList<uint>[] GenerateRelations(int n, int m)
        {
            int count = (int) Math.Pow(2, n * m);
            int length = n * m;
            LinkedList<uint>[] relations = new LinkedList<uint>[count];
            for (uint value = 0; value < count; value++)
            {
                relations[value] = new LinkedList<uint>();
                var rect = GetRect(value,n,m);
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        LinkedList<int[]> changes = new LinkedList<int[]>();
                        changes.AddLast(new int[] { i, j });

                        if(i > 0 )
                        {
                            changes.AddLast(new int[] { i-1, j });
                        }
                        if(j > 0)
                            changes.AddLast(new int[] { i , j-1 });

                        if(i < n-1)
                            changes.AddLast(new int[] { i + 1, j });

                        if (j < m - 1)
                            changes.AddLast(new int[] { i, j + 1 });

                        foreach (var change in changes)
                        {
                            rect[change[0], change[1]] = !rect[change[0], change[1]] ;
                        }

                        var number = GetNumber(rect);

                        relations[value].AddLast(number);

                        foreach (var change in changes)
                        {
                            rect[change[0], change[1]] = !rect[change[0], change[1]] ;
                        }
                    }
                }
            }
            return relations;
        }

        public uint GetNumber(bool[,] rect)
        {
            uint potence = 1;
            uint result = 0;
            for (int i = 0; i < rect.GetLength(0); i++)
            {
                for (int j = 0; j < rect.GetLength(1); j++)
                {
                    if (rect[i, j])
                        result += potence;
                    potence *= 2;
                }
            }

            return result;
        }

        public bool[,] GetRect(uint value, int n , int m)
        {
            var bytes = BitConverter.GetBytes(value);
            BitArray bitArray = new BitArray(bytes);
            bool[,] result = new bool[n, m];
            int index = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    result[i, j] = bitArray[index];
                    index++;
                }
            }
            return result;
        }
    }
}
