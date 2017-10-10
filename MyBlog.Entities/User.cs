using MyBlog.Core;
using System;

namespace MyBlog.Entities
{
    public class User : BaseEntity
    {
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 是否被禁用
        /// </summary>
        public bool IsDisabled { get; set; }
    }
}
