using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeeSeven.Models
{
    public class CartItemModel
    {
        public int Id { get; set; }
        public ProductModel Item { get; set; }

        public int Quantity { get; set; }
    }
}
