using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class Orders1Controller : Controller
    {
        private DBDongho db = new DBDongho();

        // GET: Admin/Orders1
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Customer).Include(o => o.Delivery).Include(o => o.Product).Include(o => o.Status);
            return View(orders.ToList());
        }

        // GET: Admin/Orders1/Details/5
        public ActionResult Details(int id_user, int id_pro)
        {
            if (id_user == null || id_pro == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Where(x => x.id_product == id_pro && x.id_user == id_user).FirstOrDefault();
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        public ActionResult Edit(int id_user, int id_pro)
        {
            if (id_user == null || id_pro == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Where(x => x.id_product == id_pro && x.id_user == id_user).FirstOrDefault();
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_user = new SelectList(db.Customers, "idUser", "accuontName", order.id_user);
            ViewBag.id_deli = new SelectList(db.Deliveries, "id", "name", order.id_deli);
            ViewBag.id_product = new SelectList(db.Products, "ID", "productName", order.id_product);
            ViewBag.id_stt = new SelectList(db.Status, "id", "status1", order.id_stt);
            return View(order);
        }

        // POST: Admin/Orders1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_user,id_product,id_stt,quantity,total,addressTo,id_deli,createDate,requireDate")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_user = new SelectList(db.Customers, "idUser", "accuontName", order.id_user);
            ViewBag.id_deli = new SelectList(db.Deliveries, "id", "name", order.id_deli);
            ViewBag.id_product = new SelectList(db.Products, "ID", "productName", order.id_product);
            ViewBag.id_stt = new SelectList(db.Status, "id", "status1", order.id_stt);
            return View(order);
        }

        // GET: Admin/Orders1/Delete/5
        public ActionResult Delete(int id_user, int id_pro)
        {
            if (id_user == null || id_pro == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Where(x => x.id_product == id_pro && x.id_user == id_user).FirstOrDefault();
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Admin/Orders1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id_user, int id_pro)
        {
            Order order = db.Orders.Where(x => x.id_product == id_pro && x.id_user == id_user).FirstOrDefault();
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
