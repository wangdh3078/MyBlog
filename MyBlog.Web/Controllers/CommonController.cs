using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Web.Controllers
{
    public class CommonController : Controller
    {
        /// <summary>
        /// 顶部导航
        /// </summary>
        /// <returns></returns>
        public ActionResult Header()
        {
            return View();
        }

        /// <summary>
        /// 右侧侧边栏
        /// </summary>
        /// <returns></returns>
        public ActionResult SideBar()
        {
            return View();
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="file">文件</param>
        /// <returns></returns>
        public JsonResult FileUpload()
        {
            try
            {
                var file = Request.Files[0];
                string localPath = Path.Combine(HttpRuntime.AppDomainAppPath, "FileUpload/" + DateTime.Now.ToString("yyyy-MM-dd"));
                string gkey = Guid.NewGuid().ToString();
                string ex = Path.GetExtension(file.FileName);
                string filePathName = gkey + ex;
                if (!Directory.Exists(localPath))
                {
                    Directory.CreateDirectory(localPath);
                }
                file.SaveAs(Path.Combine(localPath, filePathName));
                string URL = HttpContext.Request.Url.Host+":"+ Request.Url.Port + "/FileUpload/" + filePathName;
                return Json(new { success = 1, message = "上传成功", url = string.Empty });
            }
            catch (Exception ex)
            {
                return Json(new { success = 0, message = ex.Message, url = string.Empty });
            }
        }
    }
}