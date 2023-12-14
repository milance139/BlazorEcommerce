using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce.Client.Shared
{
    public partial class Pagginator
    {
        [Parameter]
        public PagginationBaseModel Paggination { get; set; }
        [Parameter]
        public Func<int, Task> OnPageChange { get; set; }
        public int CurrentPage => Paggination.CurrentPage;
    }
}
