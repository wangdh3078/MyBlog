using MyBlog.Core;
using MyBlog.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Web.Areas.Admin.Filter
{
    public class OperationAttribute : ActionFilterAttribute
    {
        public OperationAttribute()
        {
            AccessDate = DateTime.Now;
        }
        public OperationAttribute(string summary)
        {
            AccessDate = DateTime.Now;
            OperationSummary = summary;
        }
        /// <summary>
        /// 方法名称
        /// </summary>
        public string ActionName { get; set; }
        /// <summary>
        /// 控制器名称
        /// </summary>
        public string ControllerName { get; set; }
        /// <summary>
        /// 方法参数
        /// </summary>
        public string ActionParameters { get; set; }
        /// <summary>
        /// 访问时间
        /// </summary>
        public DateTime AccessDate { get; set; }
        /// <summary>
        /// 操作简介
        /// </summary>
        public string OperationSummary { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ActionName = filterContext.ActionDescriptor.ActionName;
            ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            IDictionary<string, object> dic = filterContext.ActionParameters;
            System.Text.StringBuilder parameters = new System.Text.StringBuilder();
            foreach (var item in dic)
            {
                parameters.Append(item.Key + "=" + item.Value + "|^|");
            }
            ActionParameters = parameters.ToString();
            //登录用户
            User account = JsonConvert.DeserializeObject<User>(filterContext.HttpContext.Session["user"].ToString());

            string ip = GetCurrentIpAddress();

            LogHelper.Logger.Process(new Log(ELogLevel.Info, OperationSummary, ActionName, ControllerName, ip, account.Id, account.LoginName));
            // LogHelper.Logger.Flush();
        }

        private string GetCurrentIpAddress()
        {
            var result = "";
            var forwardedHttpHeader = "X-FORWARDED-FOR";
            string xff = HttpContext.Current.Request.Headers.AllKeys
                       .Where(x => forwardedHttpHeader.Equals(x, StringComparison.InvariantCultureIgnoreCase))
                       .Select(k => HttpContext.Current.Request.Headers[k])
                       .FirstOrDefault();
            if (!String.IsNullOrEmpty(xff))
            {
                string lastIp = xff.Split(new[] { ',' }).FirstOrDefault();
                result = lastIp;
            }
            if (String.IsNullOrEmpty(result) && HttpContext.Current.Request.UserHostAddress != null)
            {
                result = HttpContext.Current.Request.UserHostAddress;
            }
            if (result == "::1")
            {
                result = "127.0.0.1";
            }
            return result;
        }
    }
}