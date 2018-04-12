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
        private TicTacToeGame _game;

        [HttpGet("")]
        public IActionResult Game()
        {
            var game = GetCurrentGame();
            var gamestate = new GameModel(game);

            return new JsonResult(gamestate);
        }

        [HttpGet("newgame")]
        public IActionResult NewGame()
        {
            var game = CreateNewGame();
            var gamestate = new GameModel(game);

            return new JsonResult(gamestate);
        }

        [HttpGet("taketurn/{x}/{y}")]
        public IActionResult TakeTurn(int x, int y)
        {
            var game = GetCurrentGame();
            var turnStatus = game.TakeTurn(new Coordinate(x, y));

            SaveGameInSession(game);

            return new JsonResult(new TurnStatusModel(game, turnStatus));
        }

        private TicTacToeGame CreateNewGame()
        {
            var game = new TicTacToeGame(3, new Player("Player 1", 'X'), new Player("Player 2", 'O'));
            SaveGameInSession(game);
            
            return game;
        }
        
        private TicTacToeGame GetCurrentGame()
        {
            return _game
                   ?? TicTacToeSerializer.DeserializeJson(HttpContext.Session.GetString(SessionKeyGame))
                   ?? (_game = CreateNewGame());
        }
        
        private void SaveGameInSession(TicTacToeGame game)
        {
            HttpContext.Session.SetString(SessionKeyGame, TicTacToeSerializer.SerializeToJson(game));
        }

    }
}