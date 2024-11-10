using InventoryCRUDApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryCRUDApp.Application.Interfaces.Services
{
    public interface IProductsUseCase
    {
        Task CreateProductAsync(string name, decimal price, int stock);
        Task<Product> GetProductAsync(int id);
        Task<List<Product>> GetProductsAsync();
        Task UpdateProductAsync(int id);
        Task DeleteProductAsync(int id);
    }
}
