using MyBlog.Core;
using System;
using System.Collections.Generic;

namespace MyBlog.Entities
{
    /// <summary>
    /// 文章分类
    /// </summary>
    public class Classify : BaseEntity
    {
        public Classify()
        {
            Blogs = new HashSet<Blog>();
        }

        /// <summary>
        /// 分类名称
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
        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
