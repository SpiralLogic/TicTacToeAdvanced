using System;
using System.Linq;
using Coordinate = System.Drawing.Point;

namespace TicTacToe
{
    public class Board
    {
        private readonly Symbol _emptySymbol;
        private readonly Symbol[][] _board;

        public int BoardLength => _board.GetLength(0);

        public Board(int boardLength, Symbol emptySymbol = null)
        {
            if (boardLength < 3) throw new ArgumentOutOfRangeException(nameof(boardLength));

            _board = new Symbol[boardLength][];
            _emptySymbol = emptySymbol ?? new Symbol('·');

            for (var row = 0; row < boardLength; row++)
            {
                _board[row] = new Symbol[boardLength];
                for (var column = 0; column < boardLength; column++)
                {
                    _board[row][column] = _emptySymbol;
                }
            }
        }

        public void Set(Coordinate coordinate, Symbol symbol)
        {
            _board[coordinate.X - 1][coordinate.Y - 1] = symbol;
        }

        public bool IsEmptyAt(Coordinate coordinate)
        {
            return _board[coordinate.X - 1][coordinate.Y - 1] == _emptySymbol;
        }

        public bool IsOnBoard(Coordinate coordinate)
        {
            return coordinate.X >= 1 && coordinate.X <= BoardLength && coordinate.Y >= 1 && coordinate.Y <= BoardLength;
        }

        public bool IsFull()
        {
            return _board.SelectMany(b => b).All(coordinate => coordinate != _emptySymbol);
        }

        public Symbol GetSymbolAt(Coordinate coordinate)
        {
            return _board[coordinate.X - 1][coordinate.Y - 1];
        }

        internal int Count(Symbol symbol)
        {
            return _board.SelectMany(r => r).Count(s => s == symbol);
        }

        public override string ToString()
        {
            var output = string.Empty;
            for (var row = 0; row < BoardLength; row++)
            {
                for (var column = 0; column < BoardLength; column++)
                {
                    output += _board[row][column] + " ";
                }

                output = output.TrimEnd() + '\n';
            }

            return output.TrimEnd();
        }
    }
}