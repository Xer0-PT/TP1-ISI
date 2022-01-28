using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP1.Domain.Context;
using TP1.Domain.Models;

#pragma warning disable CS8632

namespace RestfullAPI.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllActive()
        {
            return await _context.Products.Where(p => p.Active == true).ToListAsync();
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<bool> AddProduct(Product product)
        {

            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<bool> UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> RemoveProduct(Product product)
        {



            product.Active = false;
            product.ChangeDate = DateTime.Now;
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<Product> GetProductAsync(int? id, string? name)
        {
            Product product = new();

            if (id != null)
            {
                product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
                return product;
            }

            if (name != null)
            {
                product = await _context.Products.FirstOrDefaultAsync(p => p.Name == name);
                return product;
            }

            return null;
        }




    }
}
