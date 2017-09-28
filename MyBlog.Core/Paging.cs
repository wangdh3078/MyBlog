using System.Collections.Generic;

namespace MyBlog.Core
{
    /// <summary>
    /// 分页查询返回结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Paging<T> where T : class
    {
        public Paging()
        {
            Row = new List<T>();
        }

        /// <summary>
        /// 条数
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// 数据集合
        /// </summary>
        public IEnumerable<T> Row { get; set; }
    }
}
