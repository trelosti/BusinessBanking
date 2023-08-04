using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessBanking.Domain.DTO
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Enter login")]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
