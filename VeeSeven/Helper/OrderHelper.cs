using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLib.OrdersManagment;
using EntityLib.UserManagment;
using VeeSeven.Models;
using VeeSeven.Helper;
using VeeSeven.Extras;
namespace VeeSeven.Helper
{
    public static class OrderHelper
    {

        public static CartItem ToEntityCartItem(this CartItemModel model)
        {
            CartItem entity = new CartItem();
            if (model != null)
            {
                if (model.Item != null)
                {
                    entity.Item = model.Item.ToEntity();
                }
                entity.Quantity = model.Quantity;
                entity.Id = model.Id;
            }


            return entity;

        }

        public static List<CartItem> ToListCartItem(this List<CartItemModel> items)
        {
            List<CartItem> cartitems = new List<CartItem>();
            foreach (var item in items)
            {
                cartitems.Add(item.ToEntityCartItem());
            }

            return cartitems;
        }

        public static Order ToOrderEntity(this ShoppingCart model)
        {
            Order entity = new Order();
            if (model != null)
            {
                if (model.ShopingItems != null)
                {
                    entity.ShopingItems = model.ShopingItems.ToListCartItem();
                }
                entity.Status = model.Status;
                entity.Totoal = model.Totoal;
                entity.Id = model.Id;
                entity.User = model.User.ToUserEntity();
            }
            return entity;
        }

        public static CartItemModel ToModelCartItem(this CartItem entity)
        {
            CartItemModel model = new CartItemModel();
            if (entity != null)
            {
                if (entity.Item != null)
                {
                    model.Item = entity.Item.ToModel();
                }
                model.Quantity = entity.Quantity;
                model.Id = entity.Id;
            }


            return model;

        }

        public static List<CartItemModel> ToListCartItem(this List<CartItem> items)
        {
            List<CartItemModel> cartitems = new List<CartItemModel>();
            foreach (var item in items)
            {
                cartitems.Add(item.ToModelCartItem());
            }
            return cartitems;
        }


        public static List<ShoppingCart> ToOrdersList(this List<Order> ordersentity)
        {
            List<ShoppingCart> orders = new List<ShoppingCart>();

            if (ordersentity !=null)
            {

                foreach (var order in ordersentity)
                {
                    orders.Add(new ShoppingCart() { Id =order.Id, ShopingItems =order.ShopingItems.ToListCartItem(), Status = order.Status, User = order.User.ToUserModel(), Totoal =order.Totoal });
                }
            }
            return orders;
        }


        public static ShoppingCart ToOrderModel(this Order entity)
        {
            ShoppingCart model = new ShoppingCart();

            model.Id = entity.Id;
            model.Status = entity.Status;
            model.Totoal = entity.Totoal;
            model.ShopingItems = entity.ShopingItems.ToListCartItem();
            model.User = entity.User.ToUserModel();

            return model;

        }

    }
}
