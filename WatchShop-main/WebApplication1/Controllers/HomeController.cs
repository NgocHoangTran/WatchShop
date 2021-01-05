using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Function;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            
                List<Category> myList = func.getAllCategories();
                ViewBag.MyList = myList;
            
            return View();
        }
        public ActionResult Account()
        {
            return View();
        }
        public ActionResult CreateAccount()
        {
            return View();
        }
        public ActionResult ForgotPass()
        {
            return View();
        }
        public ActionResult SendMail(string mail)
        {
            //kiem tra email hop le
            if (func.IsValidEmail(mail) == false)
                return Content("");

            //gui mail
            TempData["code"] = func.sendEmail(mail);
            return Content("");
        }

        public ActionResult ValidCode(string code)
        {

            if (TempData["code"] != null)
            {
                if (code == TempData["code"].ToString())
                    return Content("Valid");
                else
                    return Content("Invalid");
            }
            else
                return Content("Invalid");
        }
        public ActionResult Login(string account, string password)
        {
            if (func.signIn(account, password))
            {
                Customer cs = func.GetCustomer(account);
                if (cs != null)
                {
                    Session["customers"] = cs;
                }
                return Content("success");
            }
            else
                return Content("fail");
        }
        [HttpPost]
        public ActionResult Register(Customer cus)
        {
            //gan quyen
            cus.idUser = 2;
            if (func.register(cus))
                return RedirectToAction("Index");
            return Content("Error");
        }
        public PartialViewResult getCate()
        {
            var lstCate = func.getAllCategories();
            ViewBag.lstCate = lstCate;
            return PartialView();
        }
        public PartialViewResult trend()
        {
            var lstPro = func.getAllProducts();
            ViewBag.lstPro = lstPro.Take(3);
            return PartialView();
        }
        //public ActionResult Error()
        //{
        //    return View();
        //}
    }
}