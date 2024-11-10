using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InventoryCRUDApp.Frontend.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public IndexModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public List<InventoryCRUDApp.Domain.Entities.Product> Products { get; set; }

        public async Task OnGetAsync()
        {
            Products = await _httpClient.GetFromJsonAsync<List<InventoryCRUDApp.Domain.Entities.Product>>("api/products");
        }


    }
}
