using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EMS.DAL
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Uid { get; set; }

        [EmailAddress(ErrorMessage = "EMAIL_FORMAT_IS_INCORRECT")]
        public string? EmailId { get; set; }
        public long? MobileNumber { get; set; }
        public string? Dob { get; set; }
        public string? JoiningDate { get; set; }
        public string? Location { get; set; }
        public string? Role { get; set; }
        public string? Department { get; set; }
        public string? Manager { get; set; } = null!;
        public string? Project { get; set; }
        public bool IsActive { get; set; }
        public string ModelStatus { get; set; }
    }
}