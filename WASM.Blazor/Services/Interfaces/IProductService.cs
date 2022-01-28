using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TP1.Domain.Models.DTO;

namespace WASM.Blazor.Services
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAllProducts();
        Task<List<ProductDTO>> GetAllActiveProducts();
        Task<HttpResponseMessage> AddProduct(ProductDTO product);
        Task<HttpResponseMessage> UpdateProduct(ProductDTO product);
        Task<HttpResponseMessage> DeleteProduct(int id);
    }
}
