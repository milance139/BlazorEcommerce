using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorEcommerce.Client.Shared
{
    public partial class Search
    {
        private string searchText = string.Empty;
        private List<string> suggestions = new List<string>();

        protected ElementReference searchInput;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                await  searchInput.FocusAsync();
            }
        }

        public void SearchProducts()
        {
            NavigationManager.NavigateTo($"search/{searchText}");
        }

        public async Task HandleSearch(KeyboardEventArgs args)
        {
            if(args.Key == null || args.Key.Equals("Enter"))
            {
                if (searchText != string.Empty)
                {
                    SearchProducts();
                }
                else
                   await ProductService.GetProducts();
            }
            else if(searchText.Length > 1) 
            {
                suggestions = await ProductService.GetProductSearchSuggestions(searchText);
            }
        }
    }
}
