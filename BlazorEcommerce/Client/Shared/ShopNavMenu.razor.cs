﻿namespace BlazorEcommerce.Client.Shared
{
    public partial class ShopNavMenu
    {
        private bool collapseNavMenu = true;

        private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }

        protected override async Task OnInitializedAsync()
        {
            await CategoryService.GetAllCategories();
            CategoryService.OnChange += StateHasChanged;
        }

        public void Dispose()
        {
            CategoryService.OnChange -= StateHasChanged;
        }
    }
}
