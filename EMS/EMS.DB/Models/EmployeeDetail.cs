using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EMS.DB.Models
{
    public class EmployeeDetail
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "FIRSTNAME_IS_REQUIRED")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LASTNAME_IS_REQUIRED")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "EMPLOYEENUMBER_IS_REQUIRED")]
        public string Uid { get; set; }

        [Required(ErrorMessage = "EMAIL_IS_REQUIRED")]
        [EmailAddress(ErrorMessage = "EMAIL_FORMAT_IS_INCORRECT")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "MOBILENUMBER_IS_REQUIRED_AND_GREATER_THAN_10")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "MOBILENUMBER_FORMAT_IS_INCORRECT")]
        public long MobileNumber { get; set; }

        [Required(ErrorMessage = "DATE_OF_BIRTH_IS_REQUIRED")]
        public string Dob { get; set; }

        [Required(ErrorMessage = "JOININGDATE_IS_REQUIRED")]
        public string JoiningDate { get; set; }
        public string? Location { get; set; }
        public string? Role { get; set; }
        public string? Department { get; set; }
        public string Manager { get; set; } = null!;
        public string? Project { get; set; }
        public bool IsActive{get;set;}

        public string ModelStatus{get;set;}
    }
}