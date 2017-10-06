using MyBlog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Web.Areas.Admin.Controllers
{
    public class ClassifiedManageController : BaseController
    {
        private readonly ClassifyService _classifyService;

        public ClassifiedManageController(ClassifyService classifyService)
        {
            _classifyService = classifyService;
        }

        /// <summary>
        /// 分类列表页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 分页获取分类列表数据
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public JsonResult GetPagingData(int pageSize, int pageNumber, string name)
        {
            var data = _classifyService.GetPagingList(pageSize, pageNumber, t => (string.IsNullOrEmpty(name) ? true : t.Name.Contains(name)) & t.IsDeleted == false);
            return Json(new { total = data.Total, rows = data.Rows }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 添加或编辑分类
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <returns></returns>
        public ActionResult AddOrEdit(int? id)
        {
            return View();
        }
    }
}