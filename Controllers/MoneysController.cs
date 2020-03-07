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
    public class MoneysController : Controller
    {
        private MyDatabaseContext db = new MyDatabaseContext();

        // GET: Moneys
        public ActionResult Index()
        {
            var moneys = db.Moneys.Include(m => m.Method);
            return View(moneys.ToList());
        }

        // GET: Moneys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Money money = db.Moneys.Find(id);
            if (money == null)
            {
                return HttpNotFound();
            }
            return View(money);
        }

        // GET: Moneys/Create
        public ActionResult Create()
        {
            ViewBag.MethodId = new SelectList(db.Methods, "Id", "Name");
            return View();
        }

        // POST: Moneys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MaSV,CountD,Date,MethodId")] Money money)
        {
            if (ModelState.IsValid)
            {
                db.Moneys.Add(money);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MethodId = new SelectList(db.Methods, "Id", "Name", money.MethodId);
            return View(money);
        }

        // GET: Moneys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Money money = db.Moneys.Find(id);
            if (money == null)
            {
                return HttpNotFound();
            }
            ViewBag.MethodId = new SelectList(db.Methods, "Id", "Name", money.MethodId);
            return View(money);
        }

        // POST: Moneys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MaSV,CountD,Date,MethodId")] Money money)
        {
            if (ModelState.IsValid)
            {
                db.Entry(money).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MethodId = new SelectList(db.Methods, "Id", "Name", money.MethodId);
            return View(money);
        }

        // GET: Moneys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Money money = db.Moneys.Find(id);
            if (money == null)
            {
                return HttpNotFound();
            }
            return View(money);
        }

        // POST: Moneys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Money money = db.Moneys.Find(id);
            db.Moneys.Remove(money);
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
