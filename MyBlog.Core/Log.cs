using MyBlog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Core
{
    public class Log : BaseEntity
    {
        public Log(ELogLevel level, string message, string operationType, string module, string ip, int userId, string userName = "")
        {
            Level = level;
            Message = message;
            UserId = userId;
            UserName = userName;
            OperationType = operationType;
            Module = module;
            IP = ip;
        }

        /// <summary>
        /// 日志级别 Trace|Debug|Info|Warn|Error|Fatal 
        /// </summary>
        public ELogLevel Level { get; set; }
        /// <summary>
        /// 日志消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int? UserId { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 操作类型
        /// </summary>
        public string OperationType { get; set; }
        /// <summary>
        /// 操作模块
        /// </summary>
        public string Module { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperationDate { get; set; }
        /// <summary>
        /// IP地址
        /// </summary>
        public string IP { get; set; }
    }
}
