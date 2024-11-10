using AutoMapper;
using InventoryCRUDApp.Application.Interfaces.Repository;
using InventoryCRUDApp.Application.Interfaces.Services;
using InventoryCRUDApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryCRUDApp.Application.Services
{
    public class ProductsUseCase : IProductsUseCase
    {
        private readonly IProductsRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductsUseCase(IProductsRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task CreateProductAsync(string name, decimal price, int stock)
        {
            var product = new Product(name, price, stock);
            await _productRepository.AddAsync(product);
        }

        public async Task<Product> GetProductAsync(int id)
        {
            var productEntity = await _productRepository.GetProductAsync(id);
            if (productEntity == null)
            {
                throw new KeyNotFoundException("Product not found");
            }
            return productEntity;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }
        public async Task UpdateProductAsync(int id)
        {
            var productEntity = await GetProductAsync(id);
            Product product = _mapper.Map<Product>(productEntity);
            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            var productEntity = await GetProductAsync(id);
            Product product = _mapper.Map<Product>(productEntity);

            await _productRepository.DeleteAsync(product);
        }


    }

}
