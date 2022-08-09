using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLib.ProductsManagment;
using VeeSeven.Models;

namespace VeeSeven.Helper
{
    public static class ProductsHelper
    {

        public static ProductModel ToModel(this Product entity)
        {
            ProductModel model = new ProductModel();

            if (entity !=null)
            {
                model.Id = entity.Id;
                model.Name = entity.Name;
                model.PurchasePrice = entity.PurchasePrice;
                model.SalePrice = entity.SalePrice;
                model.Stock = entity.Stock;
                model.Discription = entity.Discription;
                if (entity.Image !=null)
                {
                    model.Image = Convert.ToBase64String(entity.Image);
                }
            }

            return model;
        }

        public static List<ProductModel> ToList(this List<Product> entites)
        {
            List<ProductModel> modelList = new List<ProductModel>();

            foreach (var produtc in entites)
            {
                modelList.Add(ToModel(produtc));
            }
            return modelList;
        }

        public static IQueryable<ProductModel> ToIQuerable(this List<Product> entites)
        {
            List<ProductModel> modelList = new List<ProductModel>();

            foreach (var produtc in entites)
            {
                modelList.Add(ToModel(produtc));
            }
            return modelList.AsQueryable();
        }

        public static Product ToEntity(this ProductModel model)
        {
            Product entity = new Product();
            if (model != null)
            {
                entity.Name = model.Name;
                if(model.Discription != null)
                {
                    entity.Discription = model.Discription;
                }
                entity.PurchasePrice = model.PurchasePrice;
                entity.SalePrice = model.SalePrice;
                entity.Stock = model.Stock;
                entity.Id = model.Id;
            }
            return entity;
        } 

    }
}
