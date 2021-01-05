using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Function;
using WebApplication1.Models;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            //var cs = Session["customers"];
            //if (cs == null)
            //    return RedirectToAction("LoginForm", "Admin");
            
            return View();
        }
        public ActionResult GetData()
        {
            //var cs = Session["customers"];
            //if (cs == null)
            //    return RedirectToAction("LoginForm", "Admin");
       

            var data = func.getAllCategories();
            return Json(data, JsonRequestBehavior.AllowGet);

        }
        public ActionResult DelCategory(string id)
        {
            var cs = Session["customers"];
            if (cs == null)
                return RedirectToAction("LoginForm", "Admin");
            if (func.delCategory(Convert.ToInt32(id)))
                return Content("success");
            else
                return Content("fail");
        }
        [HttpPost]
        public ActionResult CreateCategory(FormCollection formData)
        {
            var cs = Session["customers"];
            if (cs == null)
                return RedirectToAction("LoginForm", "Admin");
            Category cate = new Category();
            cate.cateDescription = formData["cateDescription"];
            cate.cateName = formData["cateName"];
            cate.catePicture = formData["catePicture"];
            func.createCategory(cate);
            return Content("");
        }
        [HttpPost]
        public ActionResult EditCategory(FormCollection formData)
        {
            var cs = Session["customers"];
            if (cs == null)
                return RedirectToAction("LoginForm", "Admin");
            Category cate = new Category();
            cate.ID=Convert.ToInt32(formData["ID"]);
            cate.cateDescription = formData["cateDescription"];
            cate.cateName = formData["cateName"];
            cate.catePicture = formData["catePicture"];
            if (func.EditCategory(cate))
                return Content("success");
            else
                return Content("fail");
        }
    }
}