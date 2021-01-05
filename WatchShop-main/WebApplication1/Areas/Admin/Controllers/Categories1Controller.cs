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
    public class Categories1Controller : Controller
    {
        private DBDongho db = new DBDongho();

        // GET: Admin/Categories1
        public ActionResult Index()
        {
            var cs = Session["customers"];
            if (cs == null)
            {
                return RedirectToAction("LoginForm", "Admin");
            }
            return View(db.Categories.ToList());
        }


        // GET: Admin/Categories1/Create
        public ActionResult Create()
        {
            var cs = Session["customers"];
            if (cs == null)
            {
                return RedirectToAction("LoginForm", "Admin");
            }
            return View();
        }

        // POST: Admin/Categories1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,cateName,cateDescription,catePicture")] Category category)
        {
            var cs = Session["customers"];
            if (cs == null)
            {
                return RedirectToAction("LoginForm", "Admin");
            }
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Admin/Categories1/Edit/5
        public ActionResult Edit(int? id)
        {
            var cs = Session["customers"];
            if (cs == null)
            {
                return RedirectToAction("LoginForm", "Admin");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Categories1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,cateName,cateDescription,catePicture")] Category category)
        {
            var cs = Session["customers"];
            if (cs == null)
            {
                return RedirectToAction("LoginForm", "Admin");
            }
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Admin/Categories1/Delete/5
        public ActionResult Delete(int? id)
        {
            var cs = Session["customers"];
            if (cs == null)
            {
                return RedirectToAction("LoginForm", "Admin");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Categories1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var cs = Session["customers"];
            if (cs == null)
            {
                return RedirectToAction("LoginForm", "Admin");
            }
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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
