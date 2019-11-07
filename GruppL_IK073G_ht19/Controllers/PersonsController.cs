using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using GruppL_IK073G_ht19.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using System.Text;
using iTextSharp.text.html.simpleparser;
using GruppL_IK073G_ht19.ViewModels;

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

        public ActionResult CIndex()
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
            PersonsOperation p = new PersonsOperation();
            var viewModel = new PersonViewModels
            {
                Persons = persons,
                Educations=p.Educations(id),
                Employments = p.FindEmployment(id),
                key_Abilitiys=p.KeyAbilitiys(id),
                PersonExpertises=p.PersonExpertises(id),
                Languages=p.Languages(id),
                Competences=p.Competenses(id)
            };


            return View(viewModel);
        }

        public ActionResult CDetails(int? id)
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
            PersonsOperation p = new PersonsOperation();
            var viewModel = new PersonViewModels
            {
                Persons = persons,
                Educations = p.Educations(id),
                Employments = p.FindEmployment(id),
                key_Abilitiys = p.KeyAbilitiys(id),
                PersonExpertises = p.PersonExpertises(id),
                Languages = p.Languages(id)

            };


            return View(viewModel);
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
            //Educations educations = db.Educations

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

        //Exportera till PDF
        [HttpPost]
        [ValidateInput(false)]
        public FileResult Export(string pdfHtml)
        {
           // var cssText = "~/Content/Site.css"
            using (MemoryStream stream = new System.IO.MemoryStream())
            {
                StringReader sr = new StringReader(pdfHtml);
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                return File(stream.ToArray(), "application/pdf", "Grid.pdf");
            }
        }


    }
}
