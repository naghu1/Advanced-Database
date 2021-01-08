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
    public class tbl_ClientController : Controller
    {
        private laptopdbEntities db = new laptopdbEntities();

        // GET: tbl_Client
        public ActionResult Index()
        {
            return View(db.tbl_Client.ToList());
        }

        // GET: tbl_Client/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Client tbl_Client = db.tbl_Client.Find(id);
            if (tbl_Client == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Client);
        }

        // GET: tbl_Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_Client/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientID,ClientName,ClientEmail_Address,ClientContact_no,Street,City,EIRCode,Feedback")] tbl_Client tbl_Client)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Client.Add(tbl_Client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Client);
        }

        // GET: tbl_Client/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Client tbl_Client = db.tbl_Client.Find(id);
            if (tbl_Client == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Client);
        }

        // POST: tbl_Client/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientID,ClientName,ClientEmail_Address,ClientContact_no,Street,City,EIRCode,Feedback")] tbl_Client tbl_Client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Client);
        }

        // GET: tbl_Client/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Client tbl_Client = db.tbl_Client.Find(id);
            if (tbl_Client == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Client);
        }

        // POST: tbl_Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Client tbl_Client = db.tbl_Client.Find(id);
            db.tbl_Client.Remove(tbl_Client);
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
