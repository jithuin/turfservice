﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TurfManagement
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Model1Container : DbContext
    {
        public Model1Container()
            : base("name=Model1Container")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TurfUser> TurfUsers { get; set; }
        public virtual DbSet<TurfMaster> TurfMasters { get; set; }
        public virtual DbSet<TurfGroup> TurfGroups { get; set; }
        public virtual DbSet<TypeofTurf> TypeofTurfs { get; set; }
        public virtual DbSet<TurfFecilityMaster> TurfFecilityMasters { get; set; }
        public virtual DbSet<TurfMedia> TurfMedias { get; set; }
        public virtual DbSet<TurfBooking> TurfBookings { get; set; }
        public virtual DbSet<TurfFacilityList> TurfFacilityLists { get; set; }
        public virtual DbSet<TurfBookingFacilityList> TurfBookingFacilityLists { get; set; }
    }
}