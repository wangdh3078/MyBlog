﻿using MyBlog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace MyBlog.Data
{
    public class Respository<T> : IRespository<T> where T : BaseEntity
    {
        protected readonly MyBlogContext _context;
        protected readonly LogHelper _logger;

        protected IDbSet<T> _entities;

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public Respository(
            MyBlogContext context,
            LogHelper logger)
        {
            _context = context;
            _logger = logger;
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
                _logger.Error(GetFullErrorText(ex));
                return null;
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
                _logger.Error(GetFullErrorText(ex));
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
            try
            {
                var entity = Entities.Find(id);
                Entities.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException ex)
            {
                _logger.Error(GetFullErrorText(ex));
                return false;
            }
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                Entities.Remove(entity);
                _context.SaveChanges();

                return true;
            }
            catch (DbEntityValidationException ex)
            {
                _logger.Error(GetFullErrorText(ex));
                return false;
            }
        }

        /// <summary>
        /// 根据ID集合批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool Delete(IEnumerable<int> ids)
        {
            try
            {
                foreach (var id in ids)
                {
                    Entities.Remove(Entities.Find(id));
                }
                _context.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException ex)
            {
                _logger.Error(GetFullErrorText(ex));
                return false;
            }
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool Delete(IEnumerable<T> list)
        {
            try
            {
                foreach (var entity in list)
                {
                    Entities.Remove(entity);
                }
                _context.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException ex)
            {
                _logger.Error(GetFullErrorText(ex));
                return false;
            }
        }


        /// <summary>
        /// 删除符合条件的数据
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        public bool Delete(Expression<Func<T, bool>> express)
        {
            try
            {
                return Delete(Entities.Where(express));
            }
            catch (DbEntityValidationException ex)
            {
                _logger.Error(GetFullErrorText(ex));
                return false;
            }
        }
        #endregion

        #region 修改
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public bool Update(T entity)
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException ex)
            {
                _logger.Error(GetFullErrorText(ex));
                return false;
            }
        }

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="list">实体集合</param>
        /// <returns></returns>
        public bool Update(IEnumerable<T> list)
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException ex)
            {
                _logger.Error(GetFullErrorText(ex));
                return false;
            }
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
            return Entities.Find(id);
        }

        /// <summary>
        /// 查询符合条件的集合
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        public IEnumerable<T> GetList(Expression<Func<T, bool>> express)
        {
            return Entities.Where(express);
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
            Paging<T> paging = new Paging<T>();
            var entities = Entities.Where(express);
            paging.Total = entities.Count();
            paging.Rows = entities.OrderByDescending(t => t.CreateDate).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return paging;
        }

        /// <summary>
        /// 分页查询（指定排序字段和排序方式）
        /// </summary>
        /// <param name="pageSize">每页大小</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="express">查询条件</param>
        /// <param name="sort">排序方式 默认 desc </param>
        /// <returns></returns>
        public Paging<T> GetPagingList(int pageSize, int pageIndex, Expression<Func<T, bool>> express, string sort = "desc")
        {
            Paging<T> paging = new Paging<T>();
            var entities = Entities.Where(express);
            paging.Total = entities.Count();
            if (sort == "asc")
            {
                paging.Rows = entities.OrderBy(t => t.CreateDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                paging.Rows = entities.OrderByDescending(t => t.CreateDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            paging.Rows = paging.Rows.ToList();
            return paging;
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

        #region 获取整张表
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
        #endregion

        /// <summary>
        /// 获取完整错误
        /// </summary>
        /// <param name="exc">异常对象</param>
        /// <returns></returns>
        protected string GetFullErrorText(DbEntityValidationException exc)
        {
            var msg = string.Empty;
            foreach (var validationErrors in exc.EntityValidationErrors)
                foreach (var error in validationErrors.ValidationErrors)
                    msg += string.Format("属性: {0} 错误信息: {1}", error.PropertyName, error.ErrorMessage) + Environment.NewLine;
            return msg;
        }
    }
}
