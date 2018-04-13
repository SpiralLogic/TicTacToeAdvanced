using System.Collections.Generic;
using System.Linq;
using TicTacToe;

namespace TicTacToeWebApp.Models
{
    public class GameModel
    {
        public char[][] Board;
        public string Player1;
        public string Player2;
        public string GameState;

        public GameModel()
        {
        }

        public GameModel(Game game)
        {
            Board = CreateBoardCharArray(game.DescribeBoard());
            GameState = game.GameState.Describe;
            Player1 = game.Player1.Symbol.ToString();
            Player2 = game.Player2.Symbol.ToString();
        }

        private char[][] CreateBoardCharArray(string board)
        {
            return board.Split('\n').Select(row => row.Trim().Split(' ').Select(coord => coord.Trim().First()).ToArray()).ToArray();
        }
    }
}