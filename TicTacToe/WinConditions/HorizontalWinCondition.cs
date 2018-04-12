using Coordinate = System.Drawing.Point;

namespace TicTacToe.WinConditions
{
    internal class HorizontalWinCondition : IWinCondition
    {
        public bool HasWon(Symbol symbol, Board board)
        {
            for (var row = 1; row <= board.BoardLength; row++)
            {
                if (DoesSymbolFillRow(symbol, board, row)) return true;
            }

            return false;
        }

        private static bool DoesSymbolFillRow(Symbol symbol, Board board, int x)
        {
            for (var column = 1; column <= board.BoardLength; column++)
            {
                if (symbol != board.GetSymbolAt(new Coordinate(x, column)))
                {
                    return false;
                }
            }

            return true;
        }
    }
}