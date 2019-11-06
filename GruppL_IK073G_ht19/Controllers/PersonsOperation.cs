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

            var employmentsId = employments.Where(s => s.Person_Id == id).ToList();
            return employmentsId;

        }

        public List <Educations> Educations(int? id)
        {
            var educations = db.Educations.ToList();

            var educationsId = educations.Where(s => s.Person_ID == id).ToList();

            return educationsId;

        }

        public List <key_abilitiy> KeyAbilitiys(int? id)
        {
            var keyAbilitiys = db.key_abilitiy.ToList();

            var keyAbilitysId = keyAbilitiys.Where(s => s.person_id == id).ToList();
            return keyAbilitysId;
        }

        public List <Person_Expertise> PersonExpertises(int? id)
        {
            var personExpertises = db.Person_Expertise.ToList();
            var personExpertisesId = personExpertises.Where(s => s.Person_id == id).ToList();
            //Inte klar
            return personExpertisesId;

        }

        //public List <Languages> Languages(int? id)
        //{
        //    var languages = db.Languages.ToList();
        //    var languagesId=languages.Where(s=>s.Persons)
        //}
    }
}