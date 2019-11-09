using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GruppL_IK073G_ht19.Models;
using GruppL_IK073G_ht19.ViewModels;

namespace GruppL_IK073G_ht19.Controllers
{
    public class Person_ExpertiseController : Controller
    {
        private gruppldbEntities1 db = new gruppldbEntities1();

        // GET: Person_Expertise
        public ActionResult Index(int id)
        {
            List<PersonExpertiseCompetensViewModel> PersonExpertisListTest = new List<PersonExpertiseCompetensViewModel>();

            var personlist = (from person in db.Persons
                              join expertisPerson in db.Person_Expertise on person.Person_id equals
                              expertisPerson.Person_id into table1
                              where person.Person_id == id
                              from expertisPerson in table1.DefaultIfEmpty()

                              join expertis in db.Expertises on expertisPerson.Expertise_id equals
                              expertis.Expertise_id into table2
                              where expertisPerson.Person_id == id
                              from expertis in table2.DefaultIfEmpty()

                              join competense in db.Competences on expertis.Competence_id equals
                              competense.Competence_id into table3
                              from competense in table3.DefaultIfEmpty()
                              select new
                              {
                                  person.Person_id,
                                  person.FirstName,
                                  person.LastName,
                                  expertis.Expertise,
                                  competense.Competence,
                                  expertisPerson.Grade

                              }).ToList();
            foreach (var item in personlist)
            {
                PersonExpertiseCompetensViewModel objPEvmTest = new PersonExpertiseCompetensViewModel();
                objPEvmTest.FirstName = item.FirstName;
                objPEvmTest.LastName = item.LastName;
                objPEvmTest.Expertise = item.Expertise;
                objPEvmTest.Competence = item.Competence;
                objPEvmTest.Grade = item.Grade;
                PersonExpertisListTest.Add(objPEvmTest);
            }
            //JAG HAR JU RETURNERAT EN NY LISTA, få tillbaka den från viewn och sök genom den??
            return View(PersonExpertisListTest);
        }

        // GET: Person_Expertise/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person_Expertise person_Expertise = db.Person_Expertise.Find(id);
            if (person_Expertise == null)
            {
                return HttpNotFound();
            }
            return View(person_Expertise);
        }

        // GET: Person_Expertise/Create
        public ActionResult Create(int id, int expertiseId)
        {
            ViewBag.Expertise_id = new SelectList(db.Expertises, "Expertise_id", "Expertise");
            ViewBag.Person_id = new SelectList(db.Persons, "Person_id", "FirstName");
            return View();
        }

        // POST: Person_Expertise/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Person_id,Expertise_id,Grade")] Person_Expertise person_Expertise)
        {
            if (ModelState.IsValid)
            {
                db.Person_Expertise.Add(person_Expertise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Expertise_id = new SelectList(db.Expertises, "Expertise_id", "Expertise", person_Expertise.Expertise_id);
            ViewBag.Person_id = new SelectList(db.Persons, "Person_id", "FirstName", person_Expertise.Person_id);
            return View(person_Expertise);
        }

        // GET: Person_Expertise/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person_Expertise person_Expertise = db.Person_Expertise.Find(id);
            if (person_Expertise == null)
            {
                return HttpNotFound();
            }
            ViewBag.Expertise_id = new SelectList(db.Expertises, "Expertise_id", "Expertise", person_Expertise.Expertise_id);
            ViewBag.Person_id = new SelectList(db.Persons, "Person_id", "FirstName", person_Expertise.Person_id);
            return View(person_Expertise);
        }

        // POST: Person_Expertise/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Person_id,Expertise_id,Grade")] Person_Expertise person_Expertise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person_Expertise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Expertise_id = new SelectList(db.Expertises, "Expertise_id", "Expertise", person_Expertise.Expertise_id);
            ViewBag.Person_id = new SelectList(db.Persons, "Person_id", "FirstName", person_Expertise.Person_id);
            return View(person_Expertise);
        }

        // GET: Person_Expertise/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person_Expertise person_Expertise = db.Person_Expertise.Find(id);
            if (person_Expertise == null)
            {
                return HttpNotFound();
            }
            return View(person_Expertise);
        }

        // POST: Person_Expertise/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person_Expertise person_Expertise = db.Person_Expertise.Find(id);
            db.Person_Expertise.Remove(person_Expertise);
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
