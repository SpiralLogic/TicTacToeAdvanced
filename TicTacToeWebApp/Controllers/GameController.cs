using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicTacToe;
using TicTacToe.GameState;
using TicTacToeWebApp.Models;
using Coordinate = System.Drawing.Point;

namespace TicTacToeWebApp.Controllers
{
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private const string SessionKeyGame = "_Game";

        [HttpPost("{boardLength}")]
        [Produces("application/json")]
        public IActionResult New(int boardLength = 3)
        {
            var game = CreateNewGame(boardLength);

            return StatusCode((int) HttpStatusCode.Created, new JsonResult(new GameModel(game)));
        }

        [HttpPut, Route("forfeit")]
        public IActionResult Forfeit([FromBody] GameModel gameModel)
        {
            var game = CreateGameFromGameModel(gameModel);
            game.ForfeitGame();

            return StatusCode((int) HttpStatusCode.Accepted, new JsonResult(new GameModel(game)));
        }

        [HttpPut("taketurn/{x}/{y}")]
        public IActionResult TakeTurn(int x, int y, [FromBody] GameModel gameModel)
        {
            var game = CreateGameFromGameModel(gameModel);
            var turnStatus = game.TakeTurn(new Coordinate(x, y));

            return StatusCode((int) HttpStatusCode.Accepted, new JsonResult(new TurnStatusModel(game, turnStatus)));
        }

        private Game CreateNewGame(int boardLength)
        {
            return new Game(boardLength);
        }

        private static Game CreateGameFromGameModel(GameModel gameModel)
        {
            return new GameFactory().FromSavedGame(new SavedGame(gameModel.Board, gameModel.Player1.FirstOrDefault(), gameModel.Player2.FirstOrDefault()));
        }
    }
}