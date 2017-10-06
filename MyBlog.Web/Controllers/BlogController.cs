using MyBlog.Services;
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

        public ActionResult BlogList()
        {
            var blogs = _blogService.GetPagingList(10, 1, t => t.IsPublished == true & t.IsDeleted == false).Rows.ToList();
            foreach (var blog in blogs)
            {
                blog.Context = ReplaceHtmlTag(blog.Context);
            }
            return View(blogs);
        }

        public static string ReplaceHtmlTag(string html, int length = 0)
        {
            string strText = System.Text.RegularExpressions.Regex.Replace(html, "<[^>]+>", "");
            strText = System.Text.RegularExpressions.Regex.Replace(strText, "&[^;]+;", "");

            if (length > 0 && strText.Length > length)
                return strText.Substring(0, length);

            return strText;
        }
    }
}