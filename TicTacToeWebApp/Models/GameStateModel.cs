using System.Linq;
using Game = TicTacToe.TicTacToeGame;

namespace TicTacToeWebApp.Models
{
    public class GameStateModel
    {
        public string GameSate;
        public char[] Board;

        public GameStateModel(Game game)
        {
            GameSate = game.GameState.Describe;
            Board = CreateBoardCharArray(game.DescribeBoard());
        }
        
        private char[] CreateBoardCharArray(string board)
        {
            return board.Split(null).Select(s => s.Trim().First()).ToArray();
        }
    }
}