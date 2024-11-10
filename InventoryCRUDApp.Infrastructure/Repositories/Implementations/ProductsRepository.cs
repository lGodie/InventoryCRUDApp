using AutoMapper;
using InventoryCRUDApp.Application.Interfaces.Repository;
using InventoryCRUDApp.Domain.Entities;
using InventoryCRUDApp.Infrastructure.Persistence.Context;
using InventoryCRUDApp.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryCRUDApp.Infrastructure.Repositories.Implementations
{
    public class ProductsRepository : GenericRepository<ProductEntity>, IProductsRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductsRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            ProductEntity productentity = _mapper.Map<ProductEntity>(product);
            await _context.Set<ProductEntity>().AddAsync(productentity);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProductAsync(int id)
        {
            ProductEntity productEntity = await _context.Set<ProductEntity>().FindAsync(id);
            Product productDto = _mapper.Map<Product>(productEntity);
            return productDto;

        }
        public async Task<List<Product>> GetAllAsync()
        {
            List<ProductEntity> products = await _context.Set<ProductEntity>().ToListAsync();
            List<Product> productDtos = _mapper.Map<List<Product>>(products);
            return productDtos;

        }
        public async Task DeleteAsync(Product product)
        {
            ProductEntity productEntity = _mapper.Map<ProductEntity>(product);
            _context.Set<ProductEntity>().Remove(productEntity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Product product)
        {
            ProductEntity productEntity = _mapper.Map<ProductEntity>(product);
            _context.Set<ProductEntity>().Update(productEntity);
            await _context.SaveChangesAsync();
        }
    }
}
