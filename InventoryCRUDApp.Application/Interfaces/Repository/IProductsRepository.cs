using InventoryCRUDApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryCRUDApp.Application.Interfaces.Repository
{
    public interface IProductsRepository
    {
        public Task AddAsync(Product product);
        public Task<Product> GetProductAsync(int id);
        Task<List<Product>> GetAllAsync();
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
    }
}
