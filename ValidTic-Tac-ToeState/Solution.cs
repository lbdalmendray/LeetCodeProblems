using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidTic_Tac_ToeState
{
    public class Solution
    {
        public bool ValidTicTacToe(string[] board)
        {
            LinkedList<Tuple<int,int>> empetyList = new LinkedList<Tuple<int,int>>();
            LinkedList<Tuple<int, int>> xList = new LinkedList<Tuple<int, int>>();
            LinkedList<Tuple<int, int>> oList = new LinkedList<Tuple<int, int>>();
            
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ( board[i][j] == ' ' )
                    {
                        empetyList.AddLast(new Tuple<int, int>(i, j));
                    }
                    else if (board[i][j] == 'X')
                    {
                        xList.AddLast(new Tuple<int, int>(i, j));

                    }
                    else
                    {
                        oList.AddLast(new Tuple<int, int>(i, j));
                    }
                }
            }

            if (oList.Count > xList.Count)
                return false;
            else if (xList.Count - oList.Count > 1)
                return false;
            else if (xList.Count == 5 && oList.Count == 4)
            {
                if (!HasThree(oList))
                    return true;
                return false;
            }

            else if (xList.Count == 4)
            {
                if (oList.Count == 4)
                {
                    if (HasThree(xList))
                        return false;
                    return true;
                }
                if (HasThree(oList))
                    return false;
                return true;
            }
            else if (xList.Count == 3 && oList.Count == 3 && HasThree(xList))
                return false;

            return true;
        }

        private bool HasThree(LinkedList<Tuple<int, int>> List)
        {
            if (List.Count < 3)
                return false;

            if ( List.Count == 3)
            {
                if (IsDiagonal(List))
                    return true;
                else if (IsVertical(List))
                    return true;
                else if (IsHorizontal(List))
                    return true;
            }
            else if ( List.Count == 4)
            {
                LinkedListNode<Tuple<int, int>> node = List.First;
                var next1 = List.First.Next;
                var next2 = List.First.Next.Next;
                var next3 = List.First.Next.Next.Next ;
                List.RemoveFirst();
                if (HasThree(List))
                    return true;
                List.AddFirst(node);

                List.Remove(next1);

                if (HasThree(List))
                    return true;
                List.AddAfter(node, next1);


                List.Remove(next2);

                if (HasThree(List))
                    return true;
                List.AddAfter(next1, next2);

                List.Remove(next3);

                if (HasThree(List))
                    return true;
                List.AddAfter(next2, next3);

            }

            return false;

        }

        private bool IsVertical(LinkedList<Tuple<int, int>> list)
        {
            var first = list.First;
            return (first.Value.Item2 == first.Next.Value.Item2 && first.Value.Item2 == first.Next.Next.Value.Item2);
        }

        private bool IsHorizontal(LinkedList<Tuple<int, int>> list)
        {
            var first = list.First;
            return (first.Value.Item1 == first.Next.Value.Item1 && first.Value.Item1 == first.Next.Next.Value.Item1);
        }

        private bool IsDiagonal(LinkedList<Tuple<int, int>> list)
        {
            var first = list.First;
            return (first.Value.Item1 == first.Next.Value.Item1-1  && first.Value.Item1 == first.Next.Next.Value.Item1-2)
                && (first.Value.Item2 == first.Next.Value.Item2-1 && first.Value.Item2 == first.Next.Next.Value.Item2-2)
                
                ||

                (first.Value.Item1 == first.Next.Value.Item1 -1 && first.Value.Item1 == first.Next.Next.Value.Item1 - 2)
                && (first.Value.Item2 == first.Next.Value.Item2 + 1 && first.Value.Item2 == first.Next.Next.Value.Item2 + 2) ;
        }
    }
}
