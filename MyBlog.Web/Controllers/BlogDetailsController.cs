﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Web.Controllers
{
    public class BlogDetailsController : Controller
    {
        // GET: BlogDetails
        public ActionResult Index()
        {
            return View();
        }
    }
}