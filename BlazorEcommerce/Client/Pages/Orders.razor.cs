﻿
namespace BlazorEcommerce.Client.Pages
{
    public partial class Orders
    {
        List<OrderOverviewResponse> orders = null;

        protected override async Task OnInitializedAsync()
        {
            orders = await OrderService.GetOrders();
        }
    }
}
