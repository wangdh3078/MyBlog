using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Web.Areas.Admin.Controllers
{
    public class ParameterSettingController : BaseController
    {
        // GET: Admin/ParameterSetting
        public ActionResult Index()
        {
            return View();
        }
    }
}