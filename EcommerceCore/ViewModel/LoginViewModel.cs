using System;
using System.ComponentModel.DataAnnotations;

namespace EcommerceCore.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter your Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your Password")]
        [StringLength(10)]
        public string Password { get; set; }
    }
}
