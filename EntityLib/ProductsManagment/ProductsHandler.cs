using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLib.ProductsManagment
{
    public class ProductsHandler
    {

        public static List<Product> GetRandomSixProduct()
        {
            using (ApplicationDB context = new ApplicationDB())
            {
                return context.Products.FromSqlRaw("SELECT top 6 * from dbo.Products where stock > 10 order by newid()").ToList();
            }
        }
        public static  List<Product> GetProductsList()
        {
            using (ApplicationDB context = new ApplicationDB())
            {
                return (from products in context.Products where products.Stock > 10 select products).ToList();

            }
        }

        public static Product GetProduct(int id)
        {
            using (ApplicationDB context =new ApplicationDB())
            {
                return (from product in context.Products where product.Id == id select product).FirstOrDefault();
            }
        }

        public static List<Product> RelatedProduct()
        {
            using (ApplicationDB context = new ApplicationDB())
            {
                return context.Products.FromSqlRaw("SELECT top 3 * from dbo.Products where stock > 10 order by newid()").ToList();
            }
        }

        public static List<Product> GetAdminProductList()
        {
            using (ApplicationDB context = new ApplicationDB())
            {
                return context.Products.ToList();

            }
        }

        public static void AddProduct(Product entity)
        {
            using (ApplicationDB context = new ApplicationDB())
            {
                context.Add(entity);
                context.SaveChanges();
            }
        }

        public static void UpdateProduct(Product entity)
        {
            using (ApplicationDB context = new ApplicationDB())
            {
                context.Update(entity);
                context.SaveChanges();
            }
        }

        public static void DeleteProduct(Product entity)
        {
            using (ApplicationDB context = new ApplicationDB())
            {
                context.Remove(entity);
                context.SaveChanges();
            }

        }

    }
}
