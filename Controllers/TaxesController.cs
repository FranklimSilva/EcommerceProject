using ECommerceProject.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ECommerceProject.Controllers
{
    public class TaxesController : Controller
    {
        private EcommerceContext db = new EcommerceContext();

        // GET: Taxes
        public ActionResult Index()
        {
            var user = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var taxes = db.Categories.Where(c => c.CompanyId == user.CompanyId);
            return View(taxes.ToList());
        }

        // GET: Taxes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tax tax = db.Taxes.Find(id);
            if (tax == null)
            {
                return HttpNotFound();
            }
            return View(tax);
        }

        // GET: Taxes/Create
        public ActionResult Create()
        {
            var user = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var taxes = new Tax
            {
                CompanyId = user.CompanyId
            };
            return View();
        }

        // POST: Taxes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaxId,Description,Rate,CompanyId")] Tax tax)
        {
            if (ModelState.IsValid)
            {
                db.Taxes.Add(tax);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name", tax.CompanyId);
            return View(tax);
        }

        // GET: Taxes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tax tax = db.Taxes.Find(id);
            if (tax == null)
            {
                return HttpNotFound();
            }
            return View(tax);
        }

        // POST: Taxes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaxId,Description,Rate,CompanyId")] Tax tax)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tax).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "Name", tax.CompanyId);
            return View(tax);
        }

        // GET: Taxes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tax tax = db.Taxes.Find(id);
            if (tax == null)
            {
                return HttpNotFound();
            }
            return View(tax);
        }

        // POST: Taxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tax tax = db.Taxes.Find(id);
            db.Taxes.Remove(tax);
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
