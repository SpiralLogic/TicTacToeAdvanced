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

        private TicTacToeGame Game
        {
            get
            {
                if (_game == null)
                {
                    _game = TicTacToeSerializer.DeserializeJson(HttpContext.Session.GetString(SessionKeyGame));
                }

                if (_game == null)
                {
                    CreateNewGame();
                }

                return _game;
            }
        }

        [HttpGet("newgame")]
        public IActionResult NewGame()
        {
            CreateNewGame();

            var gamestate = new GameStateModel(Game);

            return new ObjectResult(gamestate);
        }

        [HttpGet("taketurn/{x}/{y}")]
        public IActionResult TakeTurn(int x, int y)
        {
            var turnStatus = Game.TakeTurn(new Coordinate(x, y));

            HttpContext.Session.SetString(SessionKeyGame, TicTacToeSerializer.SerializeToJson(Game));

            return new ObjectResult(new TurnStatusModel(Game, turnStatus));
        }

        private void CreateNewGame()
        {
            _game = new TicTacToeGame(3, new Player("Player 1", 'X'), new Player("Player 2", 'O'));
            HttpContext.Session.SetString(SessionKeyGame, TicTacToeSerializer.SerializeToJson(_game));
        }
    }
}