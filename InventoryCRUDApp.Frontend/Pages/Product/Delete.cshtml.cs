using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Net.Http.Json;

namespace InventoryCRUDApp.Frontend.Pages.Product
{
    public class DeleteModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public DeleteModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public InventoryCRUDApp.Domain.Request.ProductRequest Product { get; set; }

        public async Task OnGetAsync(int id)
        {
            Product = await _httpClient.GetFromJsonAsync<InventoryCRUDApp.Domain.Request.ProductRequest>($"api/products/{id}");
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var response = await _httpClient.PostAsync($"api/products/Delete/{id}", null);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("Index");
            }

            ModelState.AddModelError(string.Empty, "Error al eliminar el producto.");
            return Page();
        }

    }
}
