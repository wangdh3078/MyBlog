﻿using MyBlog.Core;
using System;

namespace MyBlog.Entities
{
    public class User:BaseEntity
    {
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
