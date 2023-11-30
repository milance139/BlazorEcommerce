using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce.Client.Pages
{
    public partial class Index
    {
        [Parameter]
        public string? CategoryUrl { get; set; } = null;
        [Parameter]
        public string? SearchText { get; set; } = null;
        ProductSearchRequestModel requestModel = new ProductSearchRequestModel();

        protected override async Task OnParametersSetAsync()
        {
            if(SearchText != null)
            {
                requestModel.SearchText = SearchText;
                await ProductService.SearchProducts(requestModel);
            }
            else
                await ProductService.GetProducts(CategoryUrl);
        }
    }
}
