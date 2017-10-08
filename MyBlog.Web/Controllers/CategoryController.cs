using MyBlog.Services;
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
        public ActionResult Index(int id)
        {
            ViewBag.CategoryName = _classifyService.GetById(id).Name;
            var blogs = _blogService.GetList(t => t.IsDeleted == false & t.IsPublished == true & t.ClassifyId == id).ToList();
            return View();
        }
    }
}