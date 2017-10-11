using MyBlog.Core;
using MyBlog.Entities;
using MyBlog.Services;
using MyBlog.Web.Areas.Admin.Filter;
using MyBlog.Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Web.Controllers
{
    public class TagController : Controller
    {
        private readonly TagsService _tagsService;
        private readonly BlogService _blogService;

        public TagController(
            TagsService tagsService,
            BlogService blogService)
        {
            _tagsService = tagsService;
            _blogService = blogService;
        }
        // GET: Tag
        [Operation("查看标签")]
        public ActionResult Index(int? id)
        {
            var tags = new Tags();
            var data = new Paging<Blog>();
            ViewBag.Count = data.Total;
            ViewBag.Blogs = data.Rows.ToList();
            ViewBag.TagName = "没有对应标签";
            if (id.HasValue)
            {
                tags = _tagsService.GetById(id.Value);
                if (tags != null && tags.Blogs.Count > 0)
                {
                    ViewBag.Count = tags.Blogs.Count;
                    ViewBag.Blogs = tags.Blogs.OrderByDescending(t => t.CreateDate).Take(10).ToList();
                    ViewBag.TagName = tags.Name;
                }
            }
            ViewBag.Id = id;
            return View();
        }

        public ActionResult GetPaging(int? id, int pageIndex, int pageSize)
        {
            var blogs = new List<Blog>();
            var data = new Paging<Blog>();
            blogs = data.Rows.ToList();
            if (id.HasValue)
            {
                var tags = _tagsService.GetById(id.Value);
                if (tags != null && tags.Blogs.Count > 0)
                {
                    blogs = tags.Blogs.OrderByDescending(t => t.CreateDate).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList();
                }
            }
            foreach (var blog in blogs)
            {
                blog.Context = StringHelper.ReplaceHtmlTag(blog.Context);
            }
            return PartialView(blogs);
        }
    }
}