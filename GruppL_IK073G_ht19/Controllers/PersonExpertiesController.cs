using GruppL_IK073G_ht19.Models;
using GruppL_IK073G_ht19.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GruppL_IK073G_ht19.Controllers
{
    public class PersonExpertiesController : Controller
    {
        private gruppldbEntities1 db = new gruppldbEntities1();
        // GET: PersonExperties
        public ActionResult Index(string sortOrder)
        {
            //Borde ligga i en modell
            List<PersonExpertisVM> PersonExpertisList = new List<PersonExpertisVM>();

            var personlist = (from person in db.Persons 
                              join expertisPerson in db.Person_Expertise on person.Person_id equals
                              expertisPerson.Person_id into table1
                              from expertisPerson in table1.DefaultIfEmpty()

                              join expertis in db.Expertises on expertisPerson.Expertise_id equals
                              expertis.Expertise_id into table2
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
                                  competense.Competence
                              }).ToList();
            foreach(var item in personlist)
            {
                PersonExpertisVM objPEvm = new PersonExpertisVM();
                objPEvm.FirstName = item.FirstName;
                objPEvm.LastName = item.LastName;
                objPEvm.Expertis = item.Expertise;
                objPEvm.Competence = item.Competence;
                PersonExpertisList.Add(objPEvm);
            }
            //JAG HAR JU RETURNERAT EN NY LISTA, få tillbaka den från viewn och sök genom den??
            return View(PersonExpertisList);
        }



        //SKRÄP
        [HttpGet]
        public ActionResult ListUser()
        {
            var users = db.Expertises.ToList();

            var viewModel = new PersonExpertisVM { Expertislist = users }; //ELLER DEN ANDRA VYMODELLEN

            return View(viewModel);
        }
        public List<Expertises> SearchPerson(int ? id) 
        {
            List<Expertises> person = new List<Expertises>();
            person = db.Expertises.ToList();
            var result = person.Where(s => s.Expertise_id == id).ToList();
            return result;

        }
        public ActionResult Test() //DENNA FUNGERAR I EN NY VIEW
        {
            ViewBag.Competence_id = new SelectList(db.Competences, "Competence_id", "Competence");

            return View();
        }
        public PartialViewResult Load()
        {
            return PartialView("_Filter");
        }
        public ActionResult GetList() 
        {
            var expertises = (from expertis in db.Expertises select expertis.Expertise).ToList();
            return View(expertises);
        }

        [HttpPost]
        public ActionResult GetList(Expertises model)
        {
            var data = db.Expertises.ToList();
            return View(data);
        }
    }
}