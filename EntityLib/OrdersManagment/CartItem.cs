using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using EntityLib.ProductsManagment;

namespace EntityLib.OrdersManagment
{
    public class CartItem
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public Product Item { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
