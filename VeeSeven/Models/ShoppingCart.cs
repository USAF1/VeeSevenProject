using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeeSeven.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        public List<CartItemModel> ShopingItems { get; set; }

        public UserModel User { get; set; }

        public string Status { get; set; }

        public int Totoal { get; set; }
    }
}
