using Fedorova.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Serilog;

namespace Fedorova.UI.Controllers
{
    public class Home : Controller
    {
        private readonly List<ListDemo> _listData;
        private readonly ILogger<Home> _logger;
        public Home(ILogger<Home> logger)
        {
            _logger = logger;
            _listData = new List<ListDemo>
                {
                    new ListDemo {Id=1, Name="Item 1"},
                    new ListDemo {Id=2, Name="Item 2"},
                    new ListDemo {Id=3, Name="Item 3"}
                };
        }
        public IActionResult Index()
        {
            Log.Information("Hello из метода Index контроллера Home!");

            ViewData["Title"] = "Лабораторная работа №2";
            ViewData["HeaderText"] = "Лабораторная работа №2";

            var items = new List<ListDemo>() {
            new ListDemo() { Id = 1, Name = "Item 1" },
            new ListDemo() { Id = 2, Name = "Item 2" },
            new ListDemo() { Id = 3, Name = "Item 3" }
            };

            return View(items);
        }
    }

}
