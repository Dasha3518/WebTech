using Fedorova.Domain.Entities;
using Fedorova.Domain.Models;
using Fedorova.UI.Models;
using Fedorova.UI.Services.CategoryService;

namespace Fedorova.UI.Services.ProductService
{
    public class MemoryProductService : IProductService
    {
        List<Dish> _dishes;
        List<DishGroup> _dishGroup;
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
            new Dish {DishId = 1, DishName="Суп-харчо", Description="Очень острый, невкусный", Calories =200, Image="Images/Суп.jpg", DishGroupId=_dishes.Find(c=>c.NormalizedName.Equals("soups")).DishId},
            new Dish { DishId = 2, DishName="Борщ",Description="Много сала, без сметаны",Calories =330, Image="Images/Борщ.jpg",DishGroupId=_dishes.Find(c=>c.NormalizedName.Equals("soups")).DishId},

            };
        }

        public Task<ResponseData<ProductListModel<Dish>>> GetProductListAsync(string? categoryNormalizedName, int pageNo = 1)
        {
            var model = new ProductListModel<Dish>() { Items = _dishes };
            var result = new ResponseData<ProductListModel<Dish>>()
            {
                Data = model
            };
            return Task.FromResult(result);
        }

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
