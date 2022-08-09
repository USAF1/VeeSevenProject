using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeeSeven.Models;
using EntityLib.OrdersManagment;

namespace VeeSeven.Extras
{
    public static class Ext
    {

        static ShoppingCart  cart = new ShoppingCart();

        public static void Set<T>(this ISession session, string key,  T obj)
        {
            session.SetString(key, JsonConvert.SerializeObject(obj));
        }


        public static T Get<T>(this ISession session, string key)
        {
            string data = session.GetString(key);

            if (string.IsNullOrWhiteSpace(data)) return default;

             return JsonConvert.DeserializeObject<T>(data);
        }

        public static int PendingOrders()
        {
            List<Order> orders = OrderHandler.GetPendingOrders();

            return orders.Count();
        }

        public static int CompletedOrders()
        {
            List<Order> orders = OrderHandler.GetCompletedOrders();

            return orders.Count();
        }
        public static int SendOrders()
        {
            List<Order> orders = OrderHandler.GetSendOrders();

            return orders.Count();
        }
    }
}
