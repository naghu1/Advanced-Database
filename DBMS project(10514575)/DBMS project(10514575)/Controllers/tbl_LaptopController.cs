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
    public class tbl_LaptopController : Controller
    {
        private laptopdbEntities db = new laptopdbEntities();

        // GET: tbl_Laptop
        public ActionResult Index()
        {
            var tbl_Laptop = db.tbl_Laptop.Include(t => t.tbl_Client);
            return View(tbl_Laptop.ToList());
        }

        // GET: tbl_Laptop/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Laptop tbl_Laptop = db.tbl_Laptop.Find(id);
            if (tbl_Laptop == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Laptop);
        }

        // GET: tbl_Laptop/Create
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.tbl_Client, "ClientID", "ClientName");
            return View();
        }

        // POST: tbl_Laptop/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SerialNo,Model,Company,ClientID")] tbl_Laptop tbl_Laptop)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Laptop.Add(tbl_Laptop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.tbl_Client, "ClientID", "ClientName", tbl_Laptop.ClientID);
            return View(tbl_Laptop);
        }

        // GET: tbl_Laptop/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Laptop tbl_Laptop = db.tbl_Laptop.Find(id);
            if (tbl_Laptop == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.tbl_Client, "ClientID", "ClientName", tbl_Laptop.ClientID);
            return View(tbl_Laptop);
        }

        // POST: tbl_Laptop/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SerialNo,Model,Company,ClientID")] tbl_Laptop tbl_Laptop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Laptop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.tbl_Client, "ClientID", "ClientName", tbl_Laptop.ClientID);
            return View(tbl_Laptop);
        }

        // GET: tbl_Laptop/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Laptop tbl_Laptop = db.tbl_Laptop.Find(id);
            if (tbl_Laptop == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Laptop);
        }

        // POST: tbl_Laptop/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Laptop tbl_Laptop = db.tbl_Laptop.Find(id);
            db.tbl_Laptop.Remove(tbl_Laptop);
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
