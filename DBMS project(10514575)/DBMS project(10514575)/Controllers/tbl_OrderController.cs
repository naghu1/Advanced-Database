using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DBMS_project_10514575_.Models;

namespace DBMS_project_10514575_.Controllers
{
    public class tbl_OrderController : Controller
    {
        private laptopdbEntities db = new laptopdbEntities();

        // GET: tbl_Order
        public ActionResult Index()
        {
            var tbl_Order = db.tbl_Order.Include(t => t.tbl_Client);
            return View(tbl_Order.ToList());
        }

        // GET: tbl_Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Order tbl_Order = db.tbl_Order.Find(id);
            if (tbl_Order == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Order);
        }

        // GET: tbl_Order/Create
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.tbl_Client, "ClientID", "ClientName");
            return View();
        }

        // POST: tbl_Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,OrderDate,TotalAmount,ClientID")] tbl_Order tbl_Order)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Order.Add(tbl_Order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.tbl_Client, "ClientID", "ClientName", tbl_Order.ClientID);
            return View(tbl_Order);
        }

        // GET: tbl_Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Order tbl_Order = db.tbl_Order.Find(id);
            if (tbl_Order == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.tbl_Client, "ClientID", "ClientName", tbl_Order.ClientID);
            return View(tbl_Order);
        }

        // POST: tbl_Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,OrderDate,TotalAmount,ClientID")] tbl_Order tbl_Order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.tbl_Client, "ClientID", "ClientName", tbl_Order.ClientID);
            return View(tbl_Order);
        }

        // GET: tbl_Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Order tbl_Order = db.tbl_Order.Find(id);
            if (tbl_Order == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Order);
        }

        // POST: tbl_Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Order tbl_Order = db.tbl_Order.Find(id);
            db.tbl_Order.Remove(tbl_Order);
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
