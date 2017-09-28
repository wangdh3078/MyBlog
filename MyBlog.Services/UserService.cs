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
        private readonly UserRespository _userRespository;

        public UserService()
        {
            _userRespository = new UserRespository();
        }

        public User GetUser()
        {
            return _userRespository.GetUser();
        }
    }
}
