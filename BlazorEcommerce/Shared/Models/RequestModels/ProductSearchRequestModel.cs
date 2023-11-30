using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Shared.Models.RequestModels
{
    public class ProductSearchRequestModel : PagginationBaseModel
    {
        public string SearchText { get; set; } = string.Empty;
    }
}
