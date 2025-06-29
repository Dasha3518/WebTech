using Fedorova.Domain.Entities;
using Fedorova.Domain.Models;

namespace Fedorova.UI.Services.CategoryService
{
    public interface ICategoryService
    {
        /// <summary>
        /// Получение списка всех категорий
        /// </summary>
        /// <returns></returns>
        public Task<ResponseData<List<Dish>>> GetCategoryListAsync();
    }
}
