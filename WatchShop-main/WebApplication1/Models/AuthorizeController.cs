using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class AuthorizeController : ActionFilterAttribute
    {
        DBDongho db = new DBDongho();
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Customer cs= HttpContext.Current.Session["customers"] as Customer;
            if(cs==null)
            {
                filterContext.Result = new RedirectResult("Admin/Admin/Register");
            }
            else
            {
                var cs_roles = db.cusAuthe_Roles.Where(n=> n.idCusAuthe== cs.idCusAuthe);
                int count_roles = cs_roles.Count();
                string[] listpermission = new string[count_roles];
                int i = 0;
                //lấy danh sách quyền đưa vào mảng
                foreach (var item in cs_roles)
                {
                    listpermission[i] = item.RoleID.ToString();
                    i++;
                }
                string ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                if (!listpermission.Contains(ControllerName))
                {
                    filterContext.Result = new RedirectResult("~/Home/DangNhap");
                }
            }
        }
    }
}