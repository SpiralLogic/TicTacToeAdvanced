using Microsoft.AspNetCore.Mvc;

namespace TicTacToeWebApp.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public IActionResult Index()
        { 
            return
                View();
        }
    }
}