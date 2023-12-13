
using BlazorEcommerce.Shared.Models.Entities;
using Microsoft.JSInterop;

namespace BlazorEcommerce.Client.Pages.Admin
{
    public partial class Products
    {

        protected override async Task OnInitializedAsync()
        {
            await ProductService.GetAdminProducts();
        }

        void EditProduct(int productId)
        {
            NavigationManager.NavigateTo($"admin/product/{productId}");
        }
        async Task DeleteProduct(Product product)
        {
            bool confirmed = await JSRuntime.InvokeAsync<bool>("confirm", $"Do you really want to delete '{product.Title}'?");
            if (confirmed)
            {
                await ProductService.DeleteProduct(product);
                await ProductService.GetAdminProducts();
            }
        }

        async Task PromoteProduct(Product product)
        {
            bool confirmed = false;
            if (!product.IsFeatured)
               confirmed = await JSRuntime.InvokeAsync<bool>("confirm", $"Do you really want to feature '{product.Title}'?");
            else
                confirmed = await JSRuntime.InvokeAsync<bool>("confirm", $"Do you really want to remove feature on '{product.Title}'?");

            if (confirmed)
            {
                await ProductService.PromoteProduct(product);
                await ProductService.GetAdminProducts();
            }
        }

        void CreateProduct()
        {
            NavigationManager.NavigateTo("admin/product");
        }
    }
}
