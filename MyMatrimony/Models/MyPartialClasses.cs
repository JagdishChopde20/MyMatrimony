using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyMatrimony.Models
{
    [MetadataType(typeof(tblMemberMetadata))]
    public partial class tblMember
    {
    }

    public class tblMemberMetadata
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Password { get; set; }
        public string Name { get; set; }

        [Display(Name = "Date Of Birth")]
        public System.DateTime DateOfBirth { get; set; }

        [Display(Name="Mobile Number")]
        public decimal MobileNo { get; set; }

        [Display(Name= "City")]
        public int CityId { get; set; }

        [Display(Name= "Religion")]
        public int ReligionId { get; set; }

        [Display(Name= "Height")]
        public int HeightId { get; set; }

        [Display(Name= "Mother tongue")]
        public int MotherTongueId { get; set; }

        [Display(Name= "Caste")]
        public int CasteId { get; set; }

        [Display(Name="Gender")]
        public int GenderId { get; set; }
    }
}