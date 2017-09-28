using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Web.Controllers
{
    public class CommonController : Controller
    {
        /// <summary>
        /// 顶部导航
        /// </summary>
        /// <returns></returns>
        public ActionResult Header()
        {
            return View();
        }

        /// <summary>
        /// 右侧侧边栏
        /// </summary>
        /// <returns></returns>
        public ActionResult SideBar()
        {
            return View();
        }
    }
}