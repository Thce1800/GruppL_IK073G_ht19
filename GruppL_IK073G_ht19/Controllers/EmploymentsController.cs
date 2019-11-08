using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GruppL_IK073G_ht19.Models;

namespace GruppL_IK073G_ht19.Controllers
{
    public class EmploymentsController : Controller
    {
        private gruppldbEntities1 db = new gruppldbEntities1();

        // GET: Employments
        public ActionResult Index()
        {
            var employments = db.Employments.Include(e => e.Persons);
            return View(employments.ToList());
        }

        // GET: Employments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employments employments = db.Employments.Find(id);
            if (employments == null)
            {
                return HttpNotFound();
            }
            return View(employments);
        }

        // GET: Employments/Create
        public ActionResult Create()
        {
            ViewBag.Person_Id = new SelectList(db.Persons, "Person_id", "FirstName");
            return View();
        }

        // POST: Employments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Employment_id,Person_Id,End_date,Start_date,Assignments")] Employments employments)
        {
            if (ModelState.IsValid)
            {
                db.Employments.Add(employments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Person_Id = new SelectList(db.Persons, "Person_id", "FirstName", employments.Person_Id);
            return View(employments);
        }

        // GET: Employments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employments employments = db.Employments.Find(id);
            if (employments == null)
            {
                return HttpNotFound();
            }
            ViewBag.Person_Id = new SelectList(db.Persons, "Person_id", "FirstName", employments.Person_Id);
            return View(employments);
        }

        // POST: Employments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Employment_id,Person_Id,End_date,Start_date,Assignments")] Employments employments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit/1");
            }
            ViewBag.Person_Id = new SelectList(db.Persons, "Person_id", "FirstName", employments.Person_Id);
            return View(employments);
        }

        // GET: Employments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employments employments = db.Employments.Find(id);
            if (employments == null)
            {
                return HttpNotFound();
            }
            return View(employments);
        }

        // POST: Employments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employments employments = db.Employments.Find(id);
            db.Employments.Remove(employments);
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
