using Microsoft.AspNetCore.Components;
using System.Runtime.CompilerServices;

namespace BlazorEcommerce.Client.Pages
{
    public partial class ProductDetails
    {
        private int currentTypeId = 1;
        private Product? product = null;
        private string message = string.Empty;

        [Parameter]
        public int Id { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            message = "Loading product...";

            var result = await ProductService.GetProductById(Id);

            if (!result.Success)
            {
                message = result.Message;
            }
            else
            {
                product = result.Data;
                if(product.Variants.Count > 0)
                {
                    currentTypeId = product.Variants[0].ProductTypeId;
                }
            }
        }
        private ProductVariant GetSelectedVariant()
        {
            var variant = product.Variants.FirstOrDefault(v => v.ProductTypeId == currentTypeId);
            return variant;
        }

        private async Task AddToCart()
        {
            var productVariant = GetSelectedVariant();
            var cartItem = new CartItem()
            {
                ProductId = productVariant.ProductId,
                ProductTypeId = productVariant.ProductTypeId
            };

            await CartService.AddToCart(cartItem);
        }
    }
}
