using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Web.Areas.Admin.Models
{
    public class TagsViewModel
    {
        public TagsViewModel()
        {
            Blogs = new HashSet<BlogViewModel>();
        }

        public int Id { get; set; }

        /// <summary>
        /// 标签名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 添加人ID
        /// </summary>
        public int CreateUserId { get; set; }

        /// <summary>
        /// 是否已经被删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 博客集合
        /// </summary>
        public virtual ICollection<BlogViewModel> Blogs { get; set; }
    }
}