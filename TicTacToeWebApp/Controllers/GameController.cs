using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicTacToe;
using Coordinate = System.Drawing.Point;

namespace TicTacToeWebApp.Controllers
{
    public class GameController : Controller
    {
        private const string SessionKeyGame = "_Game";

        [Route("Game/NewGame")]
        public IActionResult NewGame()
        {
            CreateNewGame();
            var result = new ContentResult {Content = "New Game"};

            return result;
        }

        [Route("Game/TakeTurn/{x}/{y}")]
        public IActionResult TakeTurn(int x, int y)
        {
            var game = GetCurrentGame();
            var turnStatus = game.TakeTurn(new Coordinate(x, y));
            var gameState = game.GameState;

            var result = new ContentResult {Content = turnStatus.Describe + "\n" + game.DescribeBoard() + "\n" + gameState.Describe};
            HttpContext.Session.SetString(SessionKeyGame, TicTacToeSerializer.SerializeToJson(game));

            return result;
        }

        [Route("Game")]
        [Route("Game/Board")]
        public IActionResult Board()
        {
            var result = new ContentResult {Content = GetCurrentGame().DescribeBoard()};

            return result;
        }

        private TicTacToeGame GetCurrentGame()
        {
            var game = TicTacToeSerializer.DeserializeJson(HttpContext.Session.GetString(SessionKeyGame))
                       ?? CreateNewGame();

            return game;
        }

        private TicTacToeGame CreateNewGame()
        {
            var game = new TicTacToeGame(3, new Player("Player 1", 'X'), new Player("Player 2", 'O'));
            HttpContext.Session.SetString(SessionKeyGame, TicTacToeSerializer.SerializeToJson(game));

            return game;
        }
    }
}