using Infrastructure.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Core.Data.Seed
{
    public class SeedApplicationContext
    {
        public static async Task SeedAsync(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if(!context.GetBrands.Any())
                {
                    var brandData = File.ReadAllText("../Core/Data/Seed/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductsBrand>>(brandData);
                    foreach (var item in brands)
                    {
                        context.GetBrands.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.GetProducts.Any())
                {
                    var brandData = File.ReadAllText("../Core/Data/Seed/products.json");
                    var brands = JsonSerializer.Deserialize<List<Products>>(brandData);
                    foreach (var item in brands)
                    {
                        context.GetProducts.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                if (!context.GetCategories.Any())
                {
                    var brandData = File.ReadAllText("../Core/Data/Seed/types.json");
                    var brands = JsonSerializer.Deserialize<List<Category>>(brandData);
                    foreach (var item in brands)
                    {
                        context.GetCategories.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                var logger = loggerFactory.CreateLogger<SeedApplicationContext>();
                logger.LogError(ex.Message);
            }

        }
    }
}
