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
    public class PersonsController : Controller
    {
        private gruppldbEntities1 db = new gruppldbEntities1();

        // GET: Persons
        public ActionResult Index()
        {
            return View(db.Persons.ToList());
        }

        // GET: Persons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persons persons = db.Persons.Find(id);
            if (persons == null)
            {
                return HttpNotFound();
            }
            return View(persons);
        }

        // GET: Persons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Persons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Person_id,FirstName,LastName,Adress,Phonenumber,Email,Birthdate,Nationality,Driver_license,Profile_text")] Persons persons)
        {
            if (ModelState.IsValid)
            {
                db.Persons.Add(persons);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(persons);
        }

        // GET: Persons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persons persons = db.Persons.Find(id);
            if (persons == null)
            {
                return HttpNotFound();
            }
            return View(persons);
        }

        // POST: Persons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Person_id,FirstName,LastName,Adress,Phonenumber,Email,Birthdate,Nationality,Driver_license,Profile_text")] Persons persons)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persons).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(persons);
        }

        // GET: Persons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persons persons = db.Persons.Find(id);
            if (persons == null)
            {
                return HttpNotFound();
            }
            return View(persons);
        }

        // POST: Persons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Persons persons = db.Persons.Find(id);
            db.Persons.Remove(persons);
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
