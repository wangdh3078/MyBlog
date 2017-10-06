using MyBlog.Entities;
using MyBlog.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Web.Areas.Admin.Controllers
{
    public class ClassifiedManageController : BaseController
    {
        private readonly ClassifyService _classifyService;
        private readonly BlogService _blogService;

        public ClassifiedManageController(
            ClassifyService classifyService,
            BlogService blogService)
        {
            _classifyService = classifyService;
            _blogService = blogService;
        }

        /// <summary>
        /// 分类列表页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 分页获取分类列表数据
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetPagingData(int pageSize, int pageNumber, string name)
        {
            var data = _classifyService.GetPagingList(pageSize, pageNumber, t => (string.IsNullOrEmpty(name) ? true : t.Name.Contains(name)) & t.IsDeleted == false);
            JsonSerializerSettings setting = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.None
            };
            var ret = JsonConvert.SerializeObject(new { total = data.Total, rows = data.Rows }, setting);
            return ret;
        }

        #region 添加或编辑分类
        /// <summary>
        /// 添加或编辑分类
        /// </summary>
        /// <param name="id">分类ID</param>
        /// <returns></returns>
        public ActionResult AddOrEdit(int? id)
        {
            Classify classify = new Classify();
            if (id.HasValue)
            {
                classify = _classifyService.GetById(id.Value);
            }
            return View(classify);
        }

        [HttpPost]
        public JsonResult AddOrEdit(Classify entity)
        {
            bool success = false;
            string message = string.Empty;
            try
            {
                var classfiy = _classifyService.GetList(t => t.Name == entity.Name & t.IsDeleted == false).FirstOrDefault();

                if (entity.Id != 0)
                {
                    var temp = _classifyService.GetById(entity.Id);
                    temp.Name = entity.Name;
                    if (classfiy != null && classfiy.Id != entity.Id)
                    {
                        message = "分类已经存在";
                    }
                    else
                    {
                        _classifyService.Update(temp);
                        success = true;
                        message = "保存成功";
                    }
                }
                else
                {
                    if (classfiy != null)
                    {
                        message = "分类已经存在";
                    }
                    else
                    {
                        entity.CreateDate = DateTime.Now;
                        entity.CreateUserId = CurrentUser.Id;
                        _classifyService.Add(entity);
                        success = true;
                        message = "保存成功";
                    }
                }
                return Json(new { success = success, message = message });
            }
            catch (Exception ex)
            {
                return Json(new { success = success, message = ex.Message });
            }
        }
        #endregion

        #region 删除
        public JsonResult Delete(List<int> ids)
        {
            bool success = false;
            var blogs = _blogService.GetList(t => ids.Contains(t.Classify.Id));
            if (blogs.Count() > 0)
            {
                return Json(new { success = success });
            }
            else
            {
                success = _classifyService.Delete(ids);
                return Json(new { success = success });
            }
        }
        #endregion
    }
}