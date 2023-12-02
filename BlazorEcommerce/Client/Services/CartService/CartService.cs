
using BlazorEcommerce.Shared.Models.Entities;
using Blazored.LocalStorage;
using System.Net.Http.Json;

namespace BlazorEcommerce.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private ILocalStorageService _localStorage;
        private HttpClient _http;
        private IAuthService _authService;
        public CartService(ILocalStorageService localStorage, HttpClient http, IAuthService authService) 
        { 
            _localStorage = localStorage;
            _http = http;
            _authService = authService;
        }

        public event Action OnChange;

        public async Task AddToCart(CartItem cartItem)
        {
            if (await _authService.IsUserAuthenticated())
            {
                var result = await _http.PostAsJsonAsync<CartItem>("api/cart/add", cartItem);
            }
            else
            {
                var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
                if (cart == null)
                {
                    cart = new List<CartItem>();
                }

                var sameItem = cart.Find(c => c.ProductId == cartItem.ProductId &&
                    c.ProductTypeId == cartItem.ProductTypeId);

                if (sameItem == null)
                {
                    cart.Add(cartItem);
                }
                else
                {
                    sameItem.Quantity += cartItem.Quantity;
                }

                await _localStorage.SetItemAsync("cart", cart);
            }

            await GetCartItemsCount();
        }

        public async Task<List<CartProductResponse>> GetCartProducts()
        {
            if(await _authService.IsUserAuthenticated())
            {
                var response = await _http.GetFromJsonAsync<ServiceResponse<List<CartProductResponse>>>("api/cart/");

                return response.Data;
            }
            else
            {
                var cartItems = await _localStorage.GetItemAsync<List<CartItem>>("cart");

                if (cartItems == null)
                    return new List<CartProductResponse>();

                var response = await _http.PostAsJsonAsync("api/cart/products", cartItems);

                var cartProcuts = await response.Content.ReadFromJsonAsync<ServiceResponse<List<CartProductResponse>>>();
            
                return cartProcuts.Data;
            }

        }

        public async Task RemoveFromCartItem(int productId, int productTypeId)
        {
            if (await _authService.IsUserAuthenticated())
            {
                await _http.DeleteAsync($"api/cart/{productId}/{productTypeId}");
            }
            else
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
                }
            }
            await GetCartItemsCount();
        }

        public async Task StoreCartItems(bool emtpyLocalCart = false)
        {
            var localCart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if(localCart == null)
            {
                return;
            }
            
            await _http.PostAsJsonAsync("api/cart/", localCart);

            if(emtpyLocalCart)
            {
                await _localStorage.RemoveItemAsync("cart");
            }

        }

        public async Task UpdateQuantity(CartProductResponse cartProduct)
        {
            if (await _authService.IsUserAuthenticated())
            {
                var requestModel = new CartItem()
                {
                    ProductId = cartProduct.ProductId,
                    ProductTypeId = cartProduct.ProductTypeId,
                    Quantity = cartProduct.Quantity
                };
                await _http.PutAsJsonAsync<CartItem>("api/cart/update-quantity", requestModel);
            }
            else
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

        public async Task GetCartItemsCount()
        {
            if(await _authService.IsUserAuthenticated())
            {
                var result = await _http.GetFromJsonAsync<ServiceResponse<int>>("api/cart/count");
                var count = result.Data;

                await _localStorage.SetItemAsync<int>("cartItemsCount", count);
            }
            else
            {
                var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");

                await _localStorage.SetItemAsync<int>("cartItemsCount", cart != null ? cart.Count : 0);
            }

            OnChange.Invoke();
        }
    }
}
