namespace BlazorEcommerce.Server.Services.CartService
{
    public interface ICartService
    {
        Task<ServiceResponse<List<CartProductResponseModel>>> GetCartProducts(List<CartItem> cartItems);
    }
}
