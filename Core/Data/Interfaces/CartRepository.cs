using Infrastructure.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Core.Data.Interfaces
{
    public class CartRepository : ICartRepository
    {
        private readonly IDatabase _database;
        public CartRepository(IConnectionMultiplexer Redis)
        {
            _database = Redis.GetDatabase();
        }
        public async Task<bool> DeleteCartAsync(string CartId)
        {
            return await _database.KeyDeleteAsync(CartId);
        }

        public async Task<ShoppingCart> GetCartAsync(string CartId)
        {
            var CartData = await _database.StringGetAsync(CartId);
            return CartData.IsNullOrEmpty ? null : JsonSerializer.Deserialize<ShoppingCart>(CartData);

        }

        public async Task<ShoppingCart> UpdateCartAsync(ShoppingCart Cart)
        {
            var UpdateCart = await _database.StringSetAsync(Cart.CartId, JsonSerializer.Serialize(Cart), TimeSpan.FromDays(30));
            if (!UpdateCart) return null;
            return await GetCartAsync(Cart.CartId);
        }
    }
}
