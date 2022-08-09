using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeeSeven.Models;
using EntityLib.ProductsManagment;
using VeeSeven.Helper;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using Microsoft.AspNetCore.Http;
using System.IO;
using VeeSeven.Extras;

namespace VeeSeven.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<ProductModel> products = ProductsHandler.GetAdminProductList().ToList();

            if (products != null)
            {

                ViewData["Products"] = products;
                return View();
            }
            return BadRequest();
        }

        [HttpGet]
        public  IActionResult ProductsPage(int? pageNumber)
        {

            int pageSize = 9;

            var products = ProductsHandler.GetProductsList().ToList();

            if (products != null)
            {
                ViewData["Products"] = products;
                return View(PaginatedList<ProductModel>.CreateAsync(products, pageNumber ?? 1, pageSize));
            }

            return BadRequest();
        }
        [HttpGet]
        public IActionResult SingleProduct(int id)
        {
            ProductModel model = ProductsHandler.GetProduct(id).ToModel();
            CartItemModel item = new CartItemModel();
            item.Item = model;
            item.Quantity = 1;
            List<ProductModel> products = ProductsHandler.RelatedProduct().ToList();
            if (item !=null && products != null)
            {
                ViewData["RelatedProdutcs"] = products;

                return View(item);
            }
            return BadRequest();

        }
        [HttpGet]
        public IActionResult AddToCart()
        {
            return RedirectToAction("ProdutcsPage");
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(ProductModel model)
        {

            Product entity = ProductsHelper.ToEntity(model);

            IFormFile photo = Request.Form.Files["image"];
            if (photo != null && photo.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    photo.CopyTo(ms);
                    entity.Image = ms.ToArray();
                }
            }
            ProductsHandler.AddProduct(entity);

            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            ProductModel model = ProductsHandler.GetProduct(id).ToModel();
            if (model != null)
            {
                return View(model);
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult UpdateProduct(ProductModel model)
        {
            Product entity = new Product();

            if (model != null)
            {
                entity  = ProductsHandler.GetProduct(model.Id);
                entity.Name = model.Name != null ? model.Name : entity.Name;
                entity.PurchasePrice = model.PurchasePrice > 0 ? model.PurchasePrice : entity.PurchasePrice;
                entity.SalePrice = model.SalePrice > 0 ? model.SalePrice : entity.SalePrice;
                entity.Discription = model.Discription != null ? model.Discription : entity.Discription;
                entity.Stock = model.Stock > 0 ? model.Stock : entity.Stock;
            }

            IFormFile photo = Request.Form.Files["image"];
            if (photo != null && photo.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    photo.CopyTo(ms);
                    entity.Image = ms.ToArray();
                }
            }
            ProductsHandler.UpdateProduct(entity);

            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult DeleteProduct(int id)
        {
            ProductModel model = ProductsHandler.GetProduct(id).ToModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteProduct(ProductModel model)
        {
           ProductsHandler.DeleteProduct(ProductsHandler.GetProduct(model.Id));



            return RedirectToAction("Index");
        }
    }
}
