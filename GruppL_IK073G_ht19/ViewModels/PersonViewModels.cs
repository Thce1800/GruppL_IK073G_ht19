﻿using GruppL_IK073G_ht19.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GruppL_IK073G_ht19.ViewModels
{
    public class PersonViewModels
    {
        public Persons Persons { get; set; }
        public List <Educations>  Educations { get; set; }
        public List <Employments> Employments { get; set; }
        public List <key_abilitiy> key_Abilitiys { get; set; }
        public List <Languages> Languages { get; set; }
        public List <Expertises> Expertises{ get; set; }
        public List <Competences> Competences { get; set; }
        public List <Person_Expertise> PersonExpertises { get; set; }
    }
}