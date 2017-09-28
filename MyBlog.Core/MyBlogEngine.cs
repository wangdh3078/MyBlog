using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyBlog.Core
{
    public class MyBlogEngine
    {
        #region 字段
        /// <summary>
        /// 
        /// </summary>
        private static readonly MyBlogEngine _context = new MyBlogEngine();
        /// <summary>
        /// 忽略的程序集
        /// </summary>
        private string assemblySkipLoadingPattern = "^System|^mscorlib|^Microsoft|^AjaxControlToolkit|^Antlr3|^Autofac|^AutoMapper|^Castle|^ComponentArt|^CppCodeProvider|^DotNetOpenAuth|^EntityFramework|^EPPlus|^FluentValidation|^ImageResizer|^itextsharp|^log4net|^MaxMind|^MbUnit|^MiniProfiler|^Mono.Math|^MvcContrib|^Newtonsoft|^NHibernate|^nunit|^Org.Mentalis|^PerlRegex|^QuickGraph|^Recaptcha|^Remotion|^RestSharp|^Rhino|^Telerik|^Iesi|^TestDriven|^TestFu|^UserAgentStringLibrary|^VJSharpCodeProvider|^WebActivator|^WebDev|^WebGrease|^Dapper|^DapperExtensions";
        #endregion
        /// <summary>
        /// 初始化依赖注入
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void Initialize()
        {
            //注册依赖注入
            _context.RegisterDependencies();
        }

        private void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            var baseType = typeof(IDependencyRegistrar);
            var assembies = AppDomain.CurrentDomain.GetAssemblies()
                        .Where(t => !Regex.IsMatch(t.FullName, assemblySkipLoadingPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled));

            var drTypes = assembies.SelectMany(a => a.GetTypes())
                            .Where(p => baseType.IsAssignableFrom(p) && p != baseType)
                            .ToArray();

            var drInstances = new List<IDependencyRegistrar>();
            foreach (var drType in drTypes)
            {
                drInstances.Add((IDependencyRegistrar)Activator.CreateInstance(drType));
            }
            //排序
            drInstances = drInstances.AsQueryable().OrderBy(t => t.Order).ToList();
            foreach (var dependencyRegistrar in drInstances)
            {
                dependencyRegistrar.Register(builder);
            }

            var container = builder.Build();
            //设置依赖解析器
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
