using System.Collections.Generic;
using System.Linq;
using Game = TicTacToe.TicTacToeGame;

namespace TicTacToeWebApp.Models
{
    public class GameModel
    {
        public IEnumerable<IEnumerable<char>> Board;
        public string GameState;

        public GameModel(Game game)
        {
            GameState = game.GameState.Describe;
            Board = CreateBoardCharArray(game.DescribeBoard());
        }
        
        private IEnumerable<IEnumerable<char>> CreateBoardCharArray(string board)
        {
            return board.Split('\n').Select(row => row.Trim().Split(' ').Select(coord => coord.Trim().First()).ToArray()).ToArray();
        }
    }
}