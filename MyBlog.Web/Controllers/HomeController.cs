using MyBlog.Services;
using MyBlog.Web.Areas.Admin.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserService _userService;

        public HomeController(UserService userService)
        {
            _userService = userService;
        }

        [Operation("系统首页")]
        public ActionResult Index()
        {
            return View();
        }
    }
}