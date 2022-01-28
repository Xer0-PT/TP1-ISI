using System.Collections.Generic;
using System.Threading.Tasks;
using TP1.Domain.Models.DTO;

#pragma warning disable CS8632

namespace RestfullAPI.Infrastructure.Services
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetAllActive();
        Task<List<ProductDTO>> GetAll();
        Task<bool> AddProduct(ProductDTO product);
        Task<bool> UpdateProduct(ProductDTO product);
        Task<bool> RemoveProduct(int? id, string? name);
        Task<ProductDTO> GetProductDTOAsync(int? id, string? name);
    }
}
