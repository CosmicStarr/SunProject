using Core.Data.Interfaces;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SunProject.Controllers
{
    public class ShoppingCartController : BaseApiController
    {
        private readonly ICartRepository _cartRepository;

        public ShoppingCartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        [HttpGet]
        public async Task<ActionResult<ShoppingCart>> GetCartById(string Id)
        {
            var Cart = await _cartRepository.GetCartAsync(Id);
            return Ok(Cart ?? new ShoppingCart(Id));
        }
        [HttpPost]
        public async Task<ActionResult<ShoppingCart>> UpdateCart(ShoppingCart shoppingCart)
        {
            var UpdatedCart = await _cartRepository.UpdateCartAsync(shoppingCart);
            return Ok(UpdatedCart);
        }
        [HttpDelete]
        public async Task DeleteAsync(string Id)
        {
            await _cartRepository.DeleteCartAsync(Id);
        }
    }
}
