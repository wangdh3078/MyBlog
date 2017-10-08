using MyBlog.Services;
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
        public TagController(TagsService tagsService)
        {
            _tagsService = tagsService;
        }
        // GET: Tag
        public ActionResult Index(int id)
        {
            var tags = _tagsService.GetById(id);
            ViewBag.TagName = tags.Name;
            return View();
        }
    }
}