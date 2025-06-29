using Fedorova.Domain.Entities;
using Fedorova.Domain.Models;

namespace Fedorova.UI.Services.CategoryService
{
    public class MemoryCategoryService : ICategoryService
    {
        public Task<ResponseData<List<Dish>>>GetCategoryListAsync()
        {
            var categories = new List<Dish>
            {
            new Dish {DishId=1, DishName="Стартеры",  NormalizedName="starters"},
            new Dish {DishId=2, DishName="Салаты", NormalizedName="salads"},

            };
            var result = new ResponseData<List<Dish>>();
            result.Data = categories;
            return Task.FromResult(result);
        }
    }
}
