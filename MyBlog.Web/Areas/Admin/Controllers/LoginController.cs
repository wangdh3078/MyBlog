using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Web.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CheckLogin(string name, string password)
        {
            bool success = true;
            string message = string.Empty;
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