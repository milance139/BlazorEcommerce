namespace BlazorEcommerce.Client.Shared
{
    public partial class CartCounter
    {
        private int GetCartItemsCount()
        {
            var cart = LocalStorage.GetItem<List<CartItem>>("cart");

            return cart == null ? 0 : cart.Count;
        }

        protected override void OnInitialized()
        {
            CartService.OnChange += StateHasChanged;
        }

        public void Dispose()
        {
            CartService.OnChange -= StateHasChanged;
        }
    }
}
