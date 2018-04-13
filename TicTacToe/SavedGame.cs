using System.Collections.Generic;

namespace TicTacToe
{
    public class SavedGame
    {
        public SavedGame(char[][] board, char player1Symbol, char player2Symbol)
        {
            Board = board;
            Player1Symbol = player1Symbol;
            Player2Symbol = player2Symbol;
        }

        public char[][] Board { get; }
        public char Player1Symbol { get; }
        public char Player2Symbol { get; }
    }
}