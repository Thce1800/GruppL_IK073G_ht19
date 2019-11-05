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
        public ActionResult Index()
        {
            //Kan man joina två tabeller till i denna metod??
            List<PersonExpertisVM> PersonExpertisList = new List<PersonExpertisVM>();

            var personlist = (from person in db.Persons //HÄMTAR FRÅN TABELLEN PERSON
                              join expertisPerson in db.Person_Expertise on person.Person_id equals
                              expertisPerson.Person_id into table1
                              from expertisPerson in table1.DefaultIfEmpty()
                              join expertis in db.Expertises on expertisPerson.Expertise_id equals
                              expertis.Expertise_id into table2
                              from expertis in table2.DefaultIfEmpty()

                              select new
                              {
                                  person.FirstName,
                                  person.LastName,
                                  expertis.Expertise
                              }).ToList();
            foreach(var item in personlist)
            {
                PersonExpertisVM objPEvm = new PersonExpertisVM();
                objPEvm.FirstName = item.FirstName;
                objPEvm.LastName = item.LastName;
                objPEvm.Expertis = item.Expertise;
                PersonExpertisList.Add(objPEvm);
            }


            return View(PersonExpertisList);
        }
    }
}