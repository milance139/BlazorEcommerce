using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Shared.Models.Entities
{
    public class Product : DomainObject
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string ImageURL { get; set; } = string.Empty;

        public Category? Category { get; set; }

        public int CategoryId { get; set; }

        public bool IsFeatured { get; set; } = false;
        public List<ProductVariant> Variants { get; set; } = new List<ProductVariant>();
    }
}
