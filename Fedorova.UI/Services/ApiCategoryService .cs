using Fedorova.Domain.Models;
using Fedorova.Domain.Entities;
using Fedorova.UI.Services.CategoryService;

namespace Fedorova.UI.Services
{
    public class ApiCategoryService(HttpClient httpClient) : ICategoryService
    {
        public async Task<ResponseData<List<Category>>> GetCategoryListAsync()
        {
            var result = await httpClient.GetAsync(httpClient.BaseAddress);
            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadFromJsonAsync<ResponseData<List<Category>>>();
            };

            var response = new ResponseData<List<Category>>
            { Success = false, ErrorMessage = "Ошибка чтения API" };
            return response;
        }

        Task<ResponseData<List<Dish>>> ICategoryService.GetCategoryListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
