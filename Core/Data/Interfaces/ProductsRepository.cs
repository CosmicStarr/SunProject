using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Interfaces
{
    public class ProductsRepository:IProductsRepository
    {
        private ApplicationDbContext _db;
        public ProductsRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Products> GetProductsByIdAsync(int Id)
        {
            return await _db.GetProducts.Include(p => p.ProductBrand).Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<IReadOnlyList<Products>> GetProductsByAsync()
        {
            return await _db.GetProducts.Include(p => p.Category).Include(p => p.ProductBrand).ToListAsync();
        }

        public async Task<IReadOnlyList<ProductsBrand>> GetProductsBrands()
        {
            return await _db.GetBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<Category>> GetCategoriesTypes()
        {
            return await _db.GetCategories.ToListAsync();
        }
    }
}
