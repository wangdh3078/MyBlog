﻿using MyBlog.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Mapping
{
    public class ClassifyMap : EntityTypeConfiguration<Classify>
    {
        public ClassifyMap()
        {
            Property(t => t.Name).HasMaxLength(64).IsRequired();
        }
    }
}
