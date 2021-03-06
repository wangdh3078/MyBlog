﻿using MyBlog.Entities;
using MyBlog.Web.Areas.Admin.Filter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Web.Areas.Admin.Controllers
{
    [Authentication]
    public class BaseController : Controller
    {
        public User CurrentUser
        {
            get
            {
                User user = new User();
                if (Session["user"] != null)
                {
                    user = JsonConvert.DeserializeObject<User>(Session["user"].ToString());
                    return user;
                }
                return user;
            }
        }
    }
}