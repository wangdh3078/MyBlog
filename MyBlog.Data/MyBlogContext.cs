using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public class MyBlogContext : DbContext
    {
        #region 构造函数
        public MyBlogContext()
          : base()
        {

        }
        public MyBlogContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        } 
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
           .Where(type => !string.IsNullOrEmpty(type.Namespace))
           .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
               type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
