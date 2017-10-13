using MyBlog.Core;
using MyBlog.Entities;
using MyBlog.Services;
using MyBlog.Web.API.Models;
using MyBlog.Web.Areas.Admin.Models;
using MyBlog.Web.Extensions;
using MyBlog.Web.Helper;
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
        public Paging<APIBlogModel> Get(int pageIndex, int pageSize = 10, string name = "")
        {
            var result = new Paging<APIBlogModel>();
            var blogs = _blogService.GetPagingList(pageSize, pageIndex, t => string.IsNullOrEmpty(name) ? true : t.Title.Contains(name) & t.IsDeleted == false);
            var data = new List<APIBlogModel>();
            foreach (var item in blogs.Rows)
            {
                data.Add(new APIBlogModel
                {
                    Author = item.Author,
                    Context = StringHelper.ReplaceHtmlTag(item.Context, 80),
                    Id = item.Id,
                    PublishedDate = item.PublishedDate,
                    Title = item.Title
                });
            }
            result.Rows = data;
            result.Total = blogs.Total;
            return result;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="categoryId">分类Id</param>
        /// <returns></returns>
        public Paging<APIBlogModel> Get(int pageIndex, int pageSize, int categoryId)
        {
            var result = new Paging<APIBlogModel>();
            var blogs = _blogService.GetPagingList(pageSize, pageIndex, t => t.ClassifyId == categoryId & t.IsDeleted == false);
            var data = new List<APIBlogModel>();
            foreach (var item in blogs.Rows)
            {
                data.Add(new APIBlogModel
                {
                    Author = item.Author,
                    Context = StringHelper.ReplaceHtmlTag(item.Context, 80),
                    Id = item.Id,
                    PublishedDate = item.PublishedDate,
                    Title = item.Title
                });
            }
            result.Rows = data;
            result.Total = blogs.Total;
            return result;
        }
        /// <summary>
        /// 获取博客详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BlogViewModel Get(int id)
        {
            return _blogService.GetById(id).ToModel();
        }
    }
}
