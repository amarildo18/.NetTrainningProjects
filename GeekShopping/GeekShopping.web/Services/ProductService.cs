using GeekShopping.web.Models;
using GeekShopping.web.Services.IServices;
using GeekShopping.web.Utils;

namespace GeekShopping.web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _Client;
        public const string basePath = "api/v1/product";

        public ProductService(HttpClient client)
        {
            _Client = client;
        }
        public async Task<IEnumerable<ProductModel>> FindAllProducts()
        {
            var response = await _Client.GetAsync(basePath);
            return await response.ReadContentAsync<List<ProductModel>>();
        }

        public async Task<ProductModel> FindProductById(long id)
        {
            var response = await _Client.GetAsync($"{basePath}/{id}");
            return await response.ReadContentAsync<ProductModel>();
        }

        public async Task<ProductModel> CreateProduct(ProductModel model)
        {
            var response = await _Client.PostAsJson(basePath, model);
            if(response.IsSuccessStatusCode)
            {
                return await response.ReadContentAsync<ProductModel>();
            }
            else
            {
                throw new Exception("Something went wrong when calling the API");
            }
            
        }

        public async Task<ProductModel> UpdateProduct(ProductModel model)
        {
            var response = await _Client.PutAsJson(basePath, model);
            if (response.IsSuccessStatusCode)
            {
                return await response.ReadContentAsync<ProductModel>();
            }
            else
            {
                throw new Exception("Something went wrong when calling the API");
            }
        }

        public async Task<bool> DeleteProductById(long id)
        {
            var response = await _Client.DeleteAsync($"{basePath}/{id}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAsync<bool>();
            else
                throw new Exception("Something went wrong when calling the API");
        }
    }
}
