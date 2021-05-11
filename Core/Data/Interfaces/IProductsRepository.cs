using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Interfaces
{
    public interface IProductsRepository
    {
        Task<Products> GetProductsByIdAsync(int Id);
        Task<IReadOnlyList<Products>> GetProductsByAsync();
        Task<IReadOnlyList<ProductsBrand>> GetProductsBrands();
        Task<IReadOnlyList<Category>> GetCategoriesTypes();
    }
}
