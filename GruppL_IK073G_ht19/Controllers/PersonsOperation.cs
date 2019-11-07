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
            expertises = db.Expertises.ToList();
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

        public List<Person_Expertise> PersonExpertises(int? id)
        {
            int i = 0;
            var personExpertisesId = personExpertises.Where(s => s.Person_id == id).ToList();

            return personExpertisesId;
        }

        public List<Competences> Competenses(int? id)
        {
            int i = 0;
            var personExpertisesId = personExpertises.Where(s => s.Person_id == id).ToList();

            var competencess = new List<Competences>();

            foreach (var item in personExpertisesId)
            {
                if (personExpertisesId[i].Expertise_id<=3)
                {
                    Competences competence = new Competences() { Competence_id=1, Competence="Programmerare"};
                    competencess.Add(competence);
                }
                if (personExpertisesId[i].Expertise_id >= 4 & personExpertisesId[i].Expertise_id <= 6)
                {
                    Competences competence = new Competences() { Competence_id = 1, Competence = "Grafiskdesigner" };
                    competencess.Add(competence);


                }
                if (personExpertisesId[i].Expertise_id >= 7 & personExpertisesId[i].Expertise_id <= 9)
                {
                    Competences competence = new Competences() { Competence_id = 1, Competence = "Projektledare" };
                    competencess.Add(competence);

                }
                i++;
            }

            return competencess;
        }

        public List<Languages> Languages(int? id)
        {
            var languages = db.Languages.ToList();
            var languagesId = languages.Where(s => s.Person_id == id).ToList();

            return languagesId;
        }

    }
}