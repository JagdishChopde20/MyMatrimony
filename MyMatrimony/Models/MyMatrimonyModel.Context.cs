﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyMatrimony.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MyMatrimonyDBEntities : DbContext
    {
        public MyMatrimonyDBEntities()
            : base("name=MyMatrimonyDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblCasteMaster> tblCasteMasters { get; set; }
        public virtual DbSet<tblCityMaster> tblCityMasters { get; set; }
        public virtual DbSet<tblGenderMaster> tblGenderMasters { get; set; }
        public virtual DbSet<tblHeightMaster> tblHeightMasters { get; set; }
        public virtual DbSet<tblMember> tblMembers { get; set; }
        public virtual DbSet<tblMotherTongueMaster> tblMotherTongueMasters { get; set; }
        public virtual DbSet<tblReligionMaster> tblReligionMasters { get; set; }
        public virtual DbSet<tblSkinToneMaster> tblSkinToneMasters { get; set; }
        public virtual DbSet<tblAnnualIncomeMaster> tblAnnualIncomeMasters { get; set; }
        public virtual DbSet<tblBodyTypeMaster> tblBodyTypeMasters { get; set; }
        public virtual DbSet<tblDietMaster> tblDietMasters { get; set; }
        public virtual DbSet<tblZodiacSign> tblZodiacSigns { get; set; }
    
        public virtual ObjectResult<spGetMemberById_Result> spGetMemberById(Nullable<int> memberId)
        {
            var memberIdParameter = memberId.HasValue ?
                new ObjectParameter("MemberId", memberId) :
                new ObjectParameter("MemberId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spGetMemberById_Result>("spGetMemberById", memberIdParameter);
        }
    }
}
