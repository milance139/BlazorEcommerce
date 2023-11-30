
using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce.Client.Pages
{
    public partial class Cart
    {
        List<CartProductResponseModel> cartProducts = null;
        string message = "Loading cart..";

        protected override async Task OnInitializedAsync()
        {
            await LoadCart();
        }

        private async Task RemoveProductFromCart(int productId, int procutTypeId)
        {
            await CartService.RemoveFromCartItem(productId, procutTypeId);
            await LoadCart();

        }

        private async Task LoadCart()
        {
            if ((await CartService.GetCartItems()).Count == 0)
            {
                message = "Cart is empty";
                cartProducts = new List<CartProductResponseModel> { };
            }
            else
            {
                cartProducts = await CartService.GetCartProducts();
            }
        }

        private async Task UpdateQuantity(ChangeEventArgs e, CartProductResponseModel cartProduct)
        {
            cartProduct.Quantity = int.Parse(e.Value.ToString());
            if(cartProduct.Quantity < 1)
                cartProduct.Quantity = 1;

            await CartService.UpdateQuantity(cartProduct);
        }
    }
}
