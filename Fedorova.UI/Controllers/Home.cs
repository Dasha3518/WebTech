using Fedorova.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebLabs.Controllers
{
    public class Home : Controller
    {
        public IActionResult Index()
        {
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
