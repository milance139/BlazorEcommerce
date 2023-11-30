
using BlazorEcommerce.Shared.Models.Entities;
using Blazored.LocalStorage;
using System.Net.Http.Json;

namespace BlazorEcommerce.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private ILocalStorageService _localStorage;
        private HttpClient _http;
        public CartService(ILocalStorageService localStorage, HttpClient http) 
        { 
            _localStorage = localStorage;
            _http = http;
        }

        public event Action OnChange;

        public async Task AddToCart(CartItem cartItem)
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if(cart == null) 
            {
                cart = new List<CartItem>();
            }

            var sameItem = cart.Find(c => c.ProductId == cartItem.ProductId &&
                c.ProductTypeId == cartItem.ProductTypeId);

            if(sameItem == null)
            {
                cart.Add(cartItem);
            }
            else
            {
                sameItem.Quantity += cartItem.Quantity;
            }

            await _localStorage.SetItemAsync("cart", cart);

            OnChange.Invoke();
        }

        public async Task<List<CartItem>> GetCartItems()
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                cart = new List<CartItem>();
            }

            return cart;
        }

        public async Task<List<CartProductResponseModel>> GetCartProducts()
        {
            var cartItems = await _localStorage.GetItemAsync<List<CartItem>>("cart");

            var response = await _http.PostAsJsonAsync("api/cart/products", cartItems);

            var cartProcuts = await response.Content.ReadFromJsonAsync<ServiceResponse<List<CartProductResponseModel>>>();
            
            return cartProcuts.Data;
        }

        public async Task RemoveFromCartItem(int productId, int productTypeId)
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                return;
            }

            var cartItem = cart.Find(c => c.ProductId == productId &&
                c.ProductTypeId == productTypeId);

            if (cartItem != null)
            {
                cart.Remove(cartItem);
                await _localStorage.SetItemAsync("cart", cart);
                OnChange.Invoke();
            }

        }

        public async Task UpdateQuantity(CartProductResponseModel cartProduct)
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                return;
            }

            var cartItem = cart.Find(c => c.ProductId == cartProduct.ProductId &&
                c.ProductTypeId == cartProduct.ProductTypeId);

            if (cartItem != null)
            {
                cartItem.Quantity = cartProduct.Quantity;
                await _localStorage.SetItemAsync("cart", cart);
            }
        }
    }
}
