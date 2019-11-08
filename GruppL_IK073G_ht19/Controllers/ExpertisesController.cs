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
    public class ExpertisesController : Controller
    {
        private gruppldbEntities1 db = new gruppldbEntities1();

        // GET: Expertises
        public ActionResult Index()
        {
            var expertises = db.Expertises.Include(e => e.Competences);
            return View(expertises.ToList());
        }

        // GET: Expertises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expertises expertises = db.Expertises.Find(id);
            if (expertises == null)
            {
                return HttpNotFound();
            }
            return View(expertises);
        }

        // GET: Expertises/Create
        public ActionResult Create()
        {
            ViewBag.Competence_id = new SelectList(db.Competences, "Competence_id", "Competence");
            return View();
        }

        // POST: Expertises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Expertise_id,Competence_id,Competence")] Expertises expertises)
        {
            if (ModelState.IsValid)
            {
                db.Expertises.Add(expertises);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Competence_id = new SelectList(db.Competences, "Competence_id", "Competence", expertises.Competence_id);
            return View(expertises);
        }

        // GET: Expertises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expertises expertises = db.Expertises.Find(id);
            if (expertises == null)
            {
                return HttpNotFound();
            }
            ViewBag.Competence_id = new SelectList(db.Competences, "Competence_id", "Competence", expertises.Competence_id);
            return View(expertises);
        }

        // POST: Expertises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Expertise_id,Competence_id,Competence")] Expertises expertises)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expertises).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit/1");
            }
            ViewBag.Competence_id = new SelectList(db.Competences, "Competence_id", "Competence", expertises.Competence_id);
            return View(expertises);
        }

        // GET: Expertises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expertises expertises = db.Expertises.Find(id);
            if (expertises == null)
            {
                return HttpNotFound();
            }
            return View(expertises);
        }

        // POST: Expertises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Expertises expertises = db.Expertises.Find(id);
            db.Expertises.Remove(expertises);
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
//    public class ExpertisesController : Controller
//    {
//        private gruppldbEntities1 db = new gruppldbEntities1();

//        // GET: Expertises
//        public ActionResult Index()
//        {
//            var expertises = db.Expertises.Include(e => e.Competences);
//            return View(expertises.ToList());
//        }

//        // GET: Expertises/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Expertises expertises = db.Expertises.Find(id);
//            if (expertises == null)
//            {
//                return HttpNotFound();
//            }
//            return View(expertises);
//        }

//        // GET: Expertises/Create
//        public ActionResult Create()
//        {
//            ViewBag.Competence_id = new SelectList(db.Competences, "Competence_id", "Competence");
//            return View();
//        }

//        // POST: Expertises/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "Expertise_id,Competence_id,Expertise")] Expertises expertises)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Expertises.Add(expertises);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            ViewBag.Competence_id = new SelectList(db.Competences, "Competence_id", "Competence", expertises.Competence_id);
//            return View(expertises);
//        }

//        // GET: Expertises/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Expertises expertises = db.Expertises.Find(id);
//            if (expertises == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.Competence_id = new SelectList(db.Competences, "Competence_id", "Competence", expertises.Competence_id);
//            return View(expertises);
//        }

//        // POST: Expertises/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "Expertise_id,Competence_id,Expertise")] Expertises expertises)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(expertises).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            ViewBag.Competence_id = new SelectList(db.Competences, "Competence_id", "Competence", expertises.Competence_id);
//            return View(expertises);
//        }

//        // GET: Expertises/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Expertises expertises = db.Expertises.Find(id);
//            if (expertises == null)
//            {
//                return HttpNotFound();
//            }
//            return View(expertises);
//        }

//        // POST: Expertises/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            Expertises expertises = db.Expertises.Find(id);
//            db.Expertises.Remove(expertises);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
