using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLib.UserManagment;
using VeeSeven.Models;


namespace VeeSeven.Helper
{
    public static class UserHelper
    {

        public static Login ToLoginEntity(this LoginModel model)
        {
            Login entity = new Login();

            entity.Name = model.Name;
            entity.Password = model.Password;
            return entity;
        }

        public static UserModel ToUserModel(this Users entity)
        {
            UserModel model = new UserModel();

            if(entity != null)
            {
                model.Id = entity.Id;
                model.Name = entity.Name;
                model.Password = entity.Password;
                model.Address = entity.Address;
                model.Contact = entity.Contact;
                if (entity.Email != null)
                {
                    model.Email = entity.Email;
                }
                if (entity.Role !=null)
                {
                    model.Role = new Rolemodel() { Id = entity.Role.Id, Name = entity.Role.Name };
                }
                
            }
            else
            {
                model = null;
            }

            return model;
        }

        public static Users ToUserEntity(this UserModel model)
        {
            Users entity = new Users();

            if (model != null)
            {
                entity.Id = model.Id;
                entity.Name = model.Name;
                entity.Password = model.Password;
                entity.Address = model.Address;
                entity.Contact = model.Contact;
                if (model.Email != null)
                {
                    entity.Email = model.Email;
                }
                if(entity.Role != null)
                {
                    entity.Role = new Roles() { Id = model.Role.Id, Name = model.Role.Name };
                }
                
            }
            else
            {
                entity = null;
            }

            return entity;
        }

        public static List<UserModel> ToUserList(this List<Users> entities)
        {
            List<UserModel> models = new List<UserModel>();

            if (entities != null)
            {
                foreach (var user in entities)
                {
                    models.Add(user.ToUserModel());
                }
            }

            return models;
        }

        public static Rolemodel ToRoleModel(this Roles entity)
        {
            Rolemodel model = new Rolemodel();
            if (entity !=null)
            {
                model.Id = entity.Id;
                model.Name = entity.Name;
            }
            return model;
        }

    }
}
