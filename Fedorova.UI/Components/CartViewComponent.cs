using Microsoft.AspNetCore.Mvc;

namespace Fedorova.UI.Components
{
    public class CartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
