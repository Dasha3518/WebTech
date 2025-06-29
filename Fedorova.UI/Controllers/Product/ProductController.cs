using Fedorova.Domain.Entities;
using Fedorova.Domain.Models;
using Fedorova.UI.Data;
using Fedorova.UI.Models;
using Fedorova.UI.Services.CategoryService;
using Fedorova.UI.Services.ProductService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fedorova.UI.Controllers
{
    public class ProductController(ICategoryService categoryService, IProductService productService) : Controller
    {
        ApplicationDbContext _context;

        public List<Dish> _dishes;
        List<DishGroup> _dishGroups;

        int _pageSize;

        //public ProductController(ApplicationDbContext context)
        //{
        //	_pageSize = 3;
        //	_context = context;
        //	//SetupData();
        //}
        //      //public ProductController()
        //      //      {
        //      //          _pageSize = 3;
        //      //          SetupData();
        //      //      }
        //      [Route("Catalog")]
        //      [Route("Catalog/Page_{pageNo}")]
        //      public IActionResult Index(int? group, int pageNo = 1)
        //      {

        //          var dishesFiltered = _context.Dish.Where(d => !group.HasValue || d.DishGroupId == group.Value);

        //          ViewData["Groups"] = _context.DishGroup.Where(d => true);//_dishGroups;
        //          // Получить id текущей группы и поместить в TempData
        //          ViewData["CurrentGroup"] = group ?? 0;

        //          ViewData["DishGroupId"] = new SelectList(_context.DishGroup, "DishGroupId", "GroupName");
        //          return View(ListModel<Dish>.GetModel(dishesFiltered, pageNo, _pageSize));
        //      }
        //public async Task<IActionResult> Index()
        //{
        //    var productResponse = await productService.GetProductListAsync(null);
        //    if (!productResponse.Success)
        //        return NotFound(productResponse.ErrorMessage);
        //    return View(productResponse.Data.Count);
        //}

        [Route("Catalog")]
        [Route("Catalog/{category}")]        
        public async Task<IActionResult> Index(string? category, int pageNo = 1)
        {
            // получить список категорий
            var categoriesResponse = await
            categoryService.GetCategoryListAsync();
            // если список не получен, вернуть код 404
            if (!categoriesResponse.Success)
                return NotFound(categoriesResponse.ErrorMessage);
            // передать список категорий во ViewData
            ViewData["categories"] = categoriesResponse.Data;
            // передать во ViewData имя текущей категории
            var currentCategory = category == null ? "Все" : categoriesResponse.Data.FirstOrDefault(c => c.Category.NormalizedName == category)?.Name;
            ViewData["currentCategory"] = currentCategory;
            var productResponse = await productService.GetProductListAsync(category);
            if (!productResponse.Success)
                ViewData["Error"] = productResponse.ErrorMessage;
            return View(productResponse.Data);
        }

        


        private void SetupData()
        {
            _dishGroups = new List<DishGroup>
            {
            new DishGroup {DishGroupId=1, GroupName="Стартеры"},
            new DishGroup {DishGroupId=2, GroupName="Салаты"},
            new DishGroup { DishGroupId = 3, GroupName = "Супы" },
            new DishGroup
            {
                DishGroupId = 4,
                GroupName = "Основные блюда"},
            new DishGroup { DishGroupId = 5, GroupName = "Напитки" },
                new DishGroup { DishGroupId = 6, GroupName = "Десерты" }
            };
                        _dishes = new List<Dish>
            {
            new Dish {Id = 1, Name="Суп-харчо", Description="Очень острый, невкусный", Calories =200, CategoryId=3, Image="1.jpg" },
            new Dish { Id = 2, Name="Борщ", Description="Много сала, без сметаны", Calories =330, CategoryId=3, Image="2.jpg" },
            new Dish { Id = 3, Name="Котлета пожарская", Description="Хлеб - 80%, Морковь - 20%",Calories =635, CategoryId=4, Image="3.jpg" },
            new Dish { Id = 4, Name="Макароны по-флотски", Description="С охотничьей колбаской", Calories =524, CategoryId=4, Image="4.jpg" },
            new Dish { Id = 5, Name="Компот", Description="Быстро растворимый, 2 литра", Calories =180, CategoryId=5, Image="1.jpg" }
            };
        }
    }
}