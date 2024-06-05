using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EMS.DAL
{
    public class RegisterDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "FIRSTNAME IS REQUIRED")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LASTNAME IS REQUIRED")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "EMPLOYEENUMBER IS REQUIRED")]
        public string Uid { get; set; }

        [Required(ErrorMessage = "EMAIL IS REQUIRED")]
        [EmailAddress(ErrorMessage = "EMAIL FORMAT IS INCORRECT")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "MOBILENUMBER IS REQUIRED AND GREATER THAN 10")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "MOBILENUMBER FORMAT IS INCORRECT")]
        public long MobileNumber { get; set; }

        [Required(ErrorMessage = "DATE OF BIRTH IS REQUIRED")]
        public string Dob { get; set; }

        [Required(ErrorMessage = "JOININGDATE IS REQUIRED")]
        public string JoiningDate { get; set; }

        public string? Location { get; set; }

        public string? Role { get; set; }

        public string? Department { get; set; }

        public string Manager { get; set; } = null!;

        public string? Project { get; set; }

        [Required(ErrorMessage = "PASSWORD IS REQUIRED")]
        public string Password { get; set; }

        public bool IsActive{get;set;}
        public string ModeStatus{get;set;}
        public string? ProfilePic{get;set;}
    }
}