using MyBlog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using System.Reflection;
using Autofac.Integration.Mvc;

namespace MyBlog.Web
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order =>1;

        public void Register(ContainerBuilder builder)
        {
            //注册控制器
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
        }
    }
}