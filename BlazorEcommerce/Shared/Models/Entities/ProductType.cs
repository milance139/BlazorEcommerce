using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Shared.Models.Entities
{
    public class ProductType : DomainObject
    {
        public string Name { get; set; } = string.Empty;
    }
}
