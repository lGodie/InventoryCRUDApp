using AutoMapper;
using InventoryCRUDApp.Domain.Entities;
using InventoryCRUDApp.Infrastructure.Persistence.Entities;

namespace InventoryCRUDApp.src.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductEntity>();
            CreateMap<ProductEntity, Product>();
        }
    }
}
