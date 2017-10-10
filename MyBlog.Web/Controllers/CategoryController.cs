using MyBlog.Core;
using MyBlog.Entities;
using MyBlog.Services;
using MyBlog.Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ClassifyService _classifyService;
        private readonly BlogService _blogService;

        public CategoryController(
            ClassifyService classifyService,
            BlogService blogService)
        {
            _classifyService = classifyService;
            _blogService = blogService;
        }
        // GET: Category
        public ActionResult Index(int? id)
        {
            var blogs = new List<Blog>();
            ViewBag.CategoryName = "没有对应的分类";
            var data = new Paging<Blog>(); 
            blogs = data.Rows.ToList();
            ViewBag.Count = data.Total;

            if (id.HasValue)
            {
                var category = _classifyService.GetById(id.Value);
                if (category != null)
                {
                    ViewBag.CategoryName = _classifyService.GetById(id.Value).Name;
                    data = _blogService.GetPagingList(10, 1, t => t.IsDeleted == false & t.IsPublished == true & t.ClassifyId == id);
                    blogs = data.Rows.ToList();
                    ViewBag.Count = data.Total;
                }

            }

            ViewBag.Blogs = blogs;
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
                var category = _classifyService.GetById(id.Value);
                if (category != null)
                {
                    data = _blogService.GetPagingList(pageSize, pageIndex, t => t.IsDeleted == false & t.IsPublished == true & t.ClassifyId == id);
                    blogs = data.Rows.ToList();
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