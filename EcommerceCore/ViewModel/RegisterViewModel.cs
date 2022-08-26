using System;
using System.ComponentModel.DataAnnotations;

namespace EcommerceCore.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please enter your Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
         ErrorMessage = "Characters are not allowed.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your Password")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{6,}$",
         ErrorMessage = "Characters are not allowed.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please enter your full name")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Please enter your phone")]
        [StringLength(11)]
        public string Phone { get; set; }
    }
}
