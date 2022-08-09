using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLib.OrdersManagment;
using VeeSeven.Models;
using VeeSeven.Helper;

namespace VeeSeven.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            List<ShoppingCart> orders = OrderHandler.GetOrders().ToOrdersList();
            List<ShoppingCart> mm = orders.Take(10).ToList();
            if (mm !=null)
            {
                ViewData["Orders"] = mm;
                return View();
            }

            return BadRequest();

        }

        public IActionResult UpdateOrder(int id)
        {
            ShoppingCart order = OrderHandler.GetOrder(id).ToOrderModel();

            if (order !=null)
            {
                return View(order);
            }
            return BadRequest();

        }

    }
}
