using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using TP1.Domain.Models.DTO;

namespace WASM.Blazor.Services
{
    public class ProductService : IProductService
    {
        private const string ProductController = "Product";
        private readonly HttpClient httpClient;
        private JsonSerializerOptions json = new() { PropertyNameCaseInsensitive = true };

        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> AddProduct(ProductDTO product)
            => await httpClient.PostAsJsonAsync($"{Config.BaseUrl}/{ProductController}/AddProduct", product, json);

        public async Task<List<ProductDTO>> GetAllProducts()
            => await httpClient.GetFromJsonAsync<List<ProductDTO>>($"{Config.BaseUrl}/{ProductController}/GetAllProducts", json);

        public async Task<List<ProductDTO>> GetAllActiveProducts()
            => await httpClient.GetFromJsonAsync<List<ProductDTO>>($"{Config.BaseUrl}/{ProductController}/GetAllActiveProducts", json);

        public async Task<HttpResponseMessage> UpdateProduct(ProductDTO product)
            => await httpClient.PutAsJsonAsync($"{Config.BaseUrl}/{ProductController}/UpdateProduct", product, json);

        public async Task<HttpResponseMessage> DeleteProduct(int id)
            => await httpClient.PutAsJsonAsync($"{Config.BaseUrl}/{ProductController}/RemoveProduct?id={id}", json);
    }
}
