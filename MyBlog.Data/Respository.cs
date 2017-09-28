using MyBlog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace MyBlog.Data
{
    public class Respository<T> : IRespository<T> where T : BaseEntity
    {
        private readonly MyBlogContext _context;

        private IDbSet<T> _entities;


        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public Respository()
        {
            _context = new MyBlogContext();
        }
        #endregion

        #region 新增
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public T Add(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                Entities.Add(entity);
                _context.SaveChanges();
                return entity;
            }
            catch (DbEntityValidationException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="list">实体集合</param>
        /// <returns></returns>
        public bool Add(IEnumerable<T> list)
        {
            try
            {
                if (list == null)
                {
                    throw new ArgumentNullException("list");
                }

                foreach (var entity in list)
                {
                    Entities.Add(entity);
                }
                _context.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException ex)
            {
                return false;
            }
        }
        #endregion

        #region 删除
        /// <summary>
        /// 根据ID删除实体
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(T entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据ID集合批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool Delete(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool Delete(IEnumerable<T> list)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 删除符合条件的数据
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        public bool Delete(Expression<Func<T, bool>> express)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 修改
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public T Update(T entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="list">实体集合</param>
        /// <returns></returns>
        public bool Update(IEnumerable<T> list)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 查询
        /// <summary>
        /// 根据ID获取实体
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 查询符合条件的集合
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        public IEnumerable<T> GetList(Expression<Func<T, bool>> express)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 分页查询数据
        /// </summary>
        /// <param name="pageSize">每页大小</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="express">查询条件</param>
        /// <returns></returns>
        public Paging<T> GetPagingList(int pageSize, int pageIndex, Expression<Func<T, bool>> express)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 分页查询（指定排序字段和排序方式）
        /// </summary>
        /// <param name="pageSize">每页大小</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="express">查询条件</param>
        /// <param name="sort">排序方式 默认 desc </param>
        /// <param name="sortColumn">排序字段 默认  CreateDate</param>
        /// <returns></returns>
        public Paging<T> GetPagingList(int pageSize, int pageIndex, Expression<Func<T, bool>> express, string sort = "desc", string sortColumn = "CreateDate")
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取表
        /// </summary>
        public IQueryable<T> Table => this.Entities;

        /// <summary>
        /// 获取启用“无跟踪”的表（EF功能）仅在仅为只读操作加载记录时使用
        /// </summary>
        public IQueryable<T> TableNoTracking => this.Entities.AsNoTracking();

        #endregion

        /// <summary>
        /// 获取整张表
        /// </summary>
        protected virtual IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }

    }
}
