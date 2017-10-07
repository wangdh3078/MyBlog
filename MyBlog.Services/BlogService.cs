using MyBlog.Core;
using MyBlog.Data;
using MyBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services
{
    public class BlogService
    {
        private readonly IRespository<Blog> _blogRespoistory;

        public BlogService(IRespository<Blog> blogRespoistory)
        {
            _blogRespoistory = blogRespoistory;
        }

        #region 新增
        /// <summary>
        /// 新增博客
        /// </summary>
        /// <param name="blog">实体</param>
        /// <returns></returns>
        public Blog Add(Blog blog)
        {
            return _blogRespoistory.Add(blog);
        }

        #endregion

        #region 删除
        /// <summary>
        /// 根据ID删除
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return _blogRespoistory.Delete(id);
        }

        /// <summary>
        /// 根据ID集合批量删除
        /// </summary>
        /// <param name="ids">ID集合</param>
        /// <returns></returns>
        public bool Delete(List<int> ids)
        {
            return _blogRespoistory.Delete(ids);
        }

        #endregion

        #region 修改
        public Blog Update(Blog blog)
        {
            return _blogRespoistory.Update(blog);
        }
        #endregion

        #region 查询
        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public Blog GetById(int id)
        {
            return _blogRespoistory.GetById(id);
        }

        /// <summary>
        /// 查询符合条件的集合
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        public IEnumerable<Blog> GetList(Expression<Func<Blog, bool>> express)
        {
            return _blogRespoistory.GetList(express);
        }

        /// <summary>
        /// 分页查询数据
        /// </summary>
        /// <param name="pageSize">每页大小</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="express">查询条件</param>
        /// <returns></returns>
        public Paging<Blog> GetPagingList(int pageSize, int pageIndex, Expression<Func<Blog, bool>> express)
        {
            return _blogRespoistory.GetPagingList(pageSize, pageIndex, express);

        }
        #endregion
    }
}
