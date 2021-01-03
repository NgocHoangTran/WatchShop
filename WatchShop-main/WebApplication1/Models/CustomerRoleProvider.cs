using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
        public class CustomRoleProvider : RoleProvider
        {
            SetPortalContext db = new SetPortalContext(); //khai bao context
            public override string[] GetRolesForUser(string name)
            {
                // tạo biến getrole, so sánh xem UserID đang đăng nhập có giống với tên trong db ko
                User account = db.Users.Single(x => x.UserID.Equals(name));
                if (account != null) // Nếu giống
                {
                    return new String[] { account.Role.RoleName };
                }
                else
                    return new String[] { };
            }
        }
}