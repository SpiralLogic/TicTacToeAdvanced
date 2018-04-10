using Microsoft.AspNetCore.Mvc;

namespace ReactJsMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return
                View();
        }
    }
}