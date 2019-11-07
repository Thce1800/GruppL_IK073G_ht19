using GruppL_IK073G_ht19.Models;
using GruppL_IK073G_ht19.ViewModels;
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
        List<Educations> educations = new List<Educations>();
        List<Expertises> expertises = new List<Expertises>();
        List<Person_Expertise> personExpertises = new List<Person_Expertise>();
        List<Competences> competences = new List<Competences>();



        public PersonsOperation()
        {
            employments = db.Employments.ToList();
            educations = db.Educations.ToList();
            //expertise = db.Expertises.ToList();
            personExpertises = db.Person_Expertise.ToList();
            competences = db.Competences.ToList();
        }


        public List <Employments> FindEmployment(int? id)
        {
            var employmentsId = employments.Where(s => s.Person_Id == id).ToList();
            return employmentsId;
        }

        public List <Educations> Educations(int? id)
        {
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
            var personExpertisesId = personExpertises.Where(s => s.Person_id == id).ToList();

            return personExpertisesId;
        }



        public void Test()
        {
            //Kan man joina två tabeller till i denna metod??
            //List<string> expertiseList;

            //var competenceList = (from person in db.Persons //HÄMTAR FRÅN TABELLEN PERSON
            //                  join expertisPerson in db.Person_Expertise on person.Person_id equals
            //                  expertisPerson.Person_id into table1
            //                  from expertisPerson in table1.DefaultIfEmpty()
            //                  join expertis in db.Expertises on expertisPerson.Expertise_id equals
            //                  expertis.Expertise_id into table2
            //                  from expertis in table2.DefaultIfEmpty()

            //                  select new
            //                  {
            //                      person.FirstName,
            //                      person.LastName,
            //                      expertis.Expertise
            //                  }).ToList();
            //foreach (var item in expertiseList)
            //{
            //    string add = new string;
            //    add.FirstName = item.FirstName;
            //    objPEvm.LastName = item.LastName;
            //    objPEvm.Expertis = item.Expertise;
            //    PersonExpertisList.Add(objPEvm);
            //}

        }




        public List<Languages> Languages(int? id)
        {
            var languages = db.Languages.ToList();
            var languagesId = languages.Where(s => s.Person_id == id).ToList();

            return languagesId;
        }
    }
}