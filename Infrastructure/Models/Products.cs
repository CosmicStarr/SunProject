using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class Products : BaseClass
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public ProductsBrand ProductBrand { get; set; }
        public int ProductBrandId { get; set; }
    }
}
