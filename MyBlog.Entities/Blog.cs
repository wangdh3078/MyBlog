using MyBlog.Core;
using System;
using System.Collections.Generic;

namespace MyBlog.Entities
{
    /// <summary>
    /// 博客实体
    /// </summary>
    public class Blog : BaseEntity
    {
        public Blog()
        {
            Tags = new HashSet<Tags>();
        }
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
        /// 添加人ID
        /// </summary>
        public int CreateUserId { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? PublishedDate { get; set; }

        /// <summary>
        /// 是否已经删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 是否已经发布
        /// </summary>
        public bool IsPublished { get; set; }

        /// <summary>
        /// 标签集合
        /// </summary>
        public virtual ICollection<Tags> Tags { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public virtual Classify Classify { get; set; }
        /// <summary>
        /// 分类ID
        /// </summary>
        public int ClassifyId { get; set; }
    }
}
