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
        public string ConfirmPassword { get; set; }
    }

    public class tblMemberMetadata
    {
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[A-Za-z\s]{1,}[\.]{0,1}[A-Za-z\s]{0,}$", ErrorMessage = "Please enter valid name")]
        public string Name { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = @"{0:dd/MM/yyyy}" )]
        public System.DateTime DateOfBirth { get; set; }

        [Display(Name="Mobile Number")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile Number must of 10 digits number only")]
        public decimal MobileNo { get; set; }

        [Display(Name= "City")]
        public int CityId { get; set; }

        [Display(Name= "Religion")]
        public int ReligionId { get; set; }

        [Display(Name= "Height in Kgs")]
        public int HeightId { get; set; }

        [Display(Name= "Mother tongue")]
        public int MotherTongueId { get; set; }

        [Display(Name= "Caste")]
        public int CasteId { get; set; }

        [Display(Name="Gender")]
        public int GenderId { get; set; }

        [Display(Name= "Skin Tone")]
        public int SkinToneId { get; set; }

        [Display(Name = "Body Type")]
        public Nullable<int> BodyTypeId { get; set; }

        [Display(Name = "Body Weight")]
        [Range(20,100)]
        public Nullable<int> BodyWeight { get; set; }

        [Display(Name = "Diet")]
        public Nullable<int> DietId { get; set; }

        [Display(Name = "Annual Income")]
        public int AnnualIncomeId { get; set; }

        [Display(Name = "Zodiac Sign")]
        public Nullable<int> ZodiacSignId { get; set; }

        [Display(Name = "About Myself")]
        [Required]
        public string AboutMyself { get; set; }

    }
}