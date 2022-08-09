using EntityLib.ProductsManagment;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeeSeven.Models;
using VeeSeven.Helper;
using VeeSeven.Extras;
using EntityLib.ImactStoriesManagment;


namespace VeeSeven.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            List<ProductModel> products = ProductsHandler.GetRandomSixProduct().ToList();

            List<ImactStorieModel> story = ImpactStoryHandler.getStories().ToList();


            if (products != null && story != null)
            {
                ViewData["Products"] = products;

                ViewData["Stories"] = story;
                return View();
            }
          
            return BadRequest();
        }

        public IActionResult WhoAreWe()
        {
            return View();
        }

        public IActionResult AddToCart(CartItemModel model)
        {

            List < CartItemModel > vv = HttpContext.Session.Get<List<CartItemModel>>(Constants.CartKey);

            if (vv == null)
            {
                 vv = new List<CartItemModel>();
                ProductModel find = ProductsHandler.GetProduct(model.Item.Id).ToModel();
                vv.Add(new CartItemModel() { Item = find, Quantity = model.Quantity });
                HttpContext.Session.Set(Constants.CartKey, vv);
            }
            else
            {
                ProductModel find = ProductsHandler.GetProduct(model.Item.Id).ToModel();
                vv.Add(new CartItemModel() { Item = find, Quantity = model.Quantity });
                HttpContext.Session.Set(Constants.CartKey, vv);
            }
            return RedirectToAction("Index");
        }

        public IActionResult ShoppingCart()
        {
            return View();
        }
    }
}
