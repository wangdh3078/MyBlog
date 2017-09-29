using Autofac;
using MyBlog.Core;
using MyBlog.Data;

namespace MyBlog.Services
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order => 1;

        public void Register(ContainerBuilder builder)
        {
            //注册数据库上下文
            builder.Register(t => new MyBlogContext("MyBlogContext")).InstancePerLifetimeScope();
            //注册日志
            builder.RegisterType<Logger>().As<Logger>().InstancePerLifetimeScope();
            //注册仓储
            builder.RegisterGeneric(typeof(Respository<>)).As(typeof(IRespository<>)).InstancePerLifetimeScope();

            //注册用户服务
            builder.RegisterType<UserService>().InstancePerDependency();

            //注册博客服务
            builder.RegisterType<BlogService>().InstancePerDependency();

            //注册标签服务
            builder.RegisterType<TagsService>().InstancePerDependency();

            //注册分类服务
            builder.RegisterType<ClassifyService>().InstancePerDependency();
        }
    }
}
