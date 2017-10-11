using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MyBlog.Web.Areas.Admin.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    [Serializable]
    public class TagsViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public TagsViewModel()
        {
            Blogs = new HashSet<BlogViewModel>();
        }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 标签名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 添加人ID
        /// </summary>
        [DataMember]
        public int CreateUserId { get; set; }

        /// <summary>
        /// 是否已经被删除
        /// </summary>
        [DataMember]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 博客集合
        /// </summary>
        [DataMember]
        public virtual ICollection<BlogViewModel> Blogs { get; set; }
    }
}