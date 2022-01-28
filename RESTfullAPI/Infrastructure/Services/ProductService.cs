using AutoMapper;
using RestfullAPI.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TP1.Domain.Models;
using TP1.Domain.Models.DTO;

#pragma warning disable CS8632

namespace RestfullAPI.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> GetAllActive()
        {
            var products = await _productRepository.GetAllActive();
            var aux = _mapper.Map<List<ProductDTO>>(products);

            return aux;

        }

        public async Task<List<ProductDTO>> GetAll()
        {
            var products = await _productRepository.GetAll();
            var aux = _mapper.Map<List<ProductDTO>>(products);

            return aux;
        }

        public async Task<bool> AddProduct(ProductDTO product)
        {
            var aux = await _productRepository.GetProductAsync(null, product.Name);
            if (aux == null)
            {
                var result = new Product
                {
                    Name = product.Name,
                    Stock = product.Stock,
                    Price = product.Price,
                    Active = product.Active,
                    ChangeDate = DateTime.Now,
                    CreateDate = DateTime.Now
                };
                return await _productRepository.AddProduct(result);
            }


            return false;
        }

        public async Task<bool> UpdateProduct(ProductDTO product)
        {
            var result = await _productRepository.GetProductAsync(product.Id, product.Name);

            if (result != null)
            {
                result.Name = product.Name;
                result.Stock = product.Stock;
                result.Price = product.Price;
                result.Active = product.Active;
                result.ChangeDate = DateTime.Now;

                return await _productRepository.UpdateProduct(result);
               
            }

            return false;
        }

        public async Task<bool> RemoveProduct(int? id, string? name)
        {
            var product = await _productRepository.GetProductAsync(id, name);
            if (product != null)
            {
                return await (_productRepository.RemoveProduct(product));
            }
            return false;
        }

        public async Task<ProductDTO> GetProductDTOAsync(int? id, string? name)
        {
            var aux = await _productRepository.GetProductAsync(id, name);

            var result = _mapper.Map<ProductDTO>(aux);

            return result;
        }

    }
}
