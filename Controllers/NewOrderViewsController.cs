using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ECommerceProject.Models;

namespace ECommerceProject.Controllers
{
    public class NewOrderViewsController : Controller
    {
        private EcommerceContext db = new EcommerceContext();

        // GET: NewOrderViews
        public ActionResult Index()
        {
            return View(db.NewOrderViews.ToList());
        }

        // GET: NewOrderViews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewOrderView newOrderView = db.NewOrderViews.Find(id);
            if (newOrderView == null)
            {
                return HttpNotFound();
            }
            return View(newOrderView);
        }

        // GET: NewOrderViews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewOrderViews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NewOrderViewId,Date,Detail")] NewOrderView newOrderView)
        {
            if (ModelState.IsValid)
            {
                db.NewOrderViews.Add(newOrderView);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newOrderView);
        }

        // GET: NewOrderViews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewOrderView newOrderView = db.NewOrderViews.Find(id);
            if (newOrderView == null)
            {
                return HttpNotFound();
            }
            return View(newOrderView);
        }

        // POST: NewOrderViews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NewOrderViewId,Date,Detail")] NewOrderView newOrderView)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newOrderView).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newOrderView);
        }

        // GET: NewOrderViews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewOrderView newOrderView = db.NewOrderViews.Find(id);
            if (newOrderView == null)
            {
                return HttpNotFound();
            }
            return View(newOrderView);
        }

        // POST: NewOrderViews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewOrderView newOrderView = db.NewOrderViews.Find(id);
            db.NewOrderViews.Remove(newOrderView);
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
