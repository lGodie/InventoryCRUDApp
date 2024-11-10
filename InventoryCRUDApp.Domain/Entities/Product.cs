using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryCRUDApp.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }

        public Product(string name, decimal price, int stock)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name cannot be empty.");

            if (price <= 0)
                throw new ArgumentException("Product price must be greater than zero.");

            if (stock < 0)
                throw new ArgumentException("Product stock cannot be negative.");

            Name = name;
            Price = price;
            Stock = stock;
        }

        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice <= 0)
                throw new ArgumentException("New price must be greater than zero.");

            Price = newPrice;
        }

        public void AdjustStock(int quantity)
        {
            if (Stock + quantity < 0)
                throw new InvalidOperationException("Insufficient stock for the adjustment.");

            Stock += quantity;
        }
    }

}
