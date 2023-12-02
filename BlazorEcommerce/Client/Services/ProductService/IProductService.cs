﻿using BlazorEcommerce.Shared.Models;

namespace BlazorEcommerce.Client.Services.ProductService
{
    public interface IProductService
    {
        event Action ProductsChanged;

        #region Properties
        List<Product> Products { get; set; }
        PagginationBaseModel Paggination { get; set; }
        string Message { get; set; }
        string LastSearchText { get; set; }
        #endregion

        Task GetProducts(string? categoryUrl = null);
        Task<ServiceResponse<Product>> GetProductById(int productId);
        Task SearchProducts(ProductSearchRequestModel requestModel);
        Task<List<string>> GetProductSearchSuggestions(string searchText);
    }
}
