using Core.Data.Interfaces;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ProductsWithFiltersCountSpecifications : BaseSpecification<Products>
    {
        public ProductsWithFiltersCountSpecifications(ProductSpecParams productSpec) : base(x =>
        (string.IsNullOrEmpty(productSpec.Search) || x.Name.ToLower().Contains(productSpec.Search)) &&
        (!productSpec.BrandId.HasValue || x.ProductBrandId == productSpec.BrandId) &&
        (!productSpec.CategoryId.HasValue || x.CategoryId == productSpec.CategoryId))
        {

        }
    }
}
