using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLib.OrdersManagment
{
    public class OrderHandler
    {
        public static void AddOrder(Order entity)
        {
            using (ApplicationDB context = new ApplicationDB())
            {
                if (entity.User !=null)
                {

                    context.Entry(entity.User).State = EntityState.Added;
                }
                if (entity.ShopingItems !=null)
                {
                    foreach (var item in entity.ShopingItems)
                    {
                        context.Entry(item.Item).State = EntityState.Unchanged;
                    }
                }
                context.Add(entity);
                context.SaveChanges();
            }

        }

        public static List<Order> GetOrders()
        {
            using (ApplicationDB context =new ApplicationDB())
            {

                return context.Orders
                    .Include(x => x.ShopingItems)
                    .ThenInclude(z => z.Item)
                    .Include(t => t.User).ToList();
            }
        }

        public static Order GetOrder(int id)
        {
            Order order = new Order();

            using (ApplicationDB context = new ApplicationDB())
            {
                order = (from Order in context.Orders.Include(x => x.ShopingItems)
                        .ThenInclude(z => z.Item)
                        .Include(t => t.User)
                         where Order.Id == id
                         select Order).FirstOrDefault();

                return order;
            }
        }

        public static List<Order> GetPendingOrders()
        {
            using (ApplicationDB context = new ApplicationDB())
            {
                return (from order in context.Orders where order.Status == "Pending" select order).ToList();
            }
        }
        public static List<Order> GetCompletedOrders()
        {
            using (ApplicationDB context = new ApplicationDB())
            {
                return (from order in context.Orders where order.Status == "Completed" select order).ToList();
            }
        }
        public static List<Order> GetSendOrders()
        {
            using (ApplicationDB context = new ApplicationDB())
            {
                return (from order in context.Orders where order.Status == "Send" select order).ToList();
            }
        }

        public static void UpdateOrder(Order entity)
        {
            using (ApplicationDB context = new ApplicationDB())
            {
                if (entity.ShopingItems != null)
                {
                    foreach (var item in entity.ShopingItems)
                    {
                        context.Entry(item.Item).State = EntityState.Unchanged;
                    }
                }

                if (entity.User != null)
                {

                    context.Entry(entity.User).State = EntityState.Unchanged;
                }
                context.Orders.Update(entity);

                //context.Orders.FromSqlRaw("Update dbo.Orders Set Status = {0} where Id == {1}", entity.Status, entity.Id);
                context.SaveChanges();
            }
        }
        public static void DeleteOrder(Order entity)
        {
            using (ApplicationDB context = new ApplicationDB())
            {
                if (entity.ShopingItems != null)
                {
                    foreach (var item in entity.ShopingItems)
                    {
                        context.Entry(item.Item).State = EntityState.Unchanged;
                    }
                }

                if (entity.User != null)
                {

                    context.Entry(entity.User).State = EntityState.Unchanged;
                }



                context.Orders.Remove(entity);

                context.SaveChanges();
            }
        }
    }
}
