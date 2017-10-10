using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MyBlog.Core
{
    /// <summary>
    /// 仓储接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRespository<T> where T : BaseEntity
    {
        #region 新增
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        T Add(T entity);

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="list">实体集合</param>
        /// <returns></returns>
        bool Add(IEnumerable<T> list);
        #endregion

        #region 删除
        /// <summary>
        /// 根据ID删除实体
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        bool Delete(int id);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Delete(T entity);

        /// <summary>
        /// 根据ID集合批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool Delete(IEnumerable<int> ids);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        bool Delete(IEnumerable<T> list);

        /// <summary>
        /// 删除符合条件的数据
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        bool Delete(Expression<Func<T, bool>> express);
        #endregion

        #region 修改
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        T Update(T entity);

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="list">实体集合</param>
        /// <returns></returns>
        bool Update(IEnumerable<T> list);
        #endregion

        #region 查询
        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        T GetById(int id);
        /// <summary>
        /// 查询符合条件的集合
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        IEnumerable<T> GetList(Expression<Func<T, bool>> express);
        /// <summary>
        /// 分页查询数据
        /// </summary>
        /// <param name="pageSize">每页大小</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="express">查询条件</param>
        /// <returns></returns>
        Paging<T> GetPagingList(int pageSize, int pageIndex, Expression<Func<T, bool>> express);

        /// <summary>
        /// 分页查询（指定排序字段和排序方式）
        /// </summary>
        /// <param name="pageSize">每页大小</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="express">查询条件</param>
        /// <param name="sort">排序方式 默认 desc </param>
        /// <returns></returns>
        Paging<T> GetPagingList(int pageSize, int pageIndex, Expression<Func<T, bool>> express, string sort = "desc");

        /// <summary>
        /// 获取表
        /// </summary>
        IQueryable<T> Table { get; }

        /// <summary>
        ///获取启用“无跟踪”的表（EF功能）仅在仅为只读操作加载记录时使用
        /// </summary>
        IQueryable<T> TableNoTracking { get; }
        #endregion

    }
}
