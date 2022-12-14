using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ECommerceProject.Classes;
using ECommerceProject.Models;

namespace ECommerceProject.Controllers
{
    [Authorize(Roles = "Admin")]

    public class CompaniesController : Controller
    {
        private EcommerceContext db = new EcommerceContext();

        //Upload de imagens


        //CONTROLE DE LIST VIEW EM CASCATA
        public JsonResult GetCities (int departamentId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var cities = db.Cities.Where(c => c.DepartamentsId == departamentId);
            return Json(cities);
        }

        // GET: Companies
        public ActionResult Index()
        {
            var companies = db.Companies.Include(c => c.Cities).Include(c => c.Departments);
            return View(companies.ToList());
        }

        // GET: Companies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {

            ViewBag.DepartamentsId = new SelectList(ComboHelpers.GetDepartaments(), "DepartamentsId", "Name");
            ViewBag.CityId = new SelectList(ComboHelpers.GetCities(), "CityId", "Name");
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Company company)
        {
            if (ModelState.IsValid)
            {
                db.Companies.Add(company);
                db.SaveChanges();

                if (company.LogoFile != null)
                {
                    var pic = string.Empty;
                    var folder = "~/Content/Logos";
                    var file = string.Format("{0}.jpg", company.CompanyId);
                    var response = FilesHelpers.UploadPhoto(company.LogoFile, folder, file);

                    if (response)
                    {
                        pic = string.Format("{0}/{1}", folder, file);
                        company.Logo = pic;
                    }
                }
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartamentsId = new SelectList(ComboHelpers.GetDepartaments(), "DepartamentsId", "Name", company.DepartamentsId);
            ViewBag.CityId = new SelectList(ComboHelpers.GetCities(), "CityId", "Name", company.CityId);
            return View(company);
        }

        // GET: Companies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }

            ViewBag.DepartamentsId = new SelectList(ComboHelpers.GetDepartaments(), "DepartamentsId", "Name", company.DepartamentsId);
            ViewBag.CityId = new SelectList(ComboHelpers.GetCities(), "CityId", "Name", company.CityId);
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Company company)
        {
            if (ModelState.IsValid)
            {

                if (company.LogoFile != null)
                {
                    var pic = string.Empty;
                    var folder = "~/Content/Logos";
                    var file = string.Format("{0}.jpg", company.CompanyId);
                    var response = FilesHelpers.UploadPhoto(company.LogoFile, folder, file);

                    if (response)
                    {

                        pic = string.Format("{0}/{1}", folder, file);
                        company.Logo = pic;
                    }
                }
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartamentsId = new SelectList(ComboHelpers.GetDepartaments(), "DepartamentsId", "Name", company.DepartamentsId);
            ViewBag.CityId = new SelectList(ComboHelpers.GetCities(), "CityId", "Name", company.CityId);

            return View(company);
        }

        // GET: Companies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = db.Companies.Find(id);
            db.Companies.Remove(company);
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
