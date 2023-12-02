
using System.Security.Claims;

namespace BlazorEcommerce.Server.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly DataContext _context;
        private readonly IAuthService _authService;
        public CartService(DataContext context, IAuthService authService) 
        {
            _context = context;
            _authService = authService;
        }

        public async Task<ServiceResponse<List<CartProductResponse>>> GetCartProducts(List<CartItem> cartItems)
        {
            var result = new ServiceResponse<List<CartProductResponse>>()
            {
                Data = new List<CartProductResponse>()
            };

            foreach (var cartItem in cartItems) 
            {
                var product = await _context.Products
                    .Where(p => p.Id == cartItem.ProductId)
                    .FirstOrDefaultAsync();

                if (product == null) 
                {
                    continue;
                }

                var productVariant = await _context.ProductVariants
                    .Where(pv => pv.ProductId == cartItem.ProductId &&
                    pv.ProductTypeId == cartItem.ProductTypeId)
                    .Include(pv => pv.ProductType)
                    .FirstOrDefaultAsync();

                if (productVariant == null)
                {
                    continue;
                }

                var cartProcuts = new CartProductResponse
                {
                    ProductId = product.Id,
                    Title = product.Title,
                    ImageUrl = product.ImageURL,
                    Price = productVariant.Price,
                    ProductType = productVariant.ProductType.Name,
                    ProductTypeId = productVariant.ProductTypeId,
                    Quantity = cartItem.Quantity
                };

                result.Data.Add(cartProcuts);
            }
        
            return result;
        }

        public async Task<ServiceResponse<List<CartProductResponse>>> StoreCartItems(List<CartItem> cartItems)
        {
            cartItems.ForEach(cartItem => { cartItem.UserId = _authService.GetUserId(); });

            _context.CartItem.AddRange(cartItems);
            await _context.SaveChangesAsync();

            return await GetCartProductsFromDb();
        }

        public async Task<ServiceResponse<int>> GetItemsCount()
        {
            var count = (await _context.CartItem.Where(ci => ci.UserId == _authService.GetUserId()).ToListAsync()).Count();
            return new ServiceResponse<int>() { Data = count};
        }

        public async Task<ServiceResponse<List<CartProductResponse>>> GetCartProductsFromDb()
        {
            return await GetCartProducts(await _context.CartItem.Where(ci => ci.UserId == _authService.GetUserId()).ToListAsync());
        }

        public async Task<ServiceResponse<bool>> AddToCart(CartItem cartItem)
        {
            cartItem.UserId = _authService.GetUserId();

            var sameItem = await _context.CartItem
                .FirstOrDefaultAsync(ci =>  ci.ProductId == cartItem.ProductId &&
                ci.ProductTypeId == cartItem.ProductTypeId &&
                ci.UserId == cartItem.UserId);

            if(sameItem == null)
            {
                _context.CartItem.Add(cartItem);
            }
            else
            {
                sameItem.Quantity += cartItem.Quantity;
            }

            await _context.SaveChangesAsync();

            return new ServiceResponse<bool>() { Data = true };
        }

        public async Task<ServiceResponse<bool>> RemoveFromCart(int productId, int productTypeId)
        {
            var dbCartItem = await _context.CartItem
                .FirstOrDefaultAsync(ci => ci.ProductId == productId &&
                ci.ProductTypeId == productTypeId &&
                ci.UserId == _authService.GetUserId());

            if (dbCartItem == null)
            {
                return new ServiceResponse<bool>() { Data = false, Success = false, Message = "Cart item does not exists" };
            }

            _context.CartItem.Remove(dbCartItem);

            await _context.SaveChangesAsync();

            return new ServiceResponse<bool>() { Data = true };
        }

        public async Task<ServiceResponse<bool>> UpdateQuantity(CartItem cartItem)
        {
            var dbCartItem = await _context.CartItem
                .FirstOrDefaultAsync(ci => ci.ProductId == cartItem.ProductId &&
                ci.ProductTypeId == cartItem.ProductTypeId &&
                ci.UserId == _authService.GetUserId());

            if (dbCartItem == null)
            {
                return new ServiceResponse<bool>() { Data = false, Success = false, Message = "Cart item does not exists" };
            }

            dbCartItem.Quantity = cartItem.Quantity;

            await _context.SaveChangesAsync();

            return new ServiceResponse<bool>() { Data = true };
        }
    }
}
