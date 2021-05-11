using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Interfaces
{
    public interface ICartRepository
    {
        Task<ShoppingCart> GetCartAsync(string CartId);
        Task<ShoppingCart> UpdateCartAsync(ShoppingCart Cart);
        Task<bool> DeleteCartAsync(string CartId);
    }
}
