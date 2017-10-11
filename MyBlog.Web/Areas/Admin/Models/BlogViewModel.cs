using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MyBlog.Web.Areas.Admin.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    [Serializable]
    public class BlogViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public BlogViewModel()
        {
            Tags = new List<TagsViewModel>();
            Classify = new ClassifyViewModel();
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 博客标题
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// 原始内容（editor.md 编辑器使用）
        /// </summary>
        [DataMember]
        public string ShortContext { get; set; }

        /// <summary>
        /// 博客内容
        /// </summary>
        [DataMember]
        public string Context { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        [DataMember]
        public int Author { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        [DataMember]
        public DateTime? PublishedDate { get; set; }

        /// <summary>
        /// 是否已经发布
        /// </summary>
        [DataMember]
        public bool IsPublished { get; set; }
        /// <summary>
        /// 标签集合
        /// </summary>
        [DataMember]
        public List<TagsViewModel> Tags { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        [DataMember]
        public ClassifyViewModel Classify { get; set; }

        /// <summary>
        /// 分类ID
        /// </summary>
        [DataMember]
        public int ClassifyId { get; set; }
    }


}