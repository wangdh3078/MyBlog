using MyBlog.Entities;
using MyBlog.Services;
using MyBlog.Web.Areas.Admin.Models;
using MyBlog.Web.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGrease.Css.Extensions;

namespace MyBlog.Web.Areas.Admin.Controllers
{
    public class ArticleManageController : BaseController
    {
        private readonly BlogService _blogService;
        private readonly ClassifyService _classifyService;
        private readonly TagsService _tagsService;

        public ArticleManageController(
            BlogService blogService,
            ClassifyService classifyService,
            TagsService tagsService)
        {
            _blogService = blogService;
            _classifyService = classifyService;
            _tagsService = tagsService;
        }
        // GET: Admin/ArticleManage
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 新增或编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult AddOrEditArticle(int? id)
        {
            BlogViewModel model = new BlogViewModel();
            if (id.HasValue)
            {
                var entity = _blogService.GetById(id.Value);
                model = entity.ToModel();
            }
            ViewBag.Tags = _tagsService.GetList(t => t.IsDeleted == false);
            ViewBag.Classify = _classifyService.GetList(t => t.IsDeleted == false);
            return View(model);
        }
        /// <summary>
        /// 添加或编辑
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public JsonResult AddOrEditArticle(BlogViewModel blog)
        {
            Blog entity = new Blog();
            try
            {
                if (blog.Id != 0)
                {
                    entity = _blogService.GetById(blog.Id);
                }
                entity = blog.ToEntity(entity);
                if (entity.IsPublished)
                {
                    entity.PublishedDate = DateTime.Now;
                }
                var tagsIds = entity.Tags.Select(t => t.Id).ToList();
                entity.Tags = _tagsService.GetList(t => tagsIds.Contains(t.Id)).ToList();

                if (blog.Id != 0)
                {
                    _blogService.Update(entity);
                }
                else
                {
                    entity.CreateDate = DateTime.Now;
                    entity.Author = 1;
                    _blogService.Add(entity);
                }
                return Json(new { success = true, message = "保存成功" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}