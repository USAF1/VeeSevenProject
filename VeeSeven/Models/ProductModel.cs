using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeeSeven.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float PurchasePrice { get; set; }

        public float SalePrice { get; set; }

        public string Discription { get; set; }

        public string Image { get; set; }

        public int Stock { get; set; }

    }
}
