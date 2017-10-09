using MyBlog.Services;
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
        public ActionResult Index()
        {
            return View();
        }
    }
}