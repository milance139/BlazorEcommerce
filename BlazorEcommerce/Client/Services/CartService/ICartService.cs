namespace BlazorEcommerce.Client.Services.CartService
{
    public interface ICartService
    {
        event Action OnChange;
        Task AddToCart(CartItem cartItem);
        Task<List<CartProductResponse>> GetCartProducts();
        Task RemoveFromCartItem(int productId, int productTypeId);
        Task UpdateQuantity(CartProductResponse cartProduct);
        Task StoreCartItems(bool emtpyLocalCart);
        Task GetCartItemsCount();
    }
}
