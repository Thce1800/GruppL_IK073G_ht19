using GruppL_IK073G_ht19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GruppL_IK073G_ht19.ViewModels
{
    public class PersonExpertisVM
    {
        //REPRESENTERA VÄRDEN FRÅN BÅDE PERSON OCH EXPERTIS
        //FRÅN PERSON
        public string FirstName { get; set;}
        public string LastName { get; set; }
        //FRÅN EXPETIS
        public string Expertis { get; set; }
        public List<Expertises> Expertislist { get; set; }
        //FRÅN COMPETENCE
        public string Competence { get; set; }
        public SelectList DropDownList { get; set; }

    }
}