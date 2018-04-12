using Coordinate = System.Drawing.Point;

namespace TicTacToe.WinConditions
{
    internal class DiagonalWinCondition : IWinCondition
    {
        public bool HasWon(Symbol symbol, Board board)
        {
            var hasWonLeftRoRight = true;
            var hasWonRightToLeft = true;

            for (var i = 1; i <= board.BoardLength; i++)
            {
                hasWonLeftRoRight &= symbol == board.GetSymbolAt(new Coordinate(i, i));
                hasWonRightToLeft &= symbol == board.GetSymbolAt(new Coordinate(i, board.BoardLength + 1 - i));
            }

            return hasWonLeftRoRight || hasWonRightToLeft;
        }
    }
}