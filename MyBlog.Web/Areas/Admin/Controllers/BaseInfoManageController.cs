using MyBlog.Core;
using MyBlog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Web.Areas.Admin.Controllers
{
    public class BaseInfoManageController : BaseController
    {
        private readonly UserService _userServices;
        public BaseInfoManageController(UserService userServices)
        {
            _userServices = userServices;
        }
        // GET: Admin/BaseInfoManage
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ModifyPassword(string oldPassword, string newPassword)
        {
            bool success = true;
            string message = string.Empty;
            if (CurrentUser.Password != CryptoHelper.MD5Encrypt(oldPassword))
            {
                success = false;
                message = "旧密码错误！";
            }
            if (success)
            {
                var user = _userServices.GetById(CurrentUser.Id);
                user.Password = CryptoHelper.MD5Encrypt(newPassword);
                success= _userServices.Update(user);
                Session["user"] = null;
                message = "修改成功";
            }
            return Json(new { success = success, message = message });
        }
    }
}