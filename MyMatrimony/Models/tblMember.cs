//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class tblMember
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string MobileNo { get; set; }
        public int CityId { get; set; }
        public int ReligionId { get; set; }
        public int HeightId { get; set; }
        public int MotherTongueId { get; set; }
        public int CasteId { get; set; }
        public int GenderId { get; set; }
        public int SkinToneId { get; set; }
        public Nullable<int> BodyTypeId { get; set; }
        public Nullable<int> DietId { get; set; }
        public Nullable<bool> Drink { get; set; }
        public Nullable<bool> Smoke { get; set; }
        public string Education { get; set; }
        public int AnnualIncomeId { get; set; }
        public string Occupation { get; set; }
        public string Hobbies { get; set; }
        public string AboutMyself { get; set; }
        public Nullable<int> ZodiacSignId { get; set; }
        public Nullable<int> BodyWeight { get; set; }
        public Nullable<System.DateTime> LastOnline { get; set; }
    
        public virtual tblCasteMaster tblCasteMaster { get; set; }
        public virtual tblCityMaster tblCityMaster { get; set; }
        public virtual tblGenderMaster tblGenderMaster { get; set; }
        public virtual tblHeightMaster tblHeightMaster { get; set; }
        public virtual tblMotherTongueMaster tblMotherTongueMaster { get; set; }
        public virtual tblReligionMaster tblReligionMaster { get; set; }
        public virtual tblSkinToneMaster tblSkinToneMaster { get; set; }
        public virtual tblAnnualIncomeMaster tblAnnualIncomeMaster { get; set; }
        public virtual tblBodyTypeMaster tblBodyTypeMaster { get; set; }
        public virtual tblDietMaster tblDietMaster { get; set; }
        public virtual tblZodiacSign tblZodiacSign { get; set; }
    }
}
