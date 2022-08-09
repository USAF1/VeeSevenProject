using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLib.UserManagment
{
    public class UserHandler
    {

        public static List<Users> getUsers()
        {
            using (ApplicationDB context = new ApplicationDB())
            {
                return context.Users.Include(u => u.Role).ToList();
            }
        }


        public static Users getUser(Login entity)
        {
            using (ApplicationDB context = new ApplicationDB())
            {
                return (from User in context.Users.Include(u=>u.Role)
                        where User.Name == entity.Name && User.Password == entity.Password 
                        select User).FirstOrDefault();

                //return context.Users.FromSqlRaw($"select * from Users where Name = {entity.Name} and Password = {entity.Password}").FirstOrDefault();

            }
        }

        public static Users getUser(int id)
        {
            using (ApplicationDB context = new ApplicationDB())
            {
                return (from User in context.Users.Include(u => u.Role)
                        where User.Id == id
                        select User).FirstOrDefault();
            }
        }

        public static Roles getRole(string name)
        {
            using (ApplicationDB context = new ApplicationDB())
            {
                return (from Role in context.Roles where Role.Name == name select Role).FirstOrDefault();
            }
        }

        public static void AddUser(Users entity)
        {
            using (ApplicationDB context = new ApplicationDB())
            {
                if (entity.Role !=null)
                {
                    context.Entry(entity.Role).State = EntityState.Unchanged;
                }
                context.Add(entity);
                context.SaveChanges();
            }
        }

        public static void UpdateUser(Users entity)
        {
            using (ApplicationDB context = new ApplicationDB())
            {
                if (entity.Role != null)
                {
                    context.Entry(entity.Role).State = EntityState.Unchanged;
                }
                context.Update(entity);
                context.SaveChanges();
            }
        }

        public static void DeleteUser(Users entity)
        {
            using (ApplicationDB context = new ApplicationDB())
            {

                if (entity.Role != null)
                {
                    context.Entry(entity.Role).State = EntityState.Unchanged;
                }

                context.Remove(entity);
                context.SaveChanges();
            }

        }

    }    
}
