using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;

namespace InventoryCRUDApp.Frontend.Pages.Product
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public CreateModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [BindProperty]
        public InventoryCRUDApp.Domain.Request.ProductRequest Product { get; set; }

        public string ErrorMessage { get; set; } 

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/products", Product);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("Index"); 
                }
                else
                {
                    ErrorMessage = $"Error: {response.StatusCode} - {response.ReasonPhrase}";
                    return Page();
                }
            }
            catch (HttpRequestException ex)
            {
                ErrorMessage = $"Network error: {ex.Message}";
                return Page();
            }
            catch (Exception ex)
            {
               
                ErrorMessage = $"An unexpected error occurred: {ex.Message}";
                return Page();
            }
        }
    }

}
