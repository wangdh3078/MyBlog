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
    public class UserService
    {
        private readonly IRespository<User> _userRespository;

        #region 构造函数
        public UserService(IRespository<User> userRespository)
        {
            _userRespository = userRespository;
        }
        #endregion

        #region 新增
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="user">实体</param>
        /// <returns></returns>
        public User Add(User user)
        {
            return _userRespository.Add(user);
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
            return _userRespository.Delete(id);
        }

        /// <summary>
        /// 根据ID集合批量删除
        /// </summary>
        /// <param name="ids">ID集合</param>
        /// <returns></returns>
        public bool Delete(List<int> ids)
        {
            return _userRespository.Delete(ids);
        }

        #endregion

        #region 修改
        public User Update(User user)
        {
            return _userRespository.Update(user);
        }
        #endregion

        #region 查询
        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public User GetById(int id)
        {
            return _userRespository.GetById(id);
        }

        /// <summary>
        /// 查询符合条件的集合
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        public IEnumerable<User> GetList(Expression<Func<User, bool>> express)
        {
            return _userRespository.GetList(express);
        }

        /// <summary>
        /// 分页查询数据
        /// </summary>
        /// <param name="pageSize">每页大小</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="express">查询条件</param>
        /// <returns></returns>
        public Paging<User> GetPagingList(int pageSize, int pageIndex, Expression<Func<User, bool>> express)
        {
            return _userRespository.GetPagingList(pageSize, pageIndex, express);

        }
        #endregion

        #region 用户登录
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public User CheckLogin(string name, string password)
        {
            password = CryptoHelper.MD5Encrypt(password);
            User user = new User();
            user = _userRespository.GetList(t => t.LoginName == name
                                            & t.Password == password
                                            & t.IsDisabled == false).FirstOrDefault();
            return user;
        }
        #endregion
    }
}
