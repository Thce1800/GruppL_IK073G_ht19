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
    public class CompetencesController : Controller
    {
        private gruppldbEntities1 db = new gruppldbEntities1();

        // GET: Competences
        public ActionResult Index()
        {
            return View(db.Competences.ToList());
        }

        // GET: Competences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competences competences = db.Competences.Find(id);
            if (competences == null)
            {
                return HttpNotFound();
            }
            return View(competences);
        }

        // GET: Competences/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Competences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Competence_id,Competence")] Competences competences)
        {
            if (ModelState.IsValid)
            {
                db.Competences.Add(competences);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(competences);
        }

        // GET: Competences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competences competences = db.Competences.Find(id);
            if (competences == null)
            {
                return HttpNotFound();
            }
            return View(competences);
        }

        // POST: Competences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Competence_id,Competence")] Competences competences)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competences).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(competences);
        }

        // GET: Competences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competences competences = db.Competences.Find(id);
            if (competences == null)
            {
                return HttpNotFound();
            }
            return View(competences);
        }

        // POST: Competences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Competences competences = db.Competences.Find(id);
            db.Competences.Remove(competences);
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
