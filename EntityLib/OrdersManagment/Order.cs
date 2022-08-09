using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using EntityLib.UserManagment;
namespace EntityLib.OrdersManagment
{
    public class Order
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public List<CartItem> ShopingItems { get; set; }
        [Required]
        public Users User { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Status { get; set; }
        [Required]
        public int Totoal { get; set; }

    }
}
