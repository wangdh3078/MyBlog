using MyBlog.Core;
using MyBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services
{
    public class TagsService
    {
        private readonly IRespository<Tags> _tagsRespoistory;

        public TagsService(IRespository<Tags> tagsRespoistory)
        {
            _tagsRespoistory = tagsRespoistory;
        }

        #region 新增
        /// <summary>
        /// 新增标签
        /// </summary>
        /// <param name="tags">实体</param>
        /// <returns></returns>
        public Tags Add(Tags tags)
        {
            return _tagsRespoistory.Add(tags);
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
            return _tagsRespoistory.Delete(id);
        }

        /// <summary>
        /// 根据ID集合批量删除
        /// </summary>
        /// <param name="ids">ID集合</param>
        /// <returns></returns>
        public bool Delete(List<int> ids)
        {
            return _tagsRespoistory.Delete(ids);
        }

        #endregion

        #region 修改
        public Tags Update(Tags tags)
        {
            return _tagsRespoistory.Update(tags);
        }
        #endregion

        #region 查询
        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public Tags GetById(int id)
        {
            return _tagsRespoistory.GetById(id);
        }

        /// <summary>
        /// 查询符合条件的集合
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        public IEnumerable<Tags> GetList(Expression<Func<Tags, bool>> express)
        {
            return _tagsRespoistory.GetList(express);
        }

        /// <summary>
        /// 分页查询数据
        /// </summary>
        /// <param name="pageSize">每页大小</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="express">查询条件</param>
        /// <returns></returns>
        public Paging<Tags> GetPagingList(int pageSize, int pageIndex, Expression<Func<Tags, bool>> express)
        {
            return _tagsRespoistory.GetPagingList(pageSize, pageIndex, express);

        }
        #endregion
    }
}
