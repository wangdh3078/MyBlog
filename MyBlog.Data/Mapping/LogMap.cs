using MyBlog.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Mapping
{
    public class LogMap : EntityTypeConfiguration<Log>
    {
        public LogMap()
        {
            Ignore(t => t.LogLevel);
            Property(t => t.Level).HasMaxLength(32);
            Property(t => t.UserName).HasMaxLength(64);
            Property(t => t.OperationType).HasMaxLength(64);
            Property(t => t.IP).HasMaxLength(128);
            Property(t => t.Module).HasMaxLength(128);
        }
    }
}
