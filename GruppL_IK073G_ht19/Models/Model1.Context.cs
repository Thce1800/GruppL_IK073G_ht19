﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GruppL_IK073G_ht19.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class gruppldbEntities1 : DbContext
    {
        public gruppldbEntities1()
            : base("name=gruppldbEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Competences> Competences { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Educations> Educations { get; set; }
        public virtual DbSet<Employments> Employments { get; set; }
        public virtual DbSet<Expertises> Expertises { get; set; }
        public virtual DbSet<Languages> Languages { get; set; }
        public virtual DbSet<Person_Expertise> Person_Expertise { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }
        public virtual DbSet<database_firewall_rules> database_firewall_rules { get; set; }
        public virtual DbSet<key_abilitiy> key_abilitiy { get; set; }
    }
}
