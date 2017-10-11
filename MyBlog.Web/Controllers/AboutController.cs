using MyBlog.Web.Areas.Admin.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Web.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        [Operation("关于本站")]
        public ActionResult Index()
        {
            return View();
        }
    }
}