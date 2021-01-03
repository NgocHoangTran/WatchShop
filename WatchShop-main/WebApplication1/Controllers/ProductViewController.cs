 
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Function;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class ProductViewController : Controller
    {
        // GET: ProductView
        public ActionResult Index()
        {
            List<Category> myList = func.getAllCategories();
            ViewBag.MyList = myList;
            List<Product> myProduct = func.getAllProducts();
            ViewBag.myProduct = myProduct;
            List<Brand> myBrand = func.getAllBrands();
            ViewBag.myBrand = myBrand;
            return View();
        }
        public ActionResult Detail(int id)
        {
            var proc = func.getProductById(id);
            return View(proc);
        }
        public ActionResult FilterProduct(int id)
        {
            List<Product> proc = func.FilterPro(id);
            ViewBag.myProduct = proc;
            List<Category> myList = func.getAllCategories();
            ViewBag.MyList = myList;
            List<Brand> myBrand = func.getAllBrands();
            ViewBag.myBrand = myBrand;
            return View("Index");
        }
        public ActionResult FilterBrand(int id)
        {
            List<Product> proc = func.FilterBrand(id);
            ViewBag.myProduct = proc;
            List<Category> myList = func.getAllCategories();
            ViewBag.MyList = myList;
            List<Brand> myBrand = func.getAllBrands();
            ViewBag.myBrand = myBrand;
            return View("Index");
        }
        public ActionResult AddItem(string id_pro, string quantity)
        {
            Customer cus = new Customer();
            cus = Session["customers"] as Customer;
            try
            {
                if (cus == null)
                {
                    return Content("login");
                }
                else
                {
                    if (func.Add_Item(cus.idUser, Convert.ToInt32(id_pro), Convert.ToInt32(quantity)))
                        return Content("success");
                    else
                        return Content("fail");
                }
            }
            catch
            {
                return Content("fail");
            }
        }
        
    }
}