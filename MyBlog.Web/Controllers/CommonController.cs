﻿using MyBlog.Services;
using MyBlog.Web.Areas.Admin.Filter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Web.Controllers
{
    public class CommonController : Controller
    {
        private readonly TagsService _tagsService;
        private readonly ClassifyService _classifyService;
        private readonly BlogService _blogService;

        public CommonController(
            TagsService tagsService,
            ClassifyService classifyService,
            BlogService blogService)
        {
            _tagsService = tagsService;
            _classifyService = classifyService;
            _blogService = blogService;
        }
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
            var tags = _tagsService.GetList(t => t.IsDeleted == false).ToList();
            var classifies = _classifyService.GetList(t => t.IsDeleted == false).ToList();
            ViewBag.Tags = tags;
            ViewBag.Classifies = classifies;
            return View();
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="file">文件</param>
        /// <returns></returns>
        [Operation("上传文件")]
        public JsonResult FileUpload()
        {
            try
            {
                var file = Request.Files[0];
                string localPath = Path.Combine(HttpRuntime.AppDomainAppPath, "FileUpload/" + DateTime.Now.ToString("yyyy-MM-dd"));
                string gkey = Guid.NewGuid().ToString();
                string ex = Path.GetExtension(file.FileName);
                string filePathName = gkey + ex;
                if (!Directory.Exists(localPath))
                {
                    Directory.CreateDirectory(localPath);
                }
                file.SaveAs(Path.Combine(localPath, filePathName));
#if DEBUG
                string URL = "http://" + HttpContext.Request.Url.Host + ":" + Request.Url.Port + "/FileUpload/" + DateTime.Now.ToString("yyyy-MM-dd") + "/" + filePathName;
#else
                string URL = "https://" + HttpContext.Request.Url.Host + "/FileUpload/" + DateTime.Now.ToString("yyyy-MM-dd") + "/" + filePathName;
#endif
                return Json(new { success = 1, message = "上传成功", url = URL });
            }
            catch (Exception ex)
            {
                return Json(new { success = 0, message = ex.Message, url = string.Empty });
            }
        }
    }
}