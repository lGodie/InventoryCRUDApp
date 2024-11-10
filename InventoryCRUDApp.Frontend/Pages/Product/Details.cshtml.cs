using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InventoryCRUDApp.Frontend.Pages.Product
{
    public class DetailsModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<DetailsModel> _logger;

        public DetailsModel(HttpClient httpClient, ILogger<DetailsModel> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public InventoryCRUDApp.Domain.Request.ProductRequest Product { get; set; }
        public string ErrorMessage { get; set; }
        public bool NotFound { get; set; }
        public async Task OnGetAsync(int id)
        {
            try
            {
                Product = await _httpClient.GetFromJsonAsync<InventoryCRUDApp.Domain.Request.ProductRequest>($"api/products/{id}");

                if (Product == null)
                {
                    NotFound = true; 
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching product details");

                ErrorMessage = "There was an error retrieving the product details. Please try again later.";
            }
        }

    }
}
