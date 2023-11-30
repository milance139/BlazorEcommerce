namespace BlazorEcommerce.Client.Services.CartService
{
    public interface ICartService
    {
        event Action OnChange;
        Task AddToCart(CartItem cartItem);
        Task<List<CartItem>> GetCartItems();
        Task<List<CartProductResponseModel>> GetCartProducts();
        Task RemoveFromCartItem(int productId, int productTypeId);
        Task UpdateQuantity(CartProductResponseModel cartProduct);
    }
}
