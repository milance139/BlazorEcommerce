﻿
namespace BlazorEcommerce.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        public ProductService(DataContext context) 
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Product>>> GetFeaturedProducts()
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data = await _context.Products
                   .Where(p => p.IsFeatured)
                   .Include(p => p.Variants)
                   .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
        {
            var response = new ServiceResponse<Product>();

            var product = await _context.Products
                    .Include(p => p.Variants)
                    .ThenInclude(v => v.ProductType)
                    .FirstOrDefaultAsync(p => p.Id == productId);

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
                    .Include(p => p.Variants).ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl)
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data = await _context.Products
                    .Include(p => p.Variants)
                    .Where(p => p.Category.Url.ToLower().Equals(categoryUrl.ToLower()))
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

        public async Task<ServiceResponse<ProcutSearchResultResponse>> SearchProducts(ProductSearchRequestModel requestModel)
        {
            ProcutSearchResultResponse responseModel = new ProcutSearchResultResponse();

            List<Product> foundProducts = await FindProductsBySearchText(requestModel.SearchText);

            responseModel.TotalItems = foundProducts.Count();
            responseModel.TotalPages = (int)Math.Ceiling(responseModel.TotalItems / (decimal)requestModel.PageSize);
            responseModel.CurrentPage = requestModel.CurrentPage;

            var products = await _context.Products
                                .Where(p => p.Title.ToLower().Contains(requestModel.SearchText) || p.Description.ToLower().Contains(requestModel.SearchText))
                                .Include(p => p.Variants)
                                .Skip((requestModel.CurrentPage - 1) * requestModel.PageSize)
                                .Take(requestModel.PageSize)
                                .ToListAsync();

            responseModel.Products = products;

            var response = new ServiceResponse<ProcutSearchResultResponse>
            {
                Data = responseModel
            };

            return response;
        }

        private async Task<List<Product>> FindProductsBySearchText(string searchText)
        {
            return await _context.Products
                                .Where(p => p.Title.ToLower().Contains(searchText) || p.Description.ToLower().Contains(searchText))
                                .Include(p => p.Variants)
                                .ToListAsync();
        }
    }
}
