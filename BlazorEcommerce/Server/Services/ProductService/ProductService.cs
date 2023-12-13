
namespace BlazorEcommerce.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductService(DataContext context, IHttpContextAccessor httpContextAccessor) 
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<Product>> CreateProduct(Product product)
        {
            foreach (var variant in product.Variants)
            {
                variant.ProductType = null;
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return new ServiceResponse<Product> { Data = product };
        }

        public async Task<ServiceResponse<bool>> DeleteProduct(int productId)
        {
            var dbProduct = await _context.Products.FindAsync(productId);
            if(dbProduct == null)
            {
                return new ServiceResponse<bool> 
                { 
                    Data = false,
                    Message = "Product not found",
                    Success = false
                };
            }

            dbProduct.IsDeleted = true;
            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<List<Product>>> GetAdminProducts()
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data = await _context.Products
                    .Where(p => !p.IsDeleted)
                    .Include(p => p.Variants.Where(v => !v.IsDeleted))
                    .ThenInclude(v => v.ProductType)
                    .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetFeaturedProducts()
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data = await _context.Products
                   .Where(p => p.IsFeatured && p.IsVisible && !p.IsDeleted)
                   .Include(p => p.Variants.Where(v => v.IsVisible && !v.IsDeleted))
                   .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
        {
            var response = new ServiceResponse<Product>();
            Product product = null;

            if (_httpContextAccessor.HttpContext.User.IsInRole("Admin"))
            {
                product = await _context.Products
                    .Include(p => p.Variants.Where(v =>!v.IsDeleted))
                    .ThenInclude(v => v.ProductType)
                    .FirstOrDefaultAsync(p => p.Id == productId && !p.IsDeleted);
            }
            else
            {
                product = await _context.Products
                    .Include(p => p.Variants.Where(v => v.IsVisible && !v.IsDeleted))
                    .ThenInclude(v => v.ProductType)
                    .FirstOrDefaultAsync(p => p.Id == productId && p.IsVisible && !p.IsDeleted);
            }

            if (product == null)
            {
                response.Success = false;
                response.Message = "Product with endered Id does not exists.";
            }
            else
                response.Data = product;

            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data = await _context.Products
                    .Where(p => p.IsVisible && !p.IsDeleted)
                    .Include(p => p.Variants.Where(v => v.IsVisible && !v.IsDeleted)).ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl)
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data = await _context.Products
                    .Where(p => p.Category.Url.ToLower().Equals(categoryUrl.ToLower()) &&
                    p.IsVisible && !p.IsDeleted)
                    .Include(p => p.Variants.Where(v => v.IsVisible && !v.IsDeleted))
                    .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText)
        {
            var products = await FindProductsBySearchText(searchText);

            List<string> result = new List<string>();

            foreach (var product in products)
            {
                if(product.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(product.Title);
                }

                if(product.Description != null)
                {
                    var punctuacion = product.Description.Where(char.IsPunctuation)
                        .Distinct().ToArray();
                    var words = product.Description.Split()
                        .Select(s => s.Trim(punctuacion));

                    foreach (var word in words)
                    {
                        if(word.Contains(searchText, StringComparison.OrdinalIgnoreCase) && !result.Contains(word))
                        {
                            result.Add(word); 
                        }
                    }
                }
            }

            return new ServiceResponse<List<string>>() { Data = result };
        }

        public async Task<ServiceResponse<bool>> PromoteProduct(Product product)
        {
            var dbProduct = await _context.Products.FindAsync(product.Id);
            if (dbProduct == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = "Product not found"
                };
            }

            dbProduct.IsFeatured = !product.IsFeatured;

            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<ProductSearchResultResponse>> SearchProducts(ProductSearchRequestModel requestModel)
        {
            ProductSearchResultResponse responseModel = new ProductSearchResultResponse();

            List<Product> foundProducts = await FindProductsBySearchText(requestModel.SearchText);

            responseModel.TotalItems = foundProducts.Count();
            responseModel.TotalPages = (int)Math.Ceiling(responseModel.TotalItems / (decimal)requestModel.PageSize);
            responseModel.CurrentPage = requestModel.CurrentPage;

            var products = await _context.Products
                                .Where(p => p.Title.ToLower().Contains(requestModel.SearchText) || 
                                    p.Description.ToLower().Contains(requestModel.SearchText) &&
                                    p.IsVisible && !p.IsDeleted)
                                .Include(p => p.Variants.Where(v => v.IsVisible && !v.IsDeleted))
                                .Skip((requestModel.CurrentPage - 1) * requestModel.PageSize)
                                .Take(requestModel.PageSize)
                                .ToListAsync();

            responseModel.Products = products;

            var response = new ServiceResponse<ProductSearchResultResponse>
            {
                Data = responseModel
            };

            return response;
        }

        public async Task<ServiceResponse<Product>> UpdateProduct(Product product)
        {
            var dbProduct = await _context.Products.FindAsync(product.Id);
            if (dbProduct == null)
            {
                return new ServiceResponse<Product>
                {
                    Success = false,
                    Message = "Product not found"
                };
            }

            dbProduct.Title = product.Title;
            dbProduct.Description = product.Description;
            dbProduct.ImageURL = product.ImageURL;
            dbProduct.CategoryId = product.CategoryId;
            dbProduct.IsVisible = product.IsVisible;
            dbProduct.IsFeatured = product.IsFeatured;

            foreach (var variant in product.Variants)
            {
                var dbVariant = await _context.ProductVariants
                    .SingleOrDefaultAsync(v => v.ProductId == variant.ProductId &&
                        v.ProductTypeId == variant.ProductTypeId);

                if (dbVariant == null)
                {
                    variant.ProductType = null;
                    _context.ProductVariants.Add(variant);
                }
                else
                {
                    dbVariant.ProductTypeId = variant.ProductTypeId;
                    dbVariant.Price = variant.Price;
                    dbVariant.OriginalPrice = variant.OriginalPrice;
                    dbVariant.IsDeleted = variant.IsDeleted;
                    dbVariant.IsVisible = variant.IsVisible;
                }
            }

            await _context.SaveChangesAsync();

            return new ServiceResponse<Product> { Data = product };
        }

        private async Task<List<Product>> FindProductsBySearchText(string searchText)
        {
            return await _context.Products
                                .Where(p => p.Title.ToLower().Contains(searchText) ||
                                    p.Description.ToLower().Contains(searchText) &&
                                    p.IsVisible && !p.IsDeleted)
                                .Include(p => p.Variants.Where(v => v.IsVisible && !v.IsDeleted))
                                .ToListAsync();
        }
    }
}
