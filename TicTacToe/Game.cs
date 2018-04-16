using System.Collections.Generic;
using System.Linq;
using TicTacToe.GameState;
using TicTacToe.TurnStatus;
using TicTacToe.WinConditions;
using Coordinate = System.Drawing.Point;

namespace TicTacToe
{
    public class Game
    {
        private readonly Board _board;

        public Player Player1 { get; }

        public Player Player2 { get; }

        public Player CurrentPlayer { get; private set; }

        public IGameState GameState { get; private set; }

        private readonly IEnumerable<IWinCondition> _winConditions;

        public Game(int boardLength, Player player1 = null, Player player2 = null)
        {
            _winConditions = CreateWinConditions();

            _board = new Board(boardLength);
            Player1 = player1 ?? new Player("Player 1", new Symbol('X'));
            Player2 = player2 ?? new Player("Player 2", new Symbol('O'));
            CurrentPlayer = Player1;
            GameState = new GameInProgress(CurrentPlayer);
        }

        internal Game(Board board, Player player1, Player player2) : this(board.BoardLength, player1, player2)
        {
            _board = board;
            CurrentPlayer = _board.Count(Player1.Symbol) <= _board.Count(Player2.Symbol) ? Player2 : Player1;
            
            UpdateGameState();
        }

        public ITurnStatus TakeTurn(Coordinate coordinate)
        {
            if (!(GameState is GameInProgress))
            {
                return new TurnGameOver();
            }

            if (!_board.IsOnBoard(coordinate))
            {
                return new CoordinateInvalid();
            }

            if (!_board.IsEmptyAt(coordinate))
            {
                return new CoordinateAlreadyTaken();
            }

            _board.Set(coordinate, CurrentPlayer.Symbol);

            UpdateGameState();

            return new TurnSuccess();
        }

        public void ForfeitGame()
        {
            if (GameState is GameInProgress)
            {
                GameState = new GameForfeit(CurrentPlayer);
            }
        }

        public string DescribeBoard()
        {
            return _board.ToString();
        }

        private void UpdateGameState()
        {
            if (IsGameWon())
            {
                GameState = new GameWon(CurrentPlayer);
                return;
            }

            if (_board.IsFull())
            {
                GameState = new GameDraw();
                return;
            }

            if (GameState is GameInProgress)
            {
                SwitchPlayers();
            }

            GameState = new GameInProgress(CurrentPlayer);
        }

        private bool IsGameWon()
        {
            return _winConditions.Any(wc => wc.HasWon(CurrentPlayer.Symbol, _board));
        }

        private void SwitchPlayers()
        {
            CurrentPlayer = Equals(CurrentPlayer, Player1) ? Player2 : Player1;
        }

        private IEnumerable<IWinCondition> CreateWinConditions()
        {
            return new HashSet<IWinCondition>
            {
                new HorizontalWinCondition(),
                new VerticalWinCondition(),
                new DiagonalWinCondition()
            };
        }
    }
}