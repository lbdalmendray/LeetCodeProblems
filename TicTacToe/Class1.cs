namespace TicTacToe
{
    public class TicTacToe
    {
        private readonly int n;
        private readonly int[,][] info;
        private const int lIndex = 0;
        private const int rIndex = 1;
        private const int uIndex = 2;
        private const int dIndex = 3;
        private const int urIndex = 4;
        private const int drIndex = 5;
        private const int ulIndex = 6;
        private const int dlIndex = 7;
        private const int playerIndex = 8;

        public TicTacToe(int n)
        {
            this.n = n;
            info = new int[n, n][];
        }

        public int Move(int row, int col, int player)
        {
            // INITIALIZE THE INFO AT THAT POINT ///// 

            if (info[row, col] == null)
            {
                info[row, col] = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, player };
            }

            /////
            
            if (col > 0 && info[row , col - 1]?[playerIndex] == player) // LEFT
            {
                info[row, col][lIndex] += info[row, col - 1][lIndex];
            }
            if (col < n - 1 && info[row , col + 1]?[playerIndex] == player) // RIGHT
            {
                info[row, col][rIndex] += info[row, col + 1][rIndex];
            }

            if (row > 0 && info[row - 1, col]?[playerIndex] == player) // UP 
            {
                info[row, col][uIndex] += info[row - 1, col][uIndex];
            }
            if (row < n-1 && info[row + 1, col]?[playerIndex] == player) // DOWN 
            {
                info[row, col][dIndex] += info[row + 1, col][dIndex];
            }

            if (col > 0 && row > 0 && info[row - 1, col - 1]?[playerIndex] == player) // UP LEFT
            {
                info[row, col][ulIndex] += info[row-1, col - 1][ulIndex];
            }

            if (col > 0 && row < n-1 && info[row + 1, col - 1]?[playerIndex] == player) // DOWN LEFT
            {
                info[row, col][dlIndex] += info[row + 1, col - 1][dlIndex];
            }

            if (col < n-1 && row > 0 && info[row - 1, col + 1]?[playerIndex] == player) // UP RIGHT
            {
                info[row, col][urIndex] += info[row - 1, col + 1][urIndex];
            }

            if (col < n - 1 && row < n-1 && info[row + 1, col + 1]?[playerIndex] == player) // DOWN RIGHT
            {
                info[row, col][drIndex] += info[row + 1, col + 1][drIndex];
            }

            //// UPDATING EXTREMES 

            if (col > 0 && info[row, col - 1]?[playerIndex] == player) // LEFT
            {
                var distance = info[row, col - 1][lIndex];
                info[row, col - distance][rIndex] += info[row, col][rIndex] ;
                if (info[row, col - distance][rIndex] == n)
                    return player;
            }
            if (col < n - 1 && info[row, col + 1]?[playerIndex] == player) // RIGHT
            {
                var distance = info[row, col + 1][rIndex];
                info[row, col + distance][lIndex] += info[row, col][lIndex]; ;
                if (info[row, col + distance][lIndex] == n)
                    return player;
            }

            if (row > 0 && info[row - 1, col]?[playerIndex] == player) // UP 
            {
                var distance = info[row - 1, col][uIndex];
                info[row - distance, col][dIndex] += info[row, col][dIndex];
                if (info[row - distance, col][dIndex] == n)
                    return player;
            }
            if (row < n - 1 && info[row + 1, col]?[playerIndex] == player) // DOWN 
            {
                var distance = info[row + 1, col][dIndex];
                info[row + distance, col][uIndex] += info[row, col][uIndex];
                if (info[row + distance, col][uIndex] == n)
                    return player;
            }

            if (col > 0 && row > 0 && info[row - 1, col - 1]?[playerIndex] == player) // UP LEFT
            {
                var distance = info[row - 1, col - 1][ulIndex];
                info[row - distance, col - distance][drIndex] += info[row, col][drIndex];
                if (info[row - distance, col - distance][drIndex] == n)
                    return player;
            }

            if (col > 0 && row < n - 1 && info[row + 1, col - 1]?[playerIndex] == player) // DOWN LEFT
            {
                var distance = info[row + 1, col - 1][dlIndex];
                info[row + distance, col - distance][urIndex]  += info[row, col][urIndex];
                if (info[row + distance, col - distance][urIndex] == n)
                    return player;
            }

            if (col < n - 1 && row > 0 && info[row - 1, col + 1]?[playerIndex] == player) // UP RIGHT
            {
                var distance = info[row - 1, col + 1][urIndex];
                info[row - distance, col + distance][dlIndex]  += info[row, col][dlIndex];
                if (info[row - distance, col + distance][dlIndex] == n)
                    return player;
            }

            if (col < n - 1 && row < n - 1 && info[row + 1, col + 1]?[playerIndex] == player) // DOWN RIGHT
            {
                var distance = info[row + 1, col + 1][drIndex];
                info[row + distance, col + distance][ulIndex] += info[row, col][ulIndex];
                if (info[row + distance, col + distance][ulIndex] == n)
                    return player;
            }

            return 0;
        }
    }

    /**
     * Your TicTacToe object will be instantiated and called as such:
     * TicTacToe obj = new TicTacToe(n);
     * int param_1 = obj.Move(row,col,player);
     */
}
