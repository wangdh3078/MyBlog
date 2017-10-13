using MyBlog.Entities;
using MyBlog.Services;
using MyBlog.Web.Areas.Admin.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Web.Areas.Admin.Controllers
{
    /// <summary>
    /// 体重记录
    /// </summary>
    [Authentication]
    public class WeightRecordController : BaseController
    {
        private readonly WeightRecordService _weightRecordService;
        /// <summary>
        /// 
        /// </summary>
        public WeightRecordController(WeightRecordService weightRecordService)
        {
            _weightRecordService = weightRecordService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Add(WeightRecord record)
        {
            try
            {
                record.CreateUserId = CurrentUser.Id;
                record.CreateDate = DateTime.Now;
                record.Date = DateTime.Now;
                _weightRecordService.Add(record);
                return Json(new { success = true, message = "保存成功" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });

            }
        }
    }
}