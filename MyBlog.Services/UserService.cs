using MyBlog.Core;
using MyBlog.Data;
using MyBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public User GetUser()
        {
            return _userRespository.GetById(0);
        }
    }
}
