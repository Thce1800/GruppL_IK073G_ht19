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
    public class key_abilitiyController : Controller
    {
        private gruppldbEntities1 db = new gruppldbEntities1();

        // GET: key_abilitiy
        public ActionResult Index()
        {
            var key_abilitiy = db.key_abilitiy.Include(k => k.Persons);
            return View(key_abilitiy.ToList());
        }

        // GET: key_abilitiy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            key_abilitiy key_abilitiy = db.key_abilitiy.Find(id);
            if (key_abilitiy == null)
            {
                return HttpNotFound();
            }
            return View(key_abilitiy);
        }

        // GET: key_abilitiy/Create
        public ActionResult Create()
        {
            ViewBag.person_id = new SelectList(db.Persons, "Person_id", "FirstName");
            return View();
        }

        // POST: key_abilitiy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "key_abilitiy_id,person_id,abilitiy")] key_abilitiy key_abilitiy)
        {
            if (ModelState.IsValid)
            {
                db.key_abilitiy.Add(key_abilitiy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.person_id = new SelectList(db.Persons, "Person_id", "FirstName", key_abilitiy.person_id);
            return View(key_abilitiy);
        }

        // GET: key_abilitiy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            key_abilitiy key_abilitiy = db.key_abilitiy.Find(id);
            if (key_abilitiy == null)
            {
                return HttpNotFound();
            }
            ViewBag.person_id = new SelectList(db.Persons, "Person_id", "FirstName", key_abilitiy.person_id);
            return View(key_abilitiy);
        }

        // POST: key_abilitiy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "key_abilitiy_id,person_id,abilitiy")] key_abilitiy key_abilitiy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(key_abilitiy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit/1");
            }
            ViewBag.person_id = new SelectList(db.Persons, "Person_id", "FirstName", key_abilitiy.person_id);
            return View(key_abilitiy);
        }

        // GET: key_abilitiy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            key_abilitiy key_abilitiy = db.key_abilitiy.Find(id);
            if (key_abilitiy == null)
            {
                return HttpNotFound();
            }
            return View(key_abilitiy);
        }

        // POST: key_abilitiy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            key_abilitiy key_abilitiy = db.key_abilitiy.Find(id);
            db.key_abilitiy.Remove(key_abilitiy);
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
