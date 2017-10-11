using MyBlog.Core;
using MyBlog.Entities;
using MyBlog.Services;
using MyBlog.Web.Areas.Admin.Models;
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
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="name">搜索关键字</param>
        /// <returns></returns>
        public Paging<BlogViewModel> Get(int pageIndex, int pageSize = 1, string name = "")
        {
            var result = new Paging<BlogViewModel>();
            var blogs = _blogService.GetPagingList(pageSize, pageIndex, t => string.IsNullOrEmpty(name) ? true : t.Title.Contains(name));
            var data = AutoMapperConfiguration.Mapper.Map<List<Blog>, List<BlogViewModel>>(blogs.Rows.ToList());
            result.Rows = data;
            result.Total = blogs.Total;
            return result;
        }
    }
}
