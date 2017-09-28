using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Web.Areas.Admin.Controllers
{
    public class CommonController : BaseController
    {
        // GET: Admin/Common
        public ActionResult AdminHeader()
        {
            return View();
        }

        public ActionResult AdminNav()
        {
            return View();
        }
    }
}