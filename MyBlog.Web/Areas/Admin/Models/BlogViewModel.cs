using System;
using System.Collections.Generic;

namespace MyBlog.Web.Areas.Admin.Models
{
    public class BlogViewModel
    {
        public BlogViewModel()
        {
            Tags = new List<TagsViewModel>();
            Classify = new ClassifyViewModel();
        }

        public int Id { get; set; }

        /// <summary>
        /// 博客标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 原始内容（editor.md 编辑器使用）
        /// </summary>
        public string ShortContext { get; set; }

        /// <summary>
        /// 博客内容
        /// </summary>
        public string Context { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public int Author { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? PublishedDate { get; set; }

        /// <summary>
        /// 是否已经发布
        /// </summary>
        public bool IsPublished { get; set; }
        /// <summary>
        /// 标签集合
        /// </summary>
        public List<TagsViewModel> Tags { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public ClassifyViewModel Classify { get; set; }

        /// <summary>
        /// 分类ID
        /// </summary>
        public int ClassifyId { get; set; }
    }


}