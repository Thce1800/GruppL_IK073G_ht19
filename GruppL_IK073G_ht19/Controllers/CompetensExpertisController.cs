using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GruppL_IK073G_ht19.ViewModels;
using GruppL_IK073G_ht19.Models;

namespace GruppL_IK073G_ht19.Controllers
{
    public class CompetensExpertisController : Controller
    {

        // GET: CompetensExpertis
        public ActionResult Index(int id)
        {
             gruppldbEntities1 db = new gruppldbEntities1();

        
            List<PECViewModel> PersonExpertisListTest = new List<PECViewModel>();

            var personlist = (from person in db.Persons
                              join expertisPerson in db.Person_Expertise on person.Person_id equals
                              expertisPerson.Person_id into table1
                              where person.Person_id==id
                              from expertisPerson in table1.DefaultIfEmpty()

                              join expertis in db.Expertises on expertisPerson.Expertise_id equals
                              expertis.Expertise_id into table2
                              where expertisPerson.Person_id==id
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
                PECViewModel objPEvmTest = new PECViewModel();
                objPEvmTest.FirstName = item.FirstName;
                objPEvmTest.LastName = item.LastName;
                objPEvmTest.Expertise = item.Expertise;
                objPEvmTest.Competence = item.Competence;
                objPEvmTest.Grade = item.Grade;
                PersonExpertisListTest.Add(objPEvmTest);
            }
            return View(PersonExpertisListTest);
        }
    }
}