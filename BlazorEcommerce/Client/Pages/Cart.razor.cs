
using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce.Client.Pages
{
    public partial class Cart
    {
        List<CartProductResponse> cartProducts = null;
        string message = "Loading cart..";

        protected override async Task OnInitializedAsync()
        {
            await LoadCart();
        }

        private async Task RemoveProductFromCart(int productId, int productTypeId)
        {
            await CartService.RemoveFromCartItem(productId, productTypeId);
            await LoadCart();
        }

        private async Task LoadCart()
        {
            await CartService.GetCartItemsCount();
            cartProducts = await CartService.GetCartProducts();
            if (cartProducts != null || cartProducts.Count == 0 )
            {
                message = "Cart is empty";
            }
        }

        private async Task UpdateQuantity(ChangeEventArgs e, CartProductResponse cartProduct)
        {
            cartProduct.Quantity = int.Parse(e.Value.ToString());
            if(cartProduct.Quantity < 1)
                cartProduct.Quantity = 1;

            await CartService.UpdateQuantity(cartProduct);
        }

        private async Task PlaceOrder()
        {
            string url = await OrderService.PlaceOrder();
            NavigationManager.NavigateTo(url);
        }
    }
}
