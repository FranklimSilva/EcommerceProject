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
    public class OrderDetailsTmpsController : Controller
    {
        private EcommerceContext db = new EcommerceContext();

        // GET: OrderDetailsTmps
        public ActionResult Index()
        {
            return View(db.OrderDetailsTmps.ToList());
        }

        // GET: OrderDetailsTmps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetailsTmp orderDetailsTmp = db.OrderDetailsTmps.Find(id);
            if (orderDetailsTmp == null)
            {
                return HttpNotFound();
            }
            return View(orderDetailsTmp);
        }

        // GET: OrderDetailsTmps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderDetailsTmps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderDetailId,OrderId,ProductId,UserName,FirstName,LastName,Address,Photo,Description,TaxRate,Price,Quantity,LastDate")] OrderDetailsTmp orderDetailsTmp)
        {
            if (ModelState.IsValid)
            {
                db.OrderDetailsTmps.Add(orderDetailsTmp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderDetailsTmp);
        }

        // GET: OrderDetailsTmps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetailsTmp orderDetailsTmp = db.OrderDetailsTmps.Find(id);
            if (orderDetailsTmp == null)
            {
                return HttpNotFound();
            }
            return View(orderDetailsTmp);
        }

        // POST: OrderDetailsTmps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderDetailId,OrderId,ProductId,UserName,FirstName,LastName,Address,Photo,Description,TaxRate,Price,Quantity,LastDate")] OrderDetailsTmp orderDetailsTmp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderDetailsTmp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderDetailsTmp);
        }

        // GET: OrderDetailsTmps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetailsTmp orderDetailsTmp = db.OrderDetailsTmps.Find(id);
            if (orderDetailsTmp == null)
            {
                return HttpNotFound();
            }
            return View(orderDetailsTmp);
        }

        // POST: OrderDetailsTmps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderDetailsTmp orderDetailsTmp = db.OrderDetailsTmps.Find(id);
            db.OrderDetailsTmps.Remove(orderDetailsTmp);
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
