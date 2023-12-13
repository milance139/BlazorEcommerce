using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorEcommerce.Shared.Models.Entities
{
    public class Category : DomainObject
    {
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public bool IsVisible { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        [NotMapped]
        public bool Editing { get; set; } = false;
        [NotMapped]
        public bool IsNew { get; set; } = false;
    }
}
