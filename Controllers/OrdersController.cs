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
    [Authorize(Roles = "User,Admin")]
    public class OrdersController : Controller
    {
        private EcommerceContext db = new EcommerceContext();

        //ADICIONAR OS PRODUTOS GET
        public ActionResult AddProduct()
        {
            var user = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            ViewBag.ProductId = new SelectList(ComboHelpers.GetProduct(user.UserId), "ProductId", "Description");

            return View();
        }
        //ADICIONAR OS PRODUTOS POST
        [HttpPost]
        public ActionResult AddProduct(AddProductView view)
        {
            var user = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();

            if (ModelState.IsValid)
            {
                var orderDetailTmps = db.OrderDetailsTmps.Where(odt => odt.UserName == User.Identity.Name && odt.ProductId == view.ProductId).FirstOrDefault();

                if (orderDetailTmps == null)
                {

                    var product = db.Products.Find(view.ProductId);
                    orderDetailTmps = new OrderDetailsTmp
                    {
                        Description = product.Description,
                        Price = product.Price,
                        ProductId = product.ProductId,
                        Quantity = view.Quantity,
                        TaxRate = product.Tax,
                        UserName = User.Identity.Name,
                    };
                    db.OrderDetailsTmps.Add(orderDetailTmps);
                }
                else
                {
                    orderDetailTmps.Quantity += view.Quantity;
                    db.Entry(orderDetailTmps).State = EntityState.Modified;

                }

                var quantity = view.Quantity;
                var inventory = db.Inventories.Where(i => i.ProductId == view.ProductId).FirstOrDefault();

                inventory.Stock -= quantity;

                if (orderDetailTmps.Product.Stock >= 0)
                {
                    db.SaveChanges();
                    return RedirectToAction("Create");
                }
                else
                {
                   return PartialView("InventoryValidate");
                }
            }

            ViewBag.ProductId = new SelectList(ComboHelpers.GetProduct(user.UserId), "ProductId", "Description");

            return PartialView(view);
        }

        public ActionResult InventoryValidate(AddProductView product)
        {
            var user = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var products = db.Products.Include(p => p.CategoryId).Include(p => p.Tax).Where(c => c.CompanyId == user.CompanyId);

            return View(products.ToList());
        }

            // DELETAR OS PRODUTOS 

            public ActionResult DeleteProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var orderDetailTmps = db.OrderDetailsTmps.Where(odt => odt.UserName == User.Identity.Name && odt.ProductId == id).FirstOrDefault();
            if (orderDetailTmps == null)
            {
                return HttpNotFound();
            }
            db.OrderDetailsTmps.Remove(orderDetailTmps);

            var quantity = orderDetailTmps.Quantity;
            var inventory = db.Inventories.Where(i => i.ProductId == orderDetailTmps.ProductId).FirstOrDefault();

            inventory.Stock += quantity;
            db.SaveChanges();
            return RedirectToAction("Create");
        }
        // GET: Orders
        public ActionResult Index()
        {
            var user = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            var orders = db.Orders.Where(c => c.CompanyId == user.CompanyId);

            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            var user = db.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "FullName");
            var view = new Order
            {
                Date = DateTime.Now,
                Details = db.OrderDetailsTmps.Where(ot => ot.UserName == User.Identity.Name).ToList()
            };
            return View(view);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
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
