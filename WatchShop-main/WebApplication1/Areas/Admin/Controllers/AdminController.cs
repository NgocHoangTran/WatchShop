using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApplication1.Function;
using WebApplication1.Models;

namespace WebApplication1.Areas.Admin.Controllers
{
    
    public class AdminController : Controller
    {
     
        // GET: Admin/Admin
        public ActionResult Index()
        {
            var cs = Session["customers"];
            if (cs == null)
                return RedirectToAction("LoginForm", "Admin");
            return View();
        }
        public ActionResult RegisterForm()
        {           
            return View();
        }
        public ActionResult LoginForm()
        {
            return View();
        }
        public ActionResult registerAdmin(string name, string mail, string pass)
        {
            var admin = new WebApplication1.Models.Customer() { accuontName = name, passWord = Encrypt.GetMD5(pass), Email = mail, idCusAuthe=1 };
            func func = new func();
            if(func.RegisterAdmin(admin)==true)
            {
                return Content("Success");
            }
            else
            {
                return Content("Fail");
            }
        }
        public ActionResult loginAdmin(string acc,string pass)
        {

            if (func.LoginAdmin(acc, pass))
            {
                func f = new func();
                Customer cs = func.GetCustomer(acc);
                if (cs.idUser == 2)
                {
                    return Content("AdminLogin");
                }
                if (cs != null)
                {
                    Session["customers"] = cs;
                    if (cs.idCusAuthe==1)
                    {
                        return Content("AdminLogin");
                    }
                    else
                        return Content("RegisterForm");
                }
                else
                    return Content("RegisterForm");
            }

            else
                return Content("RegisterForm");
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
    }
}