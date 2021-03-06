﻿using MyBlog.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Mapping
{
    public class BlogMap : EntityTypeConfiguration<Blog>
    {
        public BlogMap()
        {
            Property(t => t.Title).HasMaxLength(100).IsRequired();


            //设置多对多的关系 .Map()配置用于存储关系的外键列和表。
            /*
             Blog  HasMany此实体类型配置一对多关系。对应对应Orders实体实体               
             WithMany   将关系配置为 many:many，且在关系的另一端有导航属性。
             * MapLeftKey 配置左外键的列名。左外键指向在 HasMany 调用中指定的导航属性的父实体。
             * MapRightKey 配置右外键的列名。右外键指向在 WithMany 调用中指定的导航属性的父实体。
             */

            HasMany(t => t.Tags)
                  .WithMany(t => t.Blogs)
                  .Map(m => m.ToTable("BlogTags")
                  .MapLeftKey("BlogId")
                  .MapRightKey("TagId"));

            HasRequired(t => t.Classify)
                .WithMany(c => c.Blogs)
                .HasForeignKey(t => t.ClassifyId)
                .WillCascadeOnDelete(false);
        }
    }
}
