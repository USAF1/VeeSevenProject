using EntityLib.ProductsManagment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeeSeven.Extras;
using VeeSeven.Helper;
using VeeSeven.Models;
using EntityLib.UserManagment;
using EntityLib.OrdersManagment;

namespace VeeSeven.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddToCart(CartItemModel model)
        {

            List<CartItemModel> vv = HttpContext.Session.Get<List<CartItemModel>>(Constants.CartKey);

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
                
                CartItemModel item = vv.Find(x=>x.Item.Id == model.Item.Id);
                if (item == null)
                {
                    vv.Add(new CartItemModel() { Item = find, Quantity = model.Quantity });
                }             
                HttpContext.Session.Set(Constants.CartKey, vv);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult ConfirmOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ConfirmOrder(UserModel model)
        {
            model.Role = UserHandler.getRole("Customer").ToRoleModel();

            ShoppingCart cart = new ShoppingCart();

            cart.User = model;
            List<CartItemModel> cartItems = HttpContext.Session.Get<List<CartItemModel>>(Constants.CartKey);

            int total = 0;

            if (cartItems != null)
            {
                cart.ShopingItems = cartItems;
                foreach (var item in cartItems)
                {
                    total = total + (item.Quantity * (int) item.Item.SalePrice);
                }
            }
            cart.Status = Constants.Pending;

            cart.Totoal = total;

            OrderHandler.AddOrder(cart.ToOrderEntity());

            return RedirectToAction("Index", "Home");
        }

        public IActionResult UpdatePendingStatus(int id)
        {
            ShoppingCart order = OrderHandler.GetOrder(id).ToOrderModel();

            order.Status = Constants.Pending;

            OrderHandler.UpdateOrder(order.ToOrderEntity());

            return RedirectToAction("index","Admin");
        }

        public IActionResult UpdateCompletedStatus(int id)
        {
            ShoppingCart order = OrderHandler.GetOrder(id).ToOrderModel();

            order.Status = Constants.Completed;

            OrderHandler.UpdateOrder(order.ToOrderEntity());

            return RedirectToAction("index", "Admin");
        }
        public IActionResult UpdateSendStatus(int id)
        {
            ShoppingCart order = OrderHandler.GetOrder(id).ToOrderModel();

            order.Status = Constants.Shipped;

            OrderHandler.UpdateOrder(order.ToOrderEntity());

            return RedirectToAction("index", "Admin");
        }

        public IActionResult AdminOrders()
        {
            List<ShoppingCart> orders = OrderHandler.GetOrders().ToOrdersList();
            ViewData["Orders"] = orders;
            return View();
        }

        [HttpGet]
        public IActionResult DeleteOrder(int id)
        {
            ShoppingCart order = OrderHandler.GetOrder(id).ToOrderModel();
            return View(order);
        }

        [HttpPost]
        public IActionResult DeleteOrder(ShoppingCart model)
        {
            Order order = OrderHandler.GetOrder(model.Id);


            OrderHandler.DeleteOrder(order);
            return RedirectToAction("AdminOrders","ShoppingCart");
        }

    }
}
