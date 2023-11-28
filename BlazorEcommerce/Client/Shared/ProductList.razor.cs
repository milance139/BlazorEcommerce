using BlazorEcommerce.Shared.Models.Entities;
using System.Net.Http.Json;


namespace BlazorEcommerce.Client.Shared
{
    public partial class ProductList
    {
        private static List<Product> products = new List<Product>();

        protected override async Task OnInitializedAsync()
        {
            var result = await Http.GetFromJsonAsync<List<Product>>("api/Product");
            if (result != null)
            {
                products = result.ToList();
            }
        }
    }
}
