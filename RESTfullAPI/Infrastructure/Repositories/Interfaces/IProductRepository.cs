using System.Collections.Generic;
using System.Threading.Tasks;
using TP1.Domain.Models;

#pragma warning disable CS8632

namespace RestfullAPI.Infrastructure.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllActive();
        Task<List<Product>> GetAll();
        Task<bool> AddProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> RemoveProduct(Product product);
        Task<Product> GetProductAsync(int? id, string? name);


    }
}
