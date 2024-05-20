using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EMS.DB.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "EMAIL_IS_REQUIRED")]
        [EmailAddress(ErrorMessage = "EMAIL_FORMAT_IS_INCORRECT")]
        public string email { get; set; }

        [Required(ErrorMessage = "PASSWORD_IS_REQUIRED")]
        public string password { get; set; }
    }
}

