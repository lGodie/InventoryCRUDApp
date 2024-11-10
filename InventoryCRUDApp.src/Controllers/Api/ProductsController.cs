using InventoryCRUDApp.Application.Interfaces.Services;
using InventoryCRUDApp.Domain.Entities;
using InventoryCRUDApp.Domain.Request;
using Microsoft.AspNetCore.Mvc;

namespace InventoryCRUDApp.src.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsUseCase _productService;

        public ProductsController(IProductsUseCase productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var products = await _productService.GetProductAsync(id);
            return Ok(products);
        }

        [HttpPost()]
        public async Task<ActionResult<Product>> Product([FromBody] ProductRequest productRequest)
        {
            await _productService.CreateProductAsync(productRequest.Name, productRequest.Price, productRequest.Stock);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetProductsAsync();
            return Ok(products);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProducts([FromQuery] int id)
        {
            await _productService.UpdateProductAsync(id);
            return Ok();
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteProducts([FromQuery] int id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok();
        }
    }
}
