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
    public class CompanyCustomersController : Controller
    {
        private EcommerceContext db = new EcommerceContext();

        // GET: CompanyCustomers
        public ActionResult Index()
        {
            var companyCustomers = db.CompanyCustomers.Include(c => c.Company);
            return View(companyCustomers.ToList());
        }

        // GET: CompanyCustomers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyCustomer companyCustomer = db.CompanyCustomers.Find(id);
            if (companyCustomer == null)
            {
                return HttpNotFound();
            }
            return View(companyCustomer);
        }

        // GET: CompanyCustomers/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name");
            return View();
        }

        // POST: CompanyCustomers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyCustomerId,CustomerId,CompanyId")] CompanyCustomer companyCustomer)
        {
            if (ModelState.IsValid)
            {
                db.CompanyCustomers.Add(companyCustomer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name", companyCustomer.CompanyId);
            return View(companyCustomer);
        }

        // GET: CompanyCustomers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyCustomer companyCustomer = db.CompanyCustomers.Find(id);
            if (companyCustomer == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name", companyCustomer.CompanyId);
            return View(companyCustomer);
        }

        // POST: CompanyCustomers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyCustomerId,CustomerId,CompanyId")] CompanyCustomer companyCustomer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyCustomer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name", companyCustomer.CompanyId);
            return View(companyCustomer);
        }

        // GET: CompanyCustomers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyCustomer companyCustomer = db.CompanyCustomers.Find(id);
            if (companyCustomer == null)
            {
                return HttpNotFound();
            }
            return View(companyCustomer);
        }

        // POST: CompanyCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyCustomer companyCustomer = db.CompanyCustomers.Find(id);
            db.CompanyCustomers.Remove(companyCustomer);
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
