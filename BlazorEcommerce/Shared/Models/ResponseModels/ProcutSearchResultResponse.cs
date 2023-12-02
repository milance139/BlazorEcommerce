using BlazorEcommerce.Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Shared.Models.ResponseModels
{
    public class ProcutSearchResultResponse : PagginationBaseModel
    {
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
