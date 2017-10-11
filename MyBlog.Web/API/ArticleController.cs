using MyBlog.Entities;
using MyBlog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyBlog.Web.API
{
    /// <summary>
    /// 文章管理
    /// </summary>
    public class ArticleController : ApiController
    {
        private readonly BlogService _blogService;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ArticleController(BlogService blogService)
        {
            _blogService = blogService;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Blog> Get()
        {
            return _blogService.GetList(t => true).ToList();
        }
    }
}
