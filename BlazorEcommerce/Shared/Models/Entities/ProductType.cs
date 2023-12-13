using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorEcommerce.Shared.Models.Entities
{
    public class ProductType : DomainObject
    {
        public string Name { get; set; } = string.Empty;
        [NotMapped]
        public bool Editing { get; set; } = false;
        [NotMapped]
        public bool IsNew { get; set; } = false;
    }
}
