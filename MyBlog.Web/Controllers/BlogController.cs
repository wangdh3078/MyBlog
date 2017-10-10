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
    public class BlogController : Controller
    {
        private readonly BlogService _blogService;

        public BlogController(BlogService blogService)
        {
            _blogService = blogService;
        }
        // GET: BlogDetails
        public ActionResult Index(int id)
        {
            var blog = _blogService.GetById(id);
            return View(blog);
        }

        public ActionResult BlogList(List<Blog> list)
        {
            var blogs = new List<Blog>();
            if (list != null)
            {
                blogs = list;
            }
            else
            {
                blogs = _blogService.GetPagingList(10, 1, t => t.IsPublished == true & t.IsDeleted == false).Rows.ToList();
            }
            foreach (var blog in blogs)
            {
                blog.Context = StringHelper.ReplaceHtmlTag(blog.Context);
            }
            return View(blogs);
        }


    }
}