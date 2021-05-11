using Core.Data.Interfaces;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ProductsWithBrandsandCatSpecs : BaseSpecification<Products>
    {
        public ProductsWithBrandsandCatSpecs(ProductSpecParams productSpec) : base(x =>
          (string.IsNullOrEmpty(productSpec.Search) || x.Name.ToLower().Contains(productSpec.Search)) &&
          (!productSpec.BrandId.HasValue || x.ProductBrandId == productSpec.BrandId) &&
          (!productSpec.CategoryId.HasValue || x.CategoryId == productSpec.CategoryId))
        {
            AddInclude(p => p.Category);
            AddInclude(p => p.ProductBrand);
            AddOrderby(x => x.Name);
            ApplyPaging(take: productSpec.PageSize * productSpec.PageIndex, productSpec.PageSize);
            if (!string.IsNullOrEmpty(productSpec.Sort))
            {
                switch (productSpec.Sort)
                {
                    case "priceAsc":
                        AddOrderby(p => p.Price);
                        break;
                    case "priceDsc":
                        AddOrderbyDescending(p => p.Price);
                        break;
                    default:
                        AddOrderby(n => n.Name);
                        break;
                }
            }
        }
        public ProductsWithBrandsandCatSpecs(int Id) : base(x => x.Id == Id)
        {
            AddInclude(p => p.Category);
            AddInclude(p => p.ProductBrand);
        }
    }
}
