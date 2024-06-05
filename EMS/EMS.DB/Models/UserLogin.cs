using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EMS.DB.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "EMAIL IS REQUIRED")]
        [EmailAddress(ErrorMessage = "EMAIL FORMAT IS INCORRECT")]
        public string email { get; set; }

        [Required(ErrorMessage = "PASSWORD IS REQUIRED")]
        public string password { get; set; }
    }
}

