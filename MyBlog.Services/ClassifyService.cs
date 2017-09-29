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
    public class ClassifyService
    {
        private readonly IRespository<Classify> _classifyRespoistory;

        public ClassifyService(IRespository<Classify> classifyRespoistory)
        {
            _classifyRespoistory = classifyRespoistory;
        }

        #region 新增
        /// <summary>
        /// 新增分类
        /// </summary>
        /// <param name="classify">实体</param>
        /// <returns></returns>
        public Classify Add(Classify classify)
        {
            return _classifyRespoistory.Add(classify);
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
            return _classifyRespoistory.Delete(id);
        }

        /// <summary>
        /// 根据ID集合批量删除
        /// </summary>
        /// <param name="ids">ID集合</param>
        /// <returns></returns>
        public bool Delete(List<int> ids)
        {
            return _classifyRespoistory.Delete(ids);
        }

        #endregion

        #region 修改
        public Classify Update(Classify classify)
        {
            return _classifyRespoistory.Update(classify);
        }
        #endregion

        #region 查询
        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public Classify GetById(int id)
        {
            return _classifyRespoistory.GetById(id);
        }

        /// <summary>
        /// 查询符合条件的集合
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        public IEnumerable<Classify> GetList(Expression<Func<Classify, bool>> express)
        {
            return _classifyRespoistory.GetList(express);
        }

        /// <summary>
        /// 分页查询数据
        /// </summary>
        /// <param name="pageSize">每页大小</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="express">查询条件</param>
        /// <returns></returns>
        public Paging<Classify> GetPagingList(int pageSize, int pageIndex, Expression<Func<Classify, bool>> express)
        {
            return _classifyRespoistory.GetPagingList(pageSize, pageIndex, express);

        }
        #endregion
    }
}
