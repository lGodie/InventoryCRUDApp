using InventoryCRUDApp.Infrastructure.Persistence.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryCRUDApp.Infrastructure.Persistence.Entities
{
    [Table("Products")]
    public class ProductEntity : EntityBase
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
