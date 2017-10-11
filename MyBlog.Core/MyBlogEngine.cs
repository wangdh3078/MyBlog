using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using AutoMapper;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Web.Http;
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
            _context.RegisterMapperConfiguration();
        }

        #region 依赖注入
        private void RegisterDependencies()
        {
            AppDomain.CurrentDomain.Load("MyBlog.Services");

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
            builder.RegisterType<Logger>().As<Logger>().InstancePerLifetimeScope();
            var container = builder.Build();

            //设置API解析
            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);
            builder.RegisterWebApiModelBinderProvider();
            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;
            //设置依赖解析器
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
        #endregion

        #region 注册映射配置
        /// <summary>
        /// 注册映射配置
        /// </summary>
        protected virtual void RegisterMapperConfiguration()
        {

            var baseType = typeof(IMapperConfiguration);
            var assembies = AppDomain.CurrentDomain.GetAssemblies()
                    .Where(t => !Regex.IsMatch(t.FullName, assemblySkipLoadingPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled));
            var mcTypes = assembies.SelectMany(a => a.GetTypes())
                           .Where(p => baseType.IsAssignableFrom(p) && p != baseType)
                           .ToArray();
            var mcInstances = new List<IMapperConfiguration>();
            foreach (var mcType in mcTypes)
                mcInstances.Add((IMapperConfiguration)Activator.CreateInstance(mcType));
            //sort
            mcInstances = mcInstances.AsQueryable().OrderBy(t => t.Order).ToList();
            //get configurations
            var configurationActions = new List<Action<IMapperConfigurationExpression>>();
            foreach (var mc in mcInstances)
                configurationActions.Add(mc.GetConfiguration());
            //register
            AutoMapperConfiguration.Init(configurationActions);
        }
        #endregion
    }
}
