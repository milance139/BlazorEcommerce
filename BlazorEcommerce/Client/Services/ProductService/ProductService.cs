
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlazorEcommerce.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;
        public ProductService(HttpClient http) 
        {
            _http = http;   
        }
        public List<Product> Products { get; set; } = new List<Product>();
        public string Message { get; set; } = "Loading products...";
        public string LastSearchText { get; set; } = string.Empty;
        public PagginationBaseModel Paggination { get; set; } = new PagginationBaseModel();

        public event Action ProductsChanged;

        public async Task<ServiceResponse<Product>> GetProductById(int productId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/Product/{productId}");
            
            return result;
        }

        public async Task GetProducts(string? categoryUrl = null)
        {
            var result = categoryUrl == null ?
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product/featured") :
                await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/Product/category/{categoryUrl}");

            if (result != null && result.Data != null)
                Products = result.Data;

            Paggination.CurrentPage = 1;
            Paggination.TotalPages = 0;

            if(Products.Count == 0)
            {
                Message = "No products found.";
            }

            ProductsChanged.Invoke();
        }

        public async Task<List<string>> GetProductSearchSuggestions(string searchText)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<string>>>($"api/Product/searchsuggestions/{searchText}");

            return result.Data;
        }

        public async Task SearchProducts(ProductSearchRequestModel requestModel)
        {
            var result = await _http.PostAsJsonAsync($"api/Product/search", requestModel);
            LastSearchText = requestModel.SearchText;

            if(result != null)
            {
                var resultData = (await result.Content
                    .ReadFromJsonAsync<ServiceResponse<ProcutSearchResultResponseModel>>()).Data;
 
                if (resultData != null)
                {
                    Products = resultData.Products;
                    Paggination.TotalItems = resultData.TotalItems;
                    Paggination.CurrentPage = resultData.CurrentPage;
                    Paggination.TotalPages = resultData.TotalPages;
                }
            
            }

            if (Products.Count == 0)
                Message = "No products found";

            ProductsChanged.Invoke();
        }
    }
}
