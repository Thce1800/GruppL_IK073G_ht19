using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GruppL_IK073G_ht19.ViewModels
{
    public class PECViewModel
    {
        public int Person_id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Expertise_id { get; set; }
        public Nullable<int> Grade { get; set; }
        public int Competence_id { get; set; }
        public string Expertise { get; set; }
        public string Competence { get; set; }

        public int Id { get; set; }
    }
}