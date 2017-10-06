using MyBlog.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Web.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserService _userServices;
        public LoginController(UserService userServices)
        {
            _userServices = userServices;
        }
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CheckLogin(string name, string password)
        {
            bool success = false;
            string message = string.Empty;
            var user = _userServices.CheckLogin(name, password);
            if (user != null)
            {
                success = true;
                Session["user"] = JsonConvert.SerializeObject(user);
            }
            else
            {
                message = "用户名或密码错误！";
            }
            return Json(new { success = success, message = message });
        }

        /// <summary>
        /// 退出系统
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOut()
        {
            Session["user"] = null;
            return RedirectToAction("Index");
        }
    }
}