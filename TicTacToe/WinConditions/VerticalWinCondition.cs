using Coordinate = System.Drawing.Point;

namespace TicTacToe.WinConditions
{
    internal class VerticalWinCondition : IWinCondition
    {
        public bool HasWon(Symbol symbol, Board board)
        {
            for (var row = 1; row <= board.BoardLength; row++)
            {
                if (DoesSymbolFillColumn(symbol, board, row)) return true;
            }

            return false;
        }

        private static bool DoesSymbolFillColumn(Symbol symbol, Board board, int y)
        {
            for (var row = 1; row <= board.BoardLength; row++)
            {
                if (symbol != board.GetSymbolAt(new Coordinate(row, y)))
                {
                    return false;
                }
            }

            return true;
        }
    }
}