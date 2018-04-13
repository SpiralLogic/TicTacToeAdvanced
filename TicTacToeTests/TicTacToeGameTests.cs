using TicTacToe;
using TicTacToe.GameState;
using TicTacToe.TurnStatus;
using Xunit;
using Coordinate = System.Drawing.Point;

namespace TicTacToeTests
{
    public class TicTacToeGameTests
    {
        private readonly Player _testPlayer1 = new Player("Player 1", 'X');
        private readonly Player _testPlayer2 = new Player("Player 2", 'O');
        private const int BoardLength = 3;

        [Fact]
        public void InitialGameHasEmptyBoard()
        {
            string[] expected =
            {
                "· · ·",
                "· · ·",
                "· · ·"
            };

            var game = new Game(BoardLength, _testPlayer1, _testPlayer2);

            Assert.Equal(string.Join('\n', expected), game.DescribeBoard());
        }

        [Fact]
        public void EnteringInvalidMoveHasInvalidTurnStatus()
        {
            string[] expected =
            {
                "· · ·",
                "· · ·",
                "· · ·"
            };

            var game = new Game(BoardLength, _testPlayer1, _testPlayer2);

            Assert.IsType<CoordinateInvalid>(game.TakeTurn(new Coordinate(0, 1)));
            Assert.Equal(string.Join('\n', expected), game.DescribeBoard());
        }

        [Fact]
        public void TakingValidTurnPlacesPlayerSymbolInCorrectPosition()
        {
            string[] before =
            {
                "· · ·",
                "· · ·",
                "· · ·"
            };

            string[] expected =
            {
                "X · ·",
                "· · ·",
                "· · ·"
            };

            var game = new Game(BoardLength, _testPlayer1, _testPlayer2);

            Assert.IsType<TurnSuccess>(game.TakeTurn(new Coordinate(1, 1)));
            Assert.Equal(string.Join('\n', expected), game.DescribeBoard());
        }

        [Fact]
        public void PlacingAPieceInAPositionAlreadyOccupiedGivesError()
        {
            var game = new Game(BoardLength, _testPlayer1, _testPlayer2);

            game.TakeTurn(new Coordinate(1, 1));
            Assert.IsType<CoordinateAlreadyTaken>(game.TakeTurn(new Coordinate(1, 1)));
        }

        [Fact]
        public void TakingMultipleTurnsAlternatesPlayerSymbols()
        {
            string[] expected =
            {
                "X O X",
                "O X O",
                "· · ·"
            };

            var game = new Game(BoardLength, _testPlayer1, _testPlayer2);

            var firstPlayer = game.CurrentPlayer;

            game.TakeTurn(new Coordinate(1, 1));
            var secondPlayer = game.CurrentPlayer;

            game.TakeTurn(new Coordinate(1, 2));
            game.TakeTurn(new Coordinate(1, 3));
            game.TakeTurn(new Coordinate(2, 1));
            game.TakeTurn(new Coordinate(2, 2));
            game.TakeTurn(new Coordinate(2, 3));

            Assert.Equal(_testPlayer1.Symbol, firstPlayer.Symbol);
            Assert.Equal(_testPlayer2.Symbol, secondPlayer.Symbol);
            Assert.Equal(string.Join('\n', expected), game.DescribeBoard());
        }

        [Fact]
        public void TheGameEndsIfAPlayerForfeits()
        {
            string[] expected =
            {
                "· · ·",
                "· · ·",
                "· · ·"
            };

            var game = new Game(BoardLength, _testPlayer1, _testPlayer2);
            game.ForfeitGame();

            Assert.IsType<GameForfeit>(game.GameState);
            Assert.Equal(string.Join('\n', expected), game.DescribeBoard());
        }

        [Fact]
        public void TheGameIsWonWhenAPlayerTakesADiagonalLeftToRight()
        {
            string[] expected =
            {
                "O O X",
                "· X ·",
                "X · ·"
            };

            var game = new Game(BoardLength, _testPlayer1, _testPlayer2);

            game.TakeTurn(new Coordinate(3, 1));
            game.TakeTurn(new Coordinate(1, 1));
            game.TakeTurn(new Coordinate(2, 2));
            game.TakeTurn(new Coordinate(1, 2));

            var statusBeforeWinningTurn = game.GameState;
            game.TakeTurn(new Coordinate(1, 3));

            Assert.IsType<GameInProgress>(statusBeforeWinningTurn);
            Assert.Equal(_testPlayer1.Symbol, game.CurrentPlayer.Symbol);
            Assert.IsType<GameWon>(game.GameState);
            Assert.Equal(string.Join('\n', expected), game.DescribeBoard());
        }

        [Fact]
        public void TheGameIsWonWhenAPlayerTakesADiagonalRightToLeft()
        {
            string[] expected =
            {
                "X O O",
                "· X ·",
                "· · X"
            };

            var game = new Game(BoardLength, _testPlayer1, _testPlayer2);

            game.TakeTurn(new Coordinate(1, 1));
            game.TakeTurn(new Coordinate(1, 3));
            game.TakeTurn(new Coordinate(2, 2));
            game.TakeTurn(new Coordinate(1, 2));

            var statusBeforeWinningTurn = game.GameState;
            game.TakeTurn(new Coordinate(3, 3));

            Assert.IsType<GameInProgress>(statusBeforeWinningTurn);
            Assert.Equal(_testPlayer1.Symbol, game.CurrentPlayer.Symbol);
            Assert.IsType<GameWon>(game.GameState);
            Assert.Equal(string.Join('\n', expected), game.DescribeBoard());
        }

        [Fact]
        public void TheGameIsWonWhenAPlayerOccupiesColumn()
        {
            string[] expected =
            {
                "X O X",
                "· O ·",
                "X O ·"
            };

            var game = new Game(BoardLength, _testPlayer1, _testPlayer2);

            game.TakeTurn(new Coordinate(1, 1));
            game.TakeTurn(new Coordinate(1, 2));
            game.TakeTurn(new Coordinate(1, 3));
            game.TakeTurn(new Coordinate(2, 2));
            game.TakeTurn(new Coordinate(3, 1));

            var statusBeforeWinningTurn = game.GameState;
            game.TakeTurn(new Coordinate(3, 2));

            Assert.IsType<GameInProgress>(statusBeforeWinningTurn);
            Assert.Equal(_testPlayer2.Symbol, game.CurrentPlayer.Symbol);
            Assert.IsType<GameWon>(game.GameState);
            Assert.Equal(string.Join('\n', expected), game.DescribeBoard());
        }

        [Fact]
        public void TheGameIsWonWhenAPlayerOccupiesRow()
        {
            string[] expected =
            {
                "X X X",
                "· · ·",
                "O · O"
            };

            var game = new Game(BoardLength, _testPlayer1, _testPlayer2);

            game.TakeTurn(new Coordinate(1, 1));
            game.TakeTurn(new Coordinate(3, 1));
            game.TakeTurn(new Coordinate(1, 2));
            game.TakeTurn(new Coordinate(3, 3));

            var statusBeforeWinningTurn = game.GameState;
            game.TakeTurn(new Coordinate(1, 3));

            Assert.IsType<GameInProgress>(statusBeforeWinningTurn);
            Assert.IsType<GameWon>(game.GameState);
            Assert.Equal(_testPlayer1.Symbol, game.CurrentPlayer.Symbol);
            Assert.Equal(string.Join('\n', expected), game.DescribeBoard());
        }
    }
}