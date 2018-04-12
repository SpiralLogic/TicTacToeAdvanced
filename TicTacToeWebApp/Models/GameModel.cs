using System.Collections.Generic;
using System.Linq;
using TicTacToe;

namespace TicTacToeWebApp.Models
{
    public class GameModel
    {
        public char[][] Board;
        public string GameState;
        public char Player1;
        public char Player2;

        public GameModel(TicTacToeGame game)
        {
            GameState = game.GameState.Describe;
            Board = CreateBoardCharArray(game.DescribeBoard());
            Player1 = game.Player1.Symbol;
            Player2 = game.Player2.Symbol;
            
        }
        
        private char[][] CreateBoardCharArray(string board)
        {
            return board.Split('\n').Select(row => row.Trim().Split(' ').Select(coord => coord.Trim().First()).ToArray()).ToArray();
        }

    }
}