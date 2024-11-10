using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;

namespace InventoryCRUDApp.Frontend.Pages.Product
{
    public class EditModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public EditModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [BindProperty]
        public InventoryCRUDApp.Domain.Request.ProductRequest Product { get; set; }

        public async Task OnGetAsync(int id)
        {
            Product = await _httpClient.GetFromJsonAsync<InventoryCRUDApp.Domain.Request.ProductRequest>($"api/products/{id}");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _httpClient.PutAsJsonAsync($"api/products/{Product.Id}", Product);
            return RedirectToPage("Index");
        }
    }
}
