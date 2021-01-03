using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Function;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        public ActionResult Index()
        {
            Customer cus = new Customer();
            cus = Session["customers"] as Customer;
            if(cus != null)
            {
                //Lấy giỏ hàng của user đăng nhập
                List<Cart> listCart = func.GetListCart(cus.idUser);
                ViewBag.listCart = listCart;
                ViewBag.count = listCart.Count();
                decimal total = 0;
                foreach(var item in listCart)
                {
                    total = total + (decimal)item.Product.Price * (int)item.count;
                }
                ViewBag.total = total;
            }
            else
            {
                //Không đăng nhập thì giỏ hàng rỗng
                List<Cart> listCart = new List<Cart>();
                ViewBag.listCart = listCart;
                ViewBag.total = 0;
                ViewBag.count = 0;
            }
            return View();
        }
        public ActionResult Delete(string id_pro)
        {
            //Dùng ajax gọi function này
            //Xóa sản phẩm dưới database giỏ hàng
            try
            {
                Customer cus = new Customer();
                cus = Session["customers"] as Customer;
                if(cus == null)
                {
                    return Redirect("/Home/Index/");
                }
                func.DeleteItemCart(cus.idUser, Convert.ToInt32(id_pro));
                return Content("");
            }
            catch
            {
                return Content("");
            }
        }
    }
}