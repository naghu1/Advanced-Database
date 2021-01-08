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
    public class tbl_BranchController : Controller
    {
        private laptopdbEntities db = new laptopdbEntities();

        // GET: tbl_Branch
        public ActionResult Index()
        {
            return View(db.tbl_Branch.ToList());
        }

        // GET: tbl_Branch/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Branch tbl_Branch = db.tbl_Branch.Find(id);
            if (tbl_Branch == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Branch);
        }

        // GET: tbl_Branch/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_Branch/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BranchID,BranchName,Street,City,EIRCode")] tbl_Branch tbl_Branch)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Branch.Add(tbl_Branch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Branch);
        }

        // GET: tbl_Branch/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Branch tbl_Branch = db.tbl_Branch.Find(id);
            if (tbl_Branch == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Branch);
        }

        // POST: tbl_Branch/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BranchID,BranchName,Street,City,EIRCode")] tbl_Branch tbl_Branch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Branch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Branch);
        }

        // GET: tbl_Branch/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Branch tbl_Branch = db.tbl_Branch.Find(id);
            if (tbl_Branch == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Branch);
        }

        // POST: tbl_Branch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Branch tbl_Branch = db.tbl_Branch.Find(id);
            db.tbl_Branch.Remove(tbl_Branch);
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
