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
            new Dish {Id=1, Name="Стартеры"},
            new Dish {Id=2, Name="Салаты"},

            };
            var result = new ResponseData<List<Dish>>();
            result.Data = categories;
            return Task.FromResult(result);
        }
    }
}
