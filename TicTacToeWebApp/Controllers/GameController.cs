using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicTacToe;
using TicTacToeWebApp.Models;
using Coordinate = System.Drawing.Point;

namespace TicTacToeWebApp.Controllers
{
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private const string SessionKeyGame = "_Game";

        [HttpPost("{boardLength}")]    
        public IActionResult New(int boardLength=3)
        {
            var game = CreateNewGame(boardLength);
            var gamestate = new GameModel(game);

            return new JsonResult(gamestate);
        }

        [HttpPut("forfeit")]
        public IActionResult Forfeit()
        {
            var game = GetCurrentGame();
            game.ForfeitGame();
            
            var gamestate = new GameModel(game);

            return new JsonResult(gamestate);
        }

        [HttpPut("taketurn/{x}/{y}")]
        public IActionResult TakeTurn(int x, int y)
        {
            var game = GetCurrentGame();
            var turnStatus = game.TakeTurn(new Coordinate(x, y));

            SaveGameInSession(game);

            return new JsonResult(new TurnStatusModel(game, turnStatus));
        }

        private TicTacToeGame CreateNewGame(int boardLength)
        {
            var game = new TicTacToeGame(boardLength);
            SaveGameInSession(game);

            return game;
        }

        private TicTacToeGame GetCurrentGame()
        {
            return TicTacToeSerializer.DeserializeJson(HttpContext.Session.GetString(SessionKeyGame));
        }

        private void SaveGameInSession(TicTacToeGame game)
        {
            HttpContext.Session.SetString(SessionKeyGame, TicTacToeSerializer.SerializeToJson(game));
        }
    }
}