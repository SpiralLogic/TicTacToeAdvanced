using Microsoft.AspNetCore.Mvc;

namespace TicTacToeWebApp.Controllers
{
    public class GameController : Controller
    {
        [Route("Game/TakeTurn/{x}/{y}")]
        public IActionResult TakeTurn(int x, int y)
        {
            var result = new ContentResult {Content = $"{x}{y}"};

            return result;
        }
        
        [Route("Game/NewGame")]
        public IActionResult NewGame()
        {
            var result = new ContentResult { Content = "New Game"};

            return result;
        }
        
        
        [Route("Game")]
        [Route("Game/Board")]
        public IActionResult Board()
        {
            var result = new ContentResult { Content = "Describe Board"};

            return result;
        }
    }
}