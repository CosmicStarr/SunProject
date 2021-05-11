using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {

        }
        public ShoppingCart(string cartId)
        {
            CartId = cartId;
        }

        public string CartId { get; set; }
        public List<CartItems> Items { get; set; } = new List<CartItems>();
    }
}
