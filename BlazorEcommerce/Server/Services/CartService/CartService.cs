
namespace BlazorEcommerce.Server.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly DataContext _context;
        public CartService(DataContext context) 
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<CartProductResponseModel>>> GetCartProducts(List<CartItem> cartItems)
        {
            var result = new ServiceResponse<List<CartProductResponseModel>>()
            {
                Data = new List<CartProductResponseModel>()
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

                var cartProcuts = new CartProductResponseModel
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
    }
}
