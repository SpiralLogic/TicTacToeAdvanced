using System;
using System.Collections.Generic;
using System.Linq;
using Coordinate = System.Drawing.Point;

namespace TicTacToe
{
    public class GameFactory
    {
        private int _boardLength;
        private char _emptySymbolChar = '·';
        private IDictionary<char, Symbol> _symbolLookup;

        public Game FromSavedGame(SavedGame savedGame)
        {
            if (savedGame == null)
            {
                throw new ArgumentException(nameof(savedGame));
            }

            _boardLength = savedGame.Board.Length;
            _emptySymbolChar = FindEmptySymbolChar(savedGame);
            _symbolLookup = CreateSymbolLookup(savedGame);

            if (!IsValidSaveGame(savedGame)) throw new ArgumentException("Invalid Save Game");

            return CreateGame(savedGame);
        }

        private Game CreateGame(SavedGame savedGame)
        {
            var board = CreateBoard(savedGame);
            var player1 = new Player("Player 1", savedGame.Player1Symbol);
            var player2 = new Player("Player 2", savedGame.Player2Symbol);

            return new Game(board, player1, player2);
        }

        private Board CreateBoard(SavedGame savedGame)
        {
            var board = new Board(_boardLength, new Symbol(_emptySymbolChar));

            for (var x = 1; x <= _boardLength; x++)
            {
                for (var y = 1; y <= _boardLength; y++)
                {
                    board.Set(new Coordinate(x, y), _symbolLookup[savedGame.Board[x - 1][y - 1]]);
                }
            }

            return board;
        }

        private Dictionary<char, Symbol> CreateSymbolLookup(SavedGame savedGame)
        {
            return new Dictionary<char, Symbol>
            {
                {savedGame.Player1Symbol, new Symbol(savedGame.Player1Symbol)},
                {savedGame.Player2Symbol, new Symbol(savedGame.Player2Symbol)},
                {_emptySymbolChar, new Symbol(_emptySymbolChar)},
            };
        }

        private bool IsValidSaveGame(SavedGame savedGame)
        {
            var allSymbols = savedGame.Board.SelectMany(r => r).ToArray();

            return savedGame.Board.All(r => r.Length == _boardLength) &&
                   HasCorrectNumberOfTurns(savedGame, allSymbols) &&
                   allSymbols.All(IsValidSymbol);
        }

        private static bool HasCorrectNumberOfTurns(SavedGame savedGame, char[] allsymbols)
        {
            var player1Turns = allsymbols.Count(c => c == savedGame.Player1Symbol);
            var player2Turns = allsymbols.Count(c => c == savedGame.Player2Symbol);
            return Math.Abs(player1Turns - player2Turns) <= 1;
        }

        private bool IsValidSymbol(char symbolChar)
        {
            return _symbolLookup.ContainsKey(symbolChar);
        }

        private static char FindEmptySymbolChar(SavedGame savedGame)
        {
            return savedGame.Board.SelectMany(r => r).FirstOrDefault(s => s != savedGame.Player1Symbol && s != savedGame.Player2Symbol);
        }
    }
}