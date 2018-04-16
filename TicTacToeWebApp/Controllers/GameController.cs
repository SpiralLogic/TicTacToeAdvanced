using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TicTacToe;
using TicTacToeWebApp.Models;
using Coordinate = System.Drawing.Point;

namespace TicTacToeWebApp.Controllers
{
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        [HttpPost("{boardLength}")]
        [Produces("application/json")]
        public IActionResult New(int boardLength = 3)
        {
            var game = CreateNewGame(boardLength);

            return new JsonResult(new GameModel(game));
        }
        
        [HttpPost("{boardLength}/{player1}/{player2}")]
        [Produces("application/json")]
        public IActionResult New(int boardLength, char player1, char player2)
        {
            var game = CreateNewGame(boardLength, player1, player2);

            return new JsonResult(new GameModel(game));
        }

        [HttpPut, Route("forfeit")]
        [Produces("application/json")]
        public IActionResult Forfeit([FromBody] GameModel gameModel)
        {
            var game = CreateGameFromGameModel(gameModel);
            game.ForfeitGame();

            return new JsonResult(new GameModel(game));
        }

        [HttpPut("taketurn/{x}/{y}")]
        [Produces("application/json")]
        public IActionResult TakeTurn(int x, int y, [FromBody] GameModel gameModel)
        {
            var game = CreateGameFromGameModel(gameModel);
            var turnStatus = game.TakeTurn(new Coordinate(x, y));

            return new JsonResult(new TurnStatusModel(game, turnStatus));
        }

        private Game CreateNewGame(int boardLength, char player1 = 'X', char player2 = 'O')
        {
            return new Game(boardLength, new Player("Player 1", player1), new Player("Player 2", player2));
        }

        private static Game CreateGameFromGameModel(GameModel gameModel)
        {
            return new GameFactory().FromSavedGame(new SavedGame(gameModel.Board, gameModel.Player1.FirstOrDefault(), gameModel.Player2.FirstOrDefault()));
        }
    }
}