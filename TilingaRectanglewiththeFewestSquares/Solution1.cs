using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TilingaRectanglewiththeFewestSquares
{
    public class Solution1
    {
        public int TilingRectangle(int n, int m)
        {
            Info[,] infos = new Info[n + 1, m + 1];
            bool[,] selected = new bool[n, m];
            return TilingRectangle(n, m, infos, selected, true, new Info { Result = int.MaxValue }, 0);
        }

        private int TilingRectangle1(int n, int m, Info[,] infos, bool[,] selected, bool pure, Info currentInfo, int count)
        {
            if (n == 0 || m == 0)
                return 0;
            if (count > currentInfo.Result)
                return count;

            if (pure && infos[n, m] != null)
            {
                return infos[n, m].Result;
            }

            int maxRadio = Math.Min(n, m);
            var result = new Info { Result = int.MaxValue };
            if (pure)
                infos[n, m] = result;
            if (GetFirstFree(selected, out int[] pos))
            {
                LinkedList<int[]> newSelectedPositions = new LinkedList<int[]>();
                for (int i = 1; i <= maxRadio; i++)
                {
                    if (TrySelect(i, pos, selected, newSelectedPositions))
                    {
                        if (IsPureRectangle(selected, out int[] dimension))
                        {
                            result.Result = Math.Min(result.Result, 1 + TilingRectangle(dimension[0], dimension[1], infos, new bool[dimension[0], dimension[1]], true, new Info { Result = int.MaxValue }, 0));
                        }
                        else
                        {
                            result.Result = Math.Min(result.Result, 1 + TilingRectangle(n, m, infos, selected, false, pure ? result : currentInfo, pure ? 1 : count + 1));
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                FreeNewSelectedPositions(newSelectedPositions, selected);
            }
            else
                return 0;

            return result.Result;
        }

        private int TilingRectangle(int n, int m, Info[,] infos, bool[,] selected, bool pure, Info currentInfo, int count)
        {
            if (n == 0 || m == 0)
                return 0;
            if (count > currentInfo.Result)
                return count;

            if (pure && infos[n, m] != null)
            {
                return infos[n, m].Result;
            }

            var result = new Info { Result = int.MaxValue };
            if (pure)
                infos[n, m] = result;
            if (GetFirstFree(selected, out int[] pos))
            {
                LinkedList<int[]> newSelectedPositions;
                int maxRadio = GetMaxRadio(pos, selected, out newSelectedPositions);

                for (int i = maxRadio; i >= 1; i--)
                {
                    if (IsPureRectangle(selected, out int[] dimension))
                    {
                        result.Result = Math.Min(result.Result, 1 + TilingRectangle(dimension[0], dimension[1], infos, new bool[dimension[0], dimension[1]], true, new Info { Result = int.MaxValue }, 0));
                    }
                    else
                    {
                        result.Result = Math.Min(result.Result, 1 + TilingRectangle(n, m, infos, selected, false, pure ? result : currentInfo, pure ? 1 : count + 1));
                    }
                    for (int j = 0; j < 2 * i - 1; j++)
                    {
                        selected[newSelectedPositions.Last.Value[0], newSelectedPositions.Last.Value[1]] = false;
                        newSelectedPositions.RemoveLast();
                    }
                }
                // FreeNewSelectedPositions(newSelectedPositions, selected);
            }
            else
                return 0;

            return result.Result;
        }

        private int GetMaxRadio(int[] pos, bool[,] selected, out LinkedList<int[]> newSelectedPositions)
        {
            newSelectedPositions = new LinkedList<int[]>();
            int radio = 0;
            bool gone = true;

            while (gone)
            {
                int radioPlus1 = radio + 1;
                if (pos[0] + radioPlus1 > selected.GetLength(0))
                {
                    break;
                }
                if (pos[1] + radioPlus1 > selected.GetLength(1))
                {
                    break;
                }
                for (int i = 0; i < radioPlus1; i++)
                {
                    if (selected[pos[0] + radio, pos[1] + i])
                    {
                        gone = false;
                        break;
                    }
                }

                for (int i = 0; i < radioPlus1; i++)
                {
                    if (selected[pos[0] + i, pos[1] + radio])
                    {
                        gone = false;
                        break;
                    }
                }

                if (gone)
                {
                    for (int i = 0; i < radioPlus1; i++)
                    {
                        newSelectedPositions.AddLast(new int[] { pos[0] + radio, pos[1] + i });
                        selected[pos[0] + radio, pos[1] + i] = true;
                    }

                    for (int i = 0; i < radioPlus1 - 1; i++)
                    {
                        newSelectedPositions.AddLast(new int[] { pos[0] + i, pos[1] + radio });
                        selected[pos[0] + i, pos[1] + +radio] = true;
                    }
                    radio++;
                }
            }

            return radio;

        }

        private bool IsPureRectangle(bool[,] selected, out int[] dimension)
        {
            if (GetFirstFree(selected, out int[] pos))
            {
                LinkedList<int[]> newSelectedPositions = new LinkedList<int[]>();
                int n = pos[0];
                int m = pos[1];
                newSelectedPositions.AddLast(pos);
                selected[n, m] = true;

                for (int i = n + 1; i < selected.GetLength(0); i++)
                {
                    if (!selected[i, m])
                    {
                        n = i;
                        newSelectedPositions.AddLast(new int[] { i, m });
                        selected[i, m] = true;
                    }
                }
                n = n - pos[0] + 1;

                for (int i = m + 1; i < selected.GetLength(1); i++)
                {
                    if (!selected[pos[0], i])
                    {
                        m = i;
                        newSelectedPositions.AddLast(new int[] { pos[0], i });
                        selected[pos[0], i] = true;
                    }
                }

                m = m - pos[1] + 1;

                for (int j = 1; j < m; j++)
                {
                    for (int i = 1; i < n; i++)
                    {
                        if (!selected[pos[0] + i, pos[1] + j])
                        {
                            newSelectedPositions.AddLast(new int[] { pos[0] + i, pos[1] + j });
                            selected[pos[0] + i, pos[1] + j] = true;
                        }
                    }
                }

                bool result = GetFirstFree(selected, out int[] posnew);

                foreach (var item in newSelectedPositions)
                {
                    selected[item[0], item[1]] = false;
                }

                dimension = result ? null : new int[] { n, m };
                return !result;
            }
            else
            {
                dimension = new int[] { 0, 0 };
                return true;
            }
        }

        private void FreeNewSelectedPositions(LinkedList<int[]> newSelectedPositions, bool[,] selected)
        {
            foreach (var item in newSelectedPositions)
            {
                selected[item[0], item[1]] = false;
            }
        }

        private bool TrySelect(int radio, int[] pos, bool[,] selected, LinkedList<int[]> newSelectedPositions)
        {

            for (int i = 0; i < radio; i++)
            {
                if (pos[0] + radio - 1 >= selected.GetLength(0) || pos[1] + i >= selected.GetLength(1) || selected[pos[0] + radio - 1, pos[1] + i])
                {
                    return false;
                }
                if (pos[0] + i >= selected.GetLength(0) || pos[1] + radio - 1 >= selected.GetLength(1) || selected[pos[0] + i, pos[1] + radio - 1])
                {
                    return false;
                }
            }

            for (int i = 0; i < radio; i++)
            {

                newSelectedPositions.AddLast(new int[] { pos[0] + radio - 1, pos[1] + i });
                selected[pos[0] + radio - 1, pos[1] + i] = true;

                newSelectedPositions.AddLast(new int[] { pos[0] + i, pos[1] + radio - 1 });
                selected[pos[0] + i, pos[1] + radio - 1] = true;
            }

            return true;
        }

        private bool GetFirstFree(bool[,] selected, out int[] pos)
        {
            for (int i = 0; i < selected.GetLength(0); i++)
            {
                for (int j = 0; j < selected.GetLength(1); j++)
                {
                    if (!selected[i, j])
                    {
                        pos = new int[] { i, j };
                        return true;
                    }
                }
            }

            pos = null;
            return false;
        }
    }

    internal class Info
    {
        public int Result { get; internal set; }
    }

    /*
      internal class Info
    {
        public int Result { get; internal set; }
    }
    */
}
