using MyBlog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entities
{
    /// <summary>
    /// 体重记录
    /// </summary>
    public class WeightRecord: BaseEntity
    {
        /// <summary>
        /// 体重
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 创建用户ID
        /// </summary>
        public int CreateUserId { get; set; }
    }
}
