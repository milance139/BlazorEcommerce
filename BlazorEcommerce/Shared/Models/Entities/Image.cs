using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Shared.Models.Entities
{
    public class Image : DomainObject
    {
        public string Data { get; set; } = string.Empty;
    }
}
