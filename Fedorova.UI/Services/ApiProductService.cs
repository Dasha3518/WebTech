using Fedorova.Domain.Entities;
using Fedorova.Domain.Models;
using Fedorova.UI.Models;
using Fedorova.UI.Services.ProductService;

namespace Ganets.UI.Services
{
    public class ApiProductService(HttpClient httpClient) : IProductService
    {
        public Task<ResponseData<Dish>> CreateProductAsync(Dish product, IFormFile? formFile)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseData<Dish>> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseData<ListModel<Dish>>> GetProductListAsync(string? categoryNormalizedName, int pageNo = 1)
        {
            var uri = httpClient.BaseAddress;

            // Формирование данных для строки запроса
            var queryData = new Dictionary<string, string>
        {
            { "pageNo", pageNo.ToString() }
        };

            if (!string.IsNullOrEmpty(categoryNormalizedName))
            {
                queryData.Add("category", categoryNormalizedName);
            }

            var query = QueryString.Create(queryData);

            // Выполнение HTTP-запроса
            var result = await httpClient.GetAsync(uri + query.Value);
            if (result.IsSuccessStatusCode)
            {
                return await result.Content.ReadFromJsonAsync<ResponseData<ListModel<Dish>>>();
            }

            // Формирование объекта ответа с ошибкой
            var response = new ResponseData<ListModel<Dish>>
            {
                Success = false,
                ErrorMessage = "Ошибка чтения API"
            };
            return response;
        }

        public Task UpdateProductAsync(int id, Dish product, IFormFile? formFile)
        {
            throw new NotImplementedException();
        }
    }

}
