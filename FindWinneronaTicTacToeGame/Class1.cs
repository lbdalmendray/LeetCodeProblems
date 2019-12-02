using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindWinneronaTicTacToeGame
{
    public class Solution
    {
        public string Tictactoe(int[][] moves)
        {
            if (moves.Length < 5)
                return "Pending";

            char?[,] game = new char?[3, 3];
            int i = 0;
            foreach (var item in moves)
            {
                if (i == 0)
                {
                    game[item[0],item[1]] = 'X';
                    i++;
                }
                else
                {
                    game[item[0], item[1]] = 'O';
                    i--;
                }                      
            }
            bool winner;
            if (IsVerticalWinner(game, out winner) || IsHorizontalWinner(game, out winner) || IsDiagonal(game, out winner))
            {
                return winner ? "A" : "B";
            }
            if ( moves.Length == 9)
            {
                return "Draw";
            }
            return "Pending";
        }

        private bool IsDiagonal(char?[,] game, out bool winner)
        {
            if ( game[0,0].HasValue && game[1, 1].HasValue && game[2, 2].HasValue && game[0,0].Value == game[1,1].Value && game[0, 0].Value == game[2, 2].Value)
            {
                winner = game[0, 0].Value == 'X';
                return true;
            }
            else if (game[2, 0].HasValue && game[1, 1].HasValue && game[0, 2].HasValue && game[2, 0].Value == game[1, 1].Value && game[2, 0].Value == game[0, 2].Value)
            {
                winner = game[2, 0].Value == 'X';
                return true;
            }
            winner = false;
            return false;
        }

        private bool IsHorizontalWinner(char?[,] game, out bool winner)
        {
            for (int i = 0; i < 3; i++)
            {
                if (game[i, 0].HasValue && game[i, 1].HasValue && game[i, 2].HasValue && game[i, 0].Value == game[i, 1].Value && game[i, 0].Value == game[i, 2].Value)
                {
                    winner = game[i, 0].Value == 'X';
                    return true;
                }
            }
            winner = false;
            return false;
        }

        private bool IsVerticalWinner(char?[,] game, out bool winner)
        {
            for (int i = 0; i < 3; i++)
            {
                if ( game[0,i].HasValue && game[1, i].HasValue && game[2, i].HasValue && game[0, i].Value == game[1, i].Value && game[0, i].Value == game[ 2, i].Value)
                {
                    winner = game[0, i].Value == 'X';
                    return true;
                }
            }
            winner = false;
            return false;
        }
    }
}
