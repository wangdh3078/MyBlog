using MyBlog.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Data.Mapping
{
    public class WeightRecordMap : EntityTypeConfiguration<WeightRecord>
    {
        public WeightRecordMap()
        {
            Property(t => t.Weight).HasPrecision(18, 2);
        }
    }
}
