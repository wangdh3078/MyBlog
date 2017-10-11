using System;
using System.Runtime.Serialization;

namespace MyBlog.Web.API.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class APIBlogModel
    {
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 博客标题
        /// </summary>
        [DataMember]
        public string Title { get; set; }

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
        /// 发布时间
        /// </summary>
        [DataMember]
        public DateTime? PublishedDate { get; set; }
    }
}