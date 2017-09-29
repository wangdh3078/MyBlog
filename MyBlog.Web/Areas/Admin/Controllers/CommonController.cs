using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Web.Areas.Admin.Controllers
{
    public class CommonController : BaseController
    {
        /// <summary>
        /// 顶部
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminHeader()
        {
            return View();
        }

        /// <summary>
        /// 左侧导航
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminNav()
        {
            return View();
        }

        /// <summary>
        /// 生成单选下拉框
        /// </summary>
        /// <param name="id">控件ID</param>
        /// <param name="source">数据源</param>
        /// <param name="value">选项值字段</param>
        /// <param name="text">显示文本字段</param>
        /// <param name="@class">class</param>
        /// <param name="isMulti">是否多选</param>
        /// <returns></returns>
        public ActionResult CreateSelect(string id, IEnumerable<dynamic> source, string value, string text, string @class, string selectedValue, bool isMulti = false)
        {
            var selectItemList = new List<SelectListItem>();
            if (!isMulti)
            {
                selectItemList.Add(new SelectListItem { Value = "0", Text = "-请选择-", Selected = true });
            }
            var selectList = new SelectList(source, value, text);
            ViewBag.Id = id;
            ViewBag.SelectedValue = selectedValue;
            selectItemList.AddRange(selectList);
            ViewBag.Source = selectItemList;
            ViewBag.Class = @class;
            ViewBag.IsMulti = isMulti;
            return PartialView();
        }
    }
}