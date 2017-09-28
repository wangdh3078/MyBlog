using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Web.Areas.Admin.Controllers
{
    public class ArticleManageController : BaseController
    {
        // GET: Admin/ArticleManage
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 新增或编辑文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult AddOrEditArticle(int? id)
        {
            return View();
        }
    }
}