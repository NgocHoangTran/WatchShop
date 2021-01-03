using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Function;
using WebApplication1.Models;
using OfficeOpenXml;
using System.IO;

namespace WebApplication1.Areas.Admin.Controllers
{
    
    public class ProductController : Controller
    {
        // GET: Admin/Product
        DBDongho db = new DBDongho();
        
        public ActionResult Index()
        {

            func func = new func();
            var cs = Session["customers"];
            if (cs == null)
            {
                return RedirectToAction("LoginForm", "Admin");
            }
            List<Product> lstpro = new List<Product>();
            lstpro = func.getAllProducts();
            ViewBag.categoryID = new SelectList(func.getAllCategories(), "ID", "cateName");
            ViewBag.BrandID = new SelectList(func.getAllBrands(), "ID", "brandName");
            return View();
        }
        public ActionResult GetData()
        {
            var cs = Session["customers"];
            if (cs == null)
                return RedirectToAction("LoginForm", "Admin");
            List<Product> lstpro = new List<Product>();
            lstpro = func.getAllProducts();
            var data = new List<Product>(lstpro);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult InsertPro()
        {
            var cs = Session["customers"];
            if (cs == null)
                return RedirectToAction("LoginForm", "Admin");
            var lst = func.getAllCategories();
            ViewBag.categoryID = new SelectList(lst, "ID", "cateName");
            ViewBag.BrandID = new SelectList(func.getAllBrands(), "ID", "brandName");
            return View();
        }
        public ActionResult AddPro(Product pro)
        {
            var cs = Session["customers"];
            if (cs == null)
                return RedirectToAction("LoginForm", "Admin");
            if (func.addPro(pro) == false)
                return Content("<html><h1>ERROR</h1></html>");
            return RedirectToAction("Index");
        }
        public ActionResult GetProductById(string id)
        {
            var cs = Session["customers"];
            if (cs == null)
                return RedirectToAction("LoginForm", "Admin");
            var pro = func.getProductById(Convert.ToInt32(id));
            var data = new
            {
                id = pro.ID,
                name = pro.productName,
                descript = pro.productDescription,
                price = pro.Price,
                promo = pro.promotionPrice,
                picture = pro.productPicture,
                proStt = pro.productStatus,
                catID = pro.categoryID,
                brand = pro.BrandID,
                viewC = pro.viewCount
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DelProduct(string id)
        {
            var cs = Session["customers"];
            if (cs == null)
                return RedirectToAction("LoginForm", "Admin");
            if (func.delProduct(Convert.ToInt32(id)) == true)
                return Content("success");
            else
                return Content("fail");
        }
        [HttpPost]
        public ActionResult EditProduct(FormCollection formData)
        {
            var cs = Session["customers"];
            if (cs == null)
                return RedirectToAction("LoginForm", "Admin");
            Product prod = new Product();
            prod.ID = Convert.ToInt32(formData["ID"]);
            prod.productName = formData["productName"];
            prod.productDescription = formData["productDescription"];
            if (formData["Price"] != "")
            {
                prod.Price = Convert.ToDecimal(formData["Price"]);
            }
            if (formData["promotionPrice"] != "")
            {
                prod.promotionPrice = Convert.ToDecimal(formData["promotionPrice"]);
            }
            if (formData["productPicture"] != "")
            {
                prod.productPicture = formData["productPicture"];
            }
            string x = formData["categoryID"];
            if (formData["categoryID"] != "")
            {
                prod.categoryID = Convert.ToInt32(formData["categoryID"]);
            }
            if (formData["viewCount"] != "")
            {
                prod.viewCount = Convert.ToInt32(formData["viewCount"]);
            }
            if (formData["BrandID"] != "")
            {
                prod.BrandID = Convert.ToInt32(formData["BrandID"]);
            }
            if (formData["productStatus"] == "True")
                prod.productStatus = true;
            else
                prod.productStatus = false;

            if (func.EditProduct(prod))
                return Content("success");
            else
                return Content("fail");

        }
        public void XuatExcel()
        {
            var _context = new DBDongho();
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string fileName = Path.Combine(path, "Product.xlsx");
            FileInfo newFile = new FileInfo(fileName);
            if (newFile.Exists)
            {
                newFile.Delete();  // ensures we create a new workbook
                newFile = new FileInfo(fileName);
            }
            List<Product> myProduct = new List<Product>();
            myProduct = func.getAllProducts();
            var listpro = (from pro in _context.Products
                           join cate in _context.Categories on pro.categoryID equals cate.ID
                           join bra in _context.Brands on pro.BrandID equals bra.ID
                           select new { id = pro.productName, name = pro.productName, des = pro.productDescription, pri = pro.Price, datecrea = pro.createDate, cateName = cate.cateName, branName = bra.brandName }).ToList();
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage pck = new ExcelPackage(newFile))
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");
                ws.Cells["A1"].Value = "ID product";
                ws.Cells["B1"].Value = "Name product";
                ws.Cells["C1"].Value = "Description product";
                ws.Cells["D1"].Value = "Price product";
                ws.Cells["E1"].Value = "Date create product";

                int rowstart = 2;
                foreach (var item in listpro)
                {
                    ws.Cells[string.Format("A{0}", rowstart)].Value = item.id;
                    ws.Cells[string.Format("B{0}", rowstart)].Value = item.name;
                    ws.Cells[string.Format("C{0}", rowstart)].Value = item.des;
                    ws.Cells[string.Format("D{0}", rowstart)].Value = item.pri;
                    ws.Cells[string.Format("E{0}", rowstart)].Value = item.datecrea.ToString();
                    ws.Cells[string.Format("F{0}", rowstart)].Value = item.cateName;
                    ws.Cells[string.Format("G{0}", rowstart)].Value = item.branName;
                    rowstart++;
                }
                ws.Cells["A:AZ"].AutoFitColumns();
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=Product.xls");
                Response.BinaryWrite(pck.GetAsByteArray());
                Response.End();
            }
                
            
        }
    }
}