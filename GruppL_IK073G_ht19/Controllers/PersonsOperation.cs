using GruppL_IK073G_ht19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GruppL_IK073G_ht19.Controllers
{
    public class PersonsOperation
    {
        private gruppldbEntities1 db = new gruppldbEntities1();

        List<Employments> employments = new List<Employments>();

        public List <Employments> FindEmployment(int? id)
        {
            employments = db.Employments.ToList();

            var employmentsa = employments.Where(s => s.Person_Id == id).ToList();
            return employmentsa;

        }
    }
}