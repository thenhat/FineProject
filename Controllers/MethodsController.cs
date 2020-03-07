using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoneyProject.Models;

namespace MoneyProject.Controllers
{
    public class MethodsController : Controller
    {
        private MyDatabaseContext db = new MyDatabaseContext();

        // GET: Methods
        public ActionResult Index()
        {
            return View(db.Methods.ToList());
        }

        // GET: Methods/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Method method = db.Methods.Find(id);
            if (method == null)
            {
                return HttpNotFound();
            }
            return View(method);
        }

        // GET: Methods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Methods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Method method)
        {
            if (ModelState.IsValid)
            {
                db.Methods.Add(method);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(method);
        }

        // GET: Methods/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Method method = db.Methods.Find(id);
            if (method == null)
            {
                return HttpNotFound();
            }
            return View(method);
        }

        // POST: Methods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Method method)
        {
            if (ModelState.IsValid)
            {
                db.Entry(method).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(method);
        }

        // GET: Methods/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Method method = db.Methods.Find(id);
            if (method == null)
            {
                return HttpNotFound();
            }
            return View(method);
        }

        // POST: Methods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Method method = db.Methods.Find(id);
            db.Methods.Remove(method);
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
