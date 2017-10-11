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
    public class SearchController : Controller
    {
        private readonly BlogService _blogService;

        public SearchController(BlogService blogService)
        {
            _blogService = blogService;
        }
        // GET: Search
        [Operation("搜索内容")]
        public ActionResult Index(string key)
        {
            var blogs = new List<Blog>();
            int count = 0;
            if (!string.IsNullOrEmpty(key))
            {
                var data = _blogService.GetPagingList(10, 1, t => t.IsDeleted == false & t.IsPublished == true & t.Title.Contains(key));
                blogs = data.Rows.ToList();
                count = data.Total;
            }
            else
            {
                var data = _blogService.GetPagingList(10, 1, t => t.IsDeleted == false & t.IsPublished == true);
                blogs = data.Rows.ToList();
                count = data.Total;
            }
            ViewBag.Blogs = blogs;
            ViewBag.Count = count;
            ViewBag.searchKey = key;
            return View();
        }

        public ActionResult GetPaging(string key, int pageIndex, int pageSize)
        {
            var blogs = new List<Blog>();
            if (!string.IsNullOrEmpty(key))
            {
                var data = _blogService.GetPagingList(pageSize, pageIndex, t => t.IsDeleted == false & t.IsPublished == true & t.Title.Contains(key));
                blogs = data.Rows.ToList();
            }
            else
            {
                var data = _blogService.GetPagingList(pageSize, pageIndex, t => t.IsDeleted == false & t.IsPublished == true);
                blogs = data.Rows.ToList();
            }
            foreach (var blog in blogs)
            {
                blog.Context = StringHelper.ReplaceHtmlTag(blog.Context);
            }
            return PartialView(blogs);
        }
    }
}