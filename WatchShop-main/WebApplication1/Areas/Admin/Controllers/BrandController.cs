using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Function;
using WebApplication1.Models;

namespace WebApplication1.Areas.Admin.Controllers
{
    
    public class BrandController : Controller
    {
        // GET: Admin/Brand
        public ActionResult Index()
        {
            var cs = Session["customers"];
            if (cs == null)
            {
                return RedirectToAction("LoginForm", "Admin");
            }
            return View();
        }
        public ActionResult GetData()
        {
            var cs = Session["customers"];
            if (cs == null)
            {
                return RedirectToAction("LoginForm", "Admin");
            }
            List<Brand> lstbr = new List<Brand>();
            lstbr = func.getAllBrands();
            var data = new List<Brand>(lstbr);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DelBrand(string id)
        {
            var cs = Session["customers"];
            if (cs == null)
            {
                return RedirectToAction("LoginForm", "Admin");
            }
            if (func.delBrand(Convert.ToInt32(id)))
                return Content("success");
            else
                return Content("fail");
        }
        [HttpPost]
        public ActionResult CreateBrand(FormCollection formData)
        {
            var cs = Session["customers"];
            if (cs == null)
            {
                return RedirectToAction("LoginForm", "Admin");
            }
            Brand brand = new Brand();
            brand.brandName = formData["brandName"];
            brand.brandDesription = formData["brandDesription"];
            brand.brandPiture = formData["brandPiture"];
            brand.brandHomePage = formData["brandHomePage"];
            func.createBrand(brand);
            return Content("");
        }
        [HttpPost]
        public ActionResult EditBrand(FormCollection formData)
        {
            var cs = Session["customers"];
            if (cs == null)
            {
                return RedirectToAction("LoginForm", "Admin");
            }
            Brand brand=new Brand();
            brand.ID = Convert.ToInt32(formData["ID"]);
            brand.brandDesription = formData["brandDesription"];
            brand.brandHomePage = formData["brandHomePage"];
            brand.brandPiture = formData["brandPiture"];
            brand.brandName = formData["brandName"];
            if (func.EditBrand(brand))
                return Content("success");
            else
                return Content("fail");
        }
    }
}