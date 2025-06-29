using Fedorova.Domain.Entities;
using Fedorova.Domain.Models;
using Fedorova.UI.Models;
using Fedorova.UI.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;

namespace Fedorova.UI.Services.ProductService
{
    public class MemoryProductService : IProductService
    {

        private readonly IConfiguration _config;
        private readonly ICategoryService _categoryService;
        private readonly int _pageNo;

        List<Dish> _dishes;
        List<DishGroup> _dishGroup;
        List<Category> _categories;

       
        public MemoryProductService(
           IConfiguration config,
        ICategoryService categoryService,
        int pageNo)
        {
            _config = config;
        _categoryService = categoryService;
        _pageNo = pageNo;
        }

        public Task<ResponseData<ProductListModel<Dish>>> GetProductListAsync(string? categoryNormalizedName, int pageNo = 1)
        {
            // Создать объект результата
            var result = new ResponseData<ProductListModel<Dish>>();
            // Id категории для фильрации
            int? categoryId = null;
            // если требуется фильтрация, то найти Id категории
            // с заданным categoryNormalizedName
            if (categoryNormalizedName != null)
                categoryId = _categories
                .Find(c =>
                c.NormalizedName.Equals(categoryNormalizedName))
                ?.Id;
            // Выбрать объекты, отфильтрованные по Id категории,
            // если этот Id имеется
            var data = _dishes.Where(d => categoryId == null || d.CategoryId.Equals(categoryId))?
            .ToList();

            // получить размер страницы из конфигурации
            int pageSize = _config.GetSection("ItemsPerPage").Get<int>();
            // получить общее количество страниц
            int totalPages = (int)Math.Ceiling(data.Count /
            (double)pageSize);
            // получить данные страницы
            var listData = new ProductListModel<Dish>()
            {
                Items = data.Skip((pageNo - 1) *
            pageSize).Take(pageSize).ToList(),
                CurrentPage = pageNo,
                TotalPages = totalPages
            };

            // поместить ранные в объект результата
            result.Data = new ProductListModel<Dish>() { Items = data };
            // Если список пустой
            if (data.Count == 0)
            {
                result.Success = false;
                result.ErrorMessage = "Нет объектов в выбраннной категории";
            }
            // Вернуть результат
            return Task.FromResult(result);
        }
        

        public MemoryProductService(ICategoryService categoryService)
        {
            //_dishGroup = categoryService.GetCategoryListAsync();
            SetupData();
        }

        /// <summary>
        /// Инициализация списков
        /// </summary>
        private void SetupData()
        {
            _dishes = new List<Dish>
            {
            new Dish {Id = 1, Name="Суп-харчо", Description="Очень острый, невкусный", Calories =200, Image="Images/Суп.jpg", CategoryId=_dishes.Find(c=>c.Category.NormalizedName.Equals("soups")).Id},
            new Dish {Id = 2, Name="Борщ",Description="Много сала, без сметаны",Calories =330, Image="Images/Борщ.jpg",CategoryId=_dishes.Find(c=>c.Category.NormalizedName.Equals("soups")).Id},

            };
        }

        //public Task<ResponseData<ProductListModel<Dish>>> GetProductListAsync(string? categoryNormalizedName, int pageNo = 1)
        //{
        //    var model = new ProductListModel<Dish>() { Items = _dishes };
        //    var result = new ResponseData<ProductListModel<Dish>>()
        //    {
        //        Data = model
        //    };
        //    return Task.FromResult(result);
        //}

        public Task<ResponseData<Dish>> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductAsync(int id, Dish product, IFormFile? formFile)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseData<Dish>> CreateProductAsync(Dish product, IFormFile? formFile)
        {
            throw new NotImplementedException();
        }

        Task<ResponseData<ListModel<Dish>>> IProductService.GetProductListAsync(string? categoryNormalizedName, int pageNo)
        {
            throw new NotImplementedException();
        }
    }
}
