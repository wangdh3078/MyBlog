﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Web.Areas.Admin.Controllers
{
    public class ClassifiedManageController : BaseController
    {
        // GET: Admin/ClassifiedManage
        public ActionResult Index()
        {
            return View();
        }
    }
}