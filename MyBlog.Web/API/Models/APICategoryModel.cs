using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MyBlog.Web.API.Models
{
    /// <summary>
    /// 分类
    /// </summary>
    [DataContract]
    public class APICategoryModel
    {
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}