using MyBlog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                var u = new UserService().GetUser();
            }
            catch (Exception ex)
            {

            }
            return View();
        }
    }
}