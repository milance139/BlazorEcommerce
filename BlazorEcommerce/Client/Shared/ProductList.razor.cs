using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce.Client.Shared
{
    public partial class ProductList
    {
        ProductSearchRequestModel requestModel = new ProductSearchRequestModel();
        protected override void OnInitialized()
        {
            ProductService.ProductsChanged += StateHasChanged;
        }

        public void Dispose()
        {
            ProductService.ProductsChanged -= StateHasChanged;
        }

        private string GetPriceText(Product product)
        {
            var variants = product.Variants;
            if (variants.Count == 0)
            {
                return string.Empty;
            }
            else if (variants.Count == 1)
            {
                return $"€{variants[0].Price}";
            }
            decimal minPrice = variants.Min(v => v.Price);
            return $"Starting at €{minPrice}";
        }

        private void ChangePage(int pageNumber)
        {
            requestModel.CurrentPage = pageNumber;
            requestModel.SearchText = ProductService.LastSearchText;
            ProductService.SearchProducts(requestModel);
        }
    }
}
