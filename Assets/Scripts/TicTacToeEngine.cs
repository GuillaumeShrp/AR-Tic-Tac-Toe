public class TicTacToeEngine
    {
        private int _currentPlayer = 1;
        private int[] _grid = new int[9];

        public void NewGame()
        {
            // Initialize board
            for (int i = 0; i < 9; i++) _grid[i] = 0;

            // set current player to 1
            _currentPlayer = 1;
        }

        public void Place(int gridId)
        {
            // mark the current player's entry in the grid ID
            _grid[gridId] = _currentPlayer;
            _currentPlayer++;
            if (_currentPlayer == 3)
            {
                _currentPlayer = 1;
            }
        }

        public int IsVictory()
        {
            if (PlayerVictory(1)) // returns 1 if player 1 wins
            {
                return 1;
            }
            else if (PlayerVictory(2)) // returns 2 if player 2 wins
            {
                return 2;
            }
            else if (!HasEmptySlot()) // returns -1 if cats game
            {
                return -1;
            }
            
            // returns 0 if still playing
            return 0;
        }

        private bool PlayerVictory(int id)
        {
            if ((_grid[0] == id && _grid[1] == id && _grid[2] == id) ||
                (_grid[3] == id && _grid[4] == id && _grid[5] == id) ||
                (_grid[6] == id && _grid[7] == id && _grid[8] == id) ||

                (_grid[0] == id && _grid[3] == id && _grid[6] == id) ||
                (_grid[1] == id && _grid[4] == id && _grid[7] == id) ||
                (_grid[2] == id && _grid[5] == id && _grid[8] == id) ||

                (_grid[0] == id && _grid[4] == id && _grid[8] == id) ||
                (_grid[2] == id && _grid[4] == id && _grid[6] == id)
                )
            {
                return true;
            }

            return false;
        }

        private bool HasEmptySlot()
        {
            var count = 0;
            foreach (var i in _grid)
            {
                if (i == 0)
                {
                    count++;
                }
            }

            return count > 0;
        }
    }

