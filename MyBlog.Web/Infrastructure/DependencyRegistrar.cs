using MyBlog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using System.Reflection;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;

namespace MyBlog.Web
{
    /// <summary>
    /// 依赖注入
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// 注入排序
        /// </summary>
        public int Order =>1;

        /// <summary>
        /// 注入
        /// </summary>
        /// <param name="builder"></param>
        public void Register(ContainerBuilder builder)
        {
            //注册控制器
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            //注册API
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
        }
    }
}