using TicTacToe;
using TicTacToe.GameState;
using Xunit;

namespace TicTacToeTests
{
    public class TicTacToeGameFactoryTests
    {
        [Fact]
        public void CanInitializeGameFactory()
        {
            var gameFactory = new GameFactory();

            Assert.NotNull(gameFactory);
        }

        [Fact]
        public void GameFactoryCreatesAValidInitialGame()
        {
            string[] expectedBoard =
            {
                "· · ·",
                "· · ·",
                "· · ·"
            };

            var savedBoard = new[]
            {
                new[] {'·', '·', '·'},
                new[] {'·', '·', '·'},
                new[] {'·', '·', '·'}
            };

            var savedGame = new SavedGame(savedBoard, 'X', 'O');
            var gameFactory = new GameFactory();

            var game = gameFactory.FromSavedGame(savedGame);

            Assert.Equal(string.Join('\n', expectedBoard), game.DescribeBoard());
            Assert.Equal("X", game.CurrentPlayer.Symbol.ToString());
            Assert.Equal("X", game.Player1.Symbol.ToString());
            Assert.Equal("O", game.Player2.Symbol.ToString());
            Assert.IsType<GameInProgress>(game.GameState);
        }

        [Fact]
        public void GameFactoryCreatesAValidGameAtPlayer1Turn()
        {
            string[] expectedBoard =
            {
                "X · ·",
                "· O O",
                "· · X"
            };

            var savedBoard = new[]
            {
                new[] {'X', '·', '·'},
                new[] {'·', 'O', 'O'},
                new[] {'·', '·', 'X'}
            };

            var savedGame = new SavedGame(savedBoard, 'X', 'O');
            var gameFactory = new GameFactory();

            var game = gameFactory.FromSavedGame(savedGame);

            Assert.Equal(string.Join('\n', expectedBoard), game.DescribeBoard());
            Assert.Equal("X", game.CurrentPlayer.Symbol.ToString());
            Assert.Equal("X", game.Player1.Symbol.ToString());
            Assert.Equal("O", game.Player2.Symbol.ToString());
            Assert.IsType<GameInProgress>(game.GameState);
        }

        [Fact]
        public void GameFactoryCreatesAValidGameAtPlayer2Turn()
        {
            string[] expectedBoard =
            {
                "X · ·",
                "· O O",
                "X · X"
            };

            var savedBoard = new[]
            {
                new[] {'X', '·', '·'},
                new[] {'·', 'O', 'O'},
                new[] {'X', '·', 'X'}
            };

            var savedGame = new SavedGame(savedBoard, 'X', 'O');
            var gameFactory = new GameFactory();

            var game = gameFactory.FromSavedGame(savedGame);

            Assert.Equal(string.Join('\n', expectedBoard), game.DescribeBoard());
            Assert.Equal("O", game.CurrentPlayer.Symbol.ToString());
            Assert.Equal("X", game.Player1.Symbol.ToString());
            Assert.Equal("O", game.Player2.Symbol.ToString());
            Assert.IsType<GameInProgress>(game.GameState);
        }

        [Fact]
        public void GameFactoryCreatesWithValidPlayerSymbols()
        {
            var savedBoard = new[]
            {
                new[] {'·', '·', '·'},
                new[] {'·', 'P', 'Q'},
                new[] {'·', '·', '·'}
            };

            var savedGame = new SavedGame(savedBoard, 'P', 'Q');
            var gameFactory = new GameFactory();

            var game = gameFactory.FromSavedGame(savedGame);

            Assert.Equal("P", game.CurrentPlayer.Symbol.ToString());
            Assert.Equal("P", game.Player1.Symbol.ToString());
            Assert.Equal("Q", game.Player2.Symbol.ToString());
            Assert.IsType<GameInProgress>(game.GameState);
        }
        [Fact]
        public void GameFactorySetsGameStateToWon()
        {
            var savedBoard = new[]
            {
                new[] {'X', 'X', '·'},
                new[] {'O', 'O', 'O'},
                new[] {'X', 'O', 'X'}
            };

            var savedGame = new SavedGame(savedBoard, 'X', 'O');
            var gameFactory = new GameFactory();

            var game = gameFactory.FromSavedGame(savedGame);

            Assert.IsType<GameWon>(game.GameState);
            Assert.Equal("O", game.CurrentPlayer.Symbol.ToString());
    }

        [Fact]
        public void GameFactorySetsGameStateToDraw()
        {
            var savedBoard = new[]
            {
                new[] {'O', 'X', 'O'},
                new[] {'X', 'O', 'X'},
                new[] {'O', 'X', 'X'}
            };

            var savedGame = new SavedGame(savedBoard, 'X', 'O');
            var gameFactory = new GameFactory();

            var game = gameFactory.FromSavedGame(savedGame);

            Assert.IsType<GameDraw>(game.GameState);
            Assert.Equal("X", game.CurrentPlayer.Symbol.ToString());
        }
    }
}