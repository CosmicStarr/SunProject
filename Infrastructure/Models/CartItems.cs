using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class CartItems
    {
        public int CartItemsId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public int Quantity { get; set; }
        public string ItemImageUrl { get; set; }
        public string ItemBrand { get; set; }
        public string itemCategory { get; set; }
    }
}
