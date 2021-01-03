using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Function
{
    public class func
    {
        public static List<Product> FilterPro(int id)
        {
            using (var _Context= new DBDongho())
            {
                _Context.Configuration.LazyLoadingEnabled = false;
                var Listpro = (from pro in _Context.Products
                               where pro.categoryID == id
                               select pro).ToList();
                return Listpro;
            }
        }
        public static List<Product> FilterBrand(int id)
        {
            using (var _Context = new DBDongho())
            {
                _Context.Configuration.LazyLoadingEnabled = false;
                var Listpro = (from pro in _Context.Products
                               where pro.BrandID == id
                               select pro).ToList();
                return Listpro;
            }
        }
        public static string sendEmail(string mail)
        {
            //email của dự án
            string email = "nhomltweb@gmail.com";
            string password = "123456789a@";
            //tao code xac nhan
            string ranCod = RandomString(10, false);

            var loginInfo = new NetworkCredential(email, password);
            var msg = new MailMessage();
            var smtpClient = new SmtpClient("smtp.gmail.com", 25);


            msg.From = new MailAddress(email);
            msg.To.Add(mail);
            msg.Subject = "Hello";
            msg.Body = "Your verification code is: " + ranCod;
            msg.IsBodyHtml = true;

            //gán cho biến TempData để có thể kiểm tra xem user nhập đúng không 


            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = loginInfo;
            smtpClient.Send(msg);

            return ranCod;
        }

        public static List<Category> getAllCategories()
        {
            using (var _context = new DBDongho())
            {
                _context.Configuration.LazyLoadingEnabled = false;
                var dbcat = (from cat in _context.Categories
                             select cat).ToList();
                return dbcat;
            }
        }

        private static string RandomString(int size, bool lowerCase)
        {
            System.Text.StringBuilder sb = new StringBuilder();
            char c;
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                c = Convert.ToChar(Convert.ToInt32(rand.Next(65, 87)));
                sb.Append(c);
            }
            if (lowerCase)
            {
                return sb.ToString().ToLower();
            }
            return sb.ToString();
        }
        public static bool IsValidEmail(string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new System.Text.RegularExpressions.Regex(pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }
        public static bool signIn(string acc, string pass)
        {
            using (var _context = new DBDongho())
            {
                var dbcus = (from cus in _context.Customers
                             where cus.accuontName == acc && cus.passWord == pass
                             select cus).ToList();
                if (dbcus.Count == 1)
                    return true;
                else
                    return false;
            }
        }
        public static bool register(Customer cus)
        {
            if (AccIsExists(cus) == false)
            {
                using (var _context= new DBDongho())
                {
                    cus.passWord = Encrypt.GetMD5(cus.passWord);
                    _context.Customers.Add(cus);
                    _context.SaveChanges();
                    return true;
                }
            }
            return false;    
        }
        public static bool AccIsExists(Customer cus)
        {
            using (var _context = new DBDongho())
            {
                var dbcus = (from c in _context.Customers
                             where c.accuontName == cus.accuontName
                             select c).SingleOrDefault();
                if (dbcus != null)
                    return true;
                else
                    return false;
            }
        }
        public static List<Product> getAllProducts()
        {
            using (var _context= new DBDongho())
            {
                _context.Configuration.LazyLoadingEnabled = false;
                var dbpro = (from pro in _context.Products
                             select pro).ToList();
                return dbpro;
            }
        }
        public static bool addPro(Product pro)
        {
            try
            {
                using (var _context = new DBDongho())
                {
                    _context.Products.Add(pro);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static Product getProductById(int id)
        {
            using(var _context= new DBDongho())
            {
                var dbpro = (from p in _context.Products
                             where p.ID == id
                             select p).SingleOrDefault();
                return dbpro;
            }
        }
        public static bool delProduct(int id)
        {
            try
            {
                using (var _context = new DBDongho())
                {
                    var dbpro = (from pr in _context.Products
                                 where pr.ID == id
                                 select pr).SingleOrDefault();
                    _context.Products.Remove(dbpro);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static Customer GetCustomer(string acc)
        {
            using(var _context= new DBDongho())
            {
                var dbcus = (from c in _context.Customers
                             where c.accuontName == acc
                             select c).SingleOrDefault();
                return dbcus;
            }
        }
        public static bool RegisterAdmin(Customer admin)
        {
            try
            {
                using (var _context = new DBDongho())
                {
                    _context.Customers.Add(admin);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch { return false; }
        }
        public static bool LoginAdmin(string acc,string pass)
        {
            using(var _context= new DBDongho())
            {
                var dbadmin = (from a in _context.Customers
                               where a.accuontName == acc && a.passWord == pass
                               select a).ToList();
                if (dbadmin.Count() == 1)
                    return true;
                return false;
            }
        }
        public static bool EditProduct(Product prod)
        {           
            try
            {
                using (var _context = new DBDongho())
                {
                    _context.Products.AddOrUpdate(prod);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static bool delCategory(int id)
        {
            try
            {
                using (var _context = new DBDongho())
                {
                    var dbcat = (from cat in _context.Categories
                                 where cat.ID == id
                                 select cat).SingleOrDefault();
                    _context.Categories.Remove(dbcat);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static void createCategory(Category cate)
        {
            using (var _context = new DBDongho())
            {
                _context.Categories.Add(cate);
                _context.SaveChanges();
            }
        }
        public static bool EditCategory(Category cate)
        {
            try
            {
                using (var _context = new DBDongho())
                {
                    _context.Categories.AddOrUpdate(cate);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static List<Brand> getAllBrands()
        {
            using(var _context=new DBDongho())
            {
                _context.Configuration.LazyLoadingEnabled = false;
                var dbbrand = (from br in _context.Brands
                               select br).ToList();
                return dbbrand;
            }
        }
        public static bool delBrand(int id)
        {
            try
            {
                using (var _context = new DBDongho())
                {
                    var dbbr = (from br in _context.Brands
                                 where br.ID == id
                                 select br).SingleOrDefault();
                    _context.Brands.Remove(dbbr);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static void createBrand(Brand brand)
        {
            using( var _context=new DBDongho())
            {
                _context.Brands.Add(brand);
                _context.SaveChanges();
            }
        }
        public static bool EditBrand(Brand brand)
        {
            try
            {
                using (var _context = new DBDongho())
                {
                    _context.Brands.AddOrUpdate(brand);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool Add_Item(int id_user, int id_pro, int quantity)
        {
            try
            {
                using (var _context = new DBDongho())
                {
                    var pro_count = _context.Products.Where(p => p.ID == id_pro).FirstOrDefault().viewCount;
                    //kiem tra so luong ton co du ban khong
                    if(pro_count < quantity)
                    {
                        return false;
                    }
                    //Kiểm tra xem đã thêm sản phẩm này vào giỏ hàng chưa ?
                    var item = (from c in _context.Carts
                                where c.id_user == id_user && c.id_product == id_pro
                                select c).FirstOrDefault();
                    //Tăng số lượng sản phẩm lên 1 nếu user đã thêm sản phẩm này vào giỏ hàng
                    if (item != null)
                    {
                        item.count = item.count + quantity;
                        _context.Carts.AddOrUpdate(item);
                        _context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        Cart cart = new Cart() { id_user = id_user, id_product = id_pro, count = quantity };
                        _context.Carts.Add(cart);
                        _context.SaveChanges();
                        return true;
                    }

                }

            }
            catch
            {
                return false;
            }
        }
        public static List<Cart> GetListCart(int id_user)
        {
            using (var _context = new DBDongho())
            {
                var dbcart = (from c in _context.Carts.Include("Product")
                              where c.id_user == id_user
                              select c).ToList();
                return dbcart;
            }
        }
        public static void DeleteItemCart(int id_user, int id_pro)
        {
            using(var _context=new DBDongho())
            {
                var dbcart = (from c in _context.Carts
                              where c.id_product == id_pro && c.id_user == id_user
                              select c).SingleOrDefault();
                _context.Carts.Remove(dbcart);
                _context.SaveChanges();
            }
        }
        public static void DeleteAllCart(int id_user)
        {
            using(var _context=new DBDongho())
            {
                var dbcart = (from c in _context.Carts
                              where c.id_user == id_user
                              select c).ToList();
                foreach(var item in dbcart)
                {
                    DeleteItemCart(item.id_user, item.id_product);
                }
            }
        }
        public static void CreateOrder(int id_cus)
        {
            using(var _context=new DBDongho())
            {
                var listCart = GetListCart(id_cus);
                foreach(var item in listCart)
                {
                    Order order = new Order() {
                        id_product = item.id_product,
                        id_deli = 1,
                        id_user = id_cus,
                        addressTo = "TP.HCM",
                        createDate = DateTime.Now,
                        id_stt = 1,
                        requireDate = DateTime.Now.AddDays(3),
                        quantity = item.count,
                        total = item.count * item.Product.Price
                    };
                    var dbpro = _context.Products.Where(x => x.ID == item.id_product).FirstOrDefault();
                    dbpro.sold = dbpro.sold + item.count;
                    dbpro.turnover = dbpro.turnover + dbpro.sold * dbpro.Price;
                    _context.Products.AddOrUpdate(dbpro);
                    _context.SaveChanges();
                    _context.Orders.Add(order);
                    _context.SaveChanges();
                }

            }
            DeleteAllCart(id_cus);
        }
        public static List<Order> GetListOrder(int id_cus)
        {
            using (var _context=new DBDongho())
            {
                return _context.Orders.Where(x => x.id_user == id_cus).Include("Product").Include("Delivery").Include("Status").ToList();
            }
        }
        public static Order GetOrder(int id_user, int id_pro)
        {
            using(var _context=new DBDongho())
            {
                return _context.Orders.Where(x => x.id_user == id_user && x.id_product == id_pro).Include("Product").Include("Delivery").Include("Status").SingleOrDefault();
            }
        }
        
    }
}