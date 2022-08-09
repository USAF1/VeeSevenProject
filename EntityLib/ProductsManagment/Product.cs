using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLib.ProductsManagment
{
    public class Product
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName="varchar(50)")]
        public string Name { get; set; }

        [Required]

        public float PurchasePrice { get; set; }

        [Required]
        public float SalePrice { get; set; }

        [Required]
        [Column(TypeName ="varchar(max)")]
        public string Discription { get; set; }
        [Column(TypeName="image")]
        public byte[] Image { get; set; }
        [Required]
        public int Stock { get; set; }

    }
}
