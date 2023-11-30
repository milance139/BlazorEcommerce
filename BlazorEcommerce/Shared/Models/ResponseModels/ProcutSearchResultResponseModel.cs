using BlazorEcommerce.Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Shared.Models.ResponseModels
{
    public class ProcutSearchResultResponseModel : PagginationBaseModel
    {
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
