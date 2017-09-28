using Autofac;

namespace MyBlog.Core
{
    public interface IDependencyRegistrar
    {
        /// <summary>
        /// 注册服务和接口
        /// </summary>
        /// <param name="builder"></param>
        void Register(ContainerBuilder builder);

        /// <summary>
        /// 注入实现顺序
        /// </summary>
        int Order { get; }
    }
}
