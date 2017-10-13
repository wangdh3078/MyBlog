using MyBlog.Services;
using MyBlog.Web.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyBlog.Web.API
{
    /// <summary>
    /// 分类API
    /// </summary>
    public class CategoryController : ApiController
    {
        private readonly ClassifyService _classifyService;
        /// <summary>
        /// 构造函数
        /// </summary>
        public CategoryController(ClassifyService classifyService)
        {
            _classifyService = classifyService;
        }
        /// <summary>
        /// 获取分类集合
        /// </summary>
        /// <returns></returns>
        public IEnumerable<APICategoryModel> Get()
        {
            var data = new List<APICategoryModel>();
            var list = _classifyService.GetList(t => t.IsDeleted == false);
            foreach (var item in list)
            {
                data.Add(new APICategoryModel
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }
            return data;
        }
    }
}