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
    public class tbl_ServiceLineController : Controller
    {
        private laptopdbEntities db = new laptopdbEntities();

        // GET: tbl_ServiceLine
        public ActionResult Index()
        {
            var tbl_ServiceLine = db.tbl_ServiceLine.Include(t => t.tbl_Laptop).Include(t => t.tbl_Order).Include(t => t.tbl_Services);
            return View(tbl_ServiceLine.ToList());
        }

        // GET: tbl_ServiceLine/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ServiceLine tbl_ServiceLine = db.tbl_ServiceLine.Find(id);
            if (tbl_ServiceLine == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ServiceLine);
        }

        // GET: tbl_ServiceLine/Create
        public ActionResult Create()
        {
            ViewBag.SerialNo = new SelectList(db.tbl_Laptop, "SerialNo", "Model");
            ViewBag.OrderID = new SelectList(db.tbl_Order, "OrderID", "OrderID");
            ViewBag.ServiceID = new SelectList(db.tbl_Services, "ServiceID", "ServiceName");
            return View();
        }

        // POST: tbl_ServiceLine/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServiceNumber,Quantity,TotalServicePrice,ServiceDate,ServiceID,OrderID,SerialNo")] tbl_ServiceLine tbl_ServiceLine)
        {
            if (ModelState.IsValid)
            {
                db.tbl_ServiceLine.Add(tbl_ServiceLine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SerialNo = new SelectList(db.tbl_Laptop, "SerialNo", "Model", tbl_ServiceLine.SerialNo);
            ViewBag.OrderID = new SelectList(db.tbl_Order, "OrderID", "OrderID", tbl_ServiceLine.OrderID);
            ViewBag.ServiceID = new SelectList(db.tbl_Services, "ServiceID", "ServiceName", tbl_ServiceLine.ServiceID);
            return View(tbl_ServiceLine);
        }

        // GET: tbl_ServiceLine/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ServiceLine tbl_ServiceLine = db.tbl_ServiceLine.Find(id);
            if (tbl_ServiceLine == null)
            {
                return HttpNotFound();
            }
            ViewBag.SerialNo = new SelectList(db.tbl_Laptop, "SerialNo", "Model", tbl_ServiceLine.SerialNo);
            ViewBag.OrderID = new SelectList(db.tbl_Order, "OrderID", "OrderID", tbl_ServiceLine.OrderID);
            ViewBag.ServiceID = new SelectList(db.tbl_Services, "ServiceID", "ServiceName", tbl_ServiceLine.ServiceID);
            return View(tbl_ServiceLine);
        }

        // POST: tbl_ServiceLine/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServiceNumber,Quantity,TotalServicePrice,ServiceDate,ServiceID,OrderID,SerialNo")] tbl_ServiceLine tbl_ServiceLine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_ServiceLine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SerialNo = new SelectList(db.tbl_Laptop, "SerialNo", "Model", tbl_ServiceLine.SerialNo);
            ViewBag.OrderID = new SelectList(db.tbl_Order, "OrderID", "OrderID", tbl_ServiceLine.OrderID);
            ViewBag.ServiceID = new SelectList(db.tbl_Services, "ServiceID", "ServiceName", tbl_ServiceLine.ServiceID);
            return View(tbl_ServiceLine);
        }

        // GET: tbl_ServiceLine/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_ServiceLine tbl_ServiceLine = db.tbl_ServiceLine.Find(id);
            if (tbl_ServiceLine == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ServiceLine);
        }

        // POST: tbl_ServiceLine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_ServiceLine tbl_ServiceLine = db.tbl_ServiceLine.Find(id);
            db.tbl_ServiceLine.Remove(tbl_ServiceLine);
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
