using Microsoft.AspNetCore.Mvc;

namespace Fedorova.UI.Controllers
{
    public class Home : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
