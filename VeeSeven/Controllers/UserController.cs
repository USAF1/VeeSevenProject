using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeeSeven.Models;
using EntityLib.UserManagment;
using VeeSeven.Helper;
using Microsoft.AspNetCore.Http;
using VeeSeven.Extras;

namespace VeeSeven.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            UserModel user = UserHandler.getUser(model.ToLoginEntity()).ToUserModel();
            HttpContext.Session.Set(Constants.Key, user);

            if (user != null)
            {
                if (user.Role !=null && user.Role.Name == "Admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
                
            }
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult AdminUserMan()
        {
            ViewData["Users"] = UserHandler.getUsers().ToUserList();
            return View();
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(UserModel model)
        {
            Rolemodel Role = UserHandler.getRole(model.Role.Name).ToRoleModel();

            model.Role = Role;

            UserHandler.AddUser(model.ToUserEntity());

            return RedirectToAction("AdminUserMan");
        }

        [HttpGet]
        public IActionResult UpdateUser(int id)
        {
            UserModel model = UserHandler.getUser(id).ToUserModel();

            return View(model);
        }


        [HttpPost]
        public IActionResult UpdateUser(UserModel model)
        {
            Rolemodel Role = UserHandler.getRole(model.Role.Name).ToRoleModel();

            model.Role = Role;

            UserHandler.UpdateUser(model.ToUserEntity());

            return RedirectToAction("AdminUserMan");
        }

        [HttpGet]
        public IActionResult DeleteUser(int id)
        {
            UserModel model = UserHandler.getUser(id).ToUserModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteUser(UserModel model)
        {
            UserModel user = UserHandler.getUser(model.Id).ToUserModel();

            UserHandler.DeleteUser(user.ToUserEntity());

            return RedirectToAction("AdminUserMan");
        }
    }
}
