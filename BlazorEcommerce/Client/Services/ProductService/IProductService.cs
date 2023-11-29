namespace BlazorEcommerce.Client.Services.ProductService
{
    public interface IProductService
    {
        event Action ProductsChanged;

        #region Properties
        List<Product> Products { get; set; }
        string Message { get; set; }
        #endregion

        Task GetProducts(string? categoryUrl = null);

        Task<ServiceResponse<Product>> GetProductById(int productId);

        Task SearchProducts(string searchText);
        Task<List<string>> GetProductSearchSuggestions(string searchText);
    }
}
