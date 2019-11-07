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
        public ActionResult Index()
        {
            //gruppldbEntities1 db = new gruppldbEntities1();

            //List<Person_Expertise> personExpertises = new List<Person_Expertise>();
            //PersonExpertiseCompetensViewModel pECVM = new PersonExpertiseCompetensViewModel();

            //List <PersonExpertiseCompetensViewModel> pECVMs = personExpertises.Select(x => new PersonExpertiseCompetensViewModel 
            //{ Competence=x.}
            //)
            return View();
        }
    }
}