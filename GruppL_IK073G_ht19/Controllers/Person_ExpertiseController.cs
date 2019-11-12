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
        public ActionResult Index(int? id)
        {
            List<PECViewModel> PersonExpertisListTest = new List<PECViewModel>();

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
                                  expertisPerson.Grade,
                                  expertis.Expertise_id,
                                  expertisPerson.Id

                              }).ToList();
            foreach (var item in personlist)
            {
                PECViewModel objPEvmTest = new PECViewModel();
                objPEvmTest.FirstName = item.FirstName;
                objPEvmTest.LastName = item.LastName;
                objPEvmTest.Expertise = item.Expertise;
                objPEvmTest.Competence = item.Competence;
                objPEvmTest.Grade = item.Grade;
                objPEvmTest.Expertise_id = item.Expertise_id;
                objPEvmTest.Person_id = item.Person_id;
                objPEvmTest.Id = item.Id;
                PersonExpertisListTest.Add(objPEvmTest);
            }
            return View(PersonExpertisListTest);

        }



        // GET: Person_Expertise/Create
        public ActionResult Create()//int? idcomp)
        {
            ViewBag.Person_id = new SelectList(db.Persons, "Person_id", "FirstName");
            ViewBag.Expertise_id = new SelectList(db.Expertises, "Expertise_id", "Expertise");
            ViewBag.Competence = new SelectList(db.Competences, "Competence_id", "Competence");
            return View();
        }

        public List <Expertises> Expertisess(int idcomp)
        {
            List<Expertises> expertises = new List<Expertises>();

            expertises = db.Expertises.ToList();

            var expertisess = expertises.Where(s => s.Competence_id == idcomp).ToList();

            return expertisess;
        }

        // POST: Person_Expertise/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Person_id,Expertise_id,Grade")] Person_Expertise person_Expertise)
        {
            int id = person_Expertise.Person_id;
            if (ModelState.IsValid)
            {
                db.Person_Expertise.Add(person_Expertise);
                db.SaveChanges();
                return RedirectToAction("Index", new {id});
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
            id = person_Expertise.Person_id;
            return RedirectToAction("Index", new { id });
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
