using MyBlog.Core;
using MyBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services
{
    public class WeightRecordService
    {
        private readonly IRespository<WeightRecord> _weightRecordRespoistory;
        public WeightRecordService(IRespository<WeightRecord> weightRecordRespoistory)
        {
            _weightRecordRespoistory = weightRecordRespoistory;
        }

        /// <summary>
        /// 添加体重记录
        /// </summary>
        /// <param name="record">记录实体</param>
        /// <returns></returns>
        public WeightRecord Add(WeightRecord record)
        {
            return _weightRecordRespoistory.Add(record);
        }

        /// <summary>
        /// 获取记录列表
        /// </summary>
        /// <param name="express">查询条件</param>
        /// <returns></returns>
        public IList<WeightRecord> GetList(Expression<Func<WeightRecord, bool>> express)
        {
            return _weightRecordRespoistory.GetList(express).ToList();
        }
    }
}
