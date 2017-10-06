using MyBlog.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {

            Property(t => t.LoginName).HasMaxLength(64).IsRequired();
            Property(t => t.NickName).HasMaxLength(64);
            Property(t => t.Password).HasMaxLength(256).IsRequired();
            Property(t => t.Email).HasMaxLength(128);
        }
    }
}
