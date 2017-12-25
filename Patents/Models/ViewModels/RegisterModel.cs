using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Patents.Models.ViewModels
{
    public class RegisterModel
    {
        [Required]
        [Display(Name = "Full name")]
        [MinLength(5)]
        public string FullName { get; set; }


        [Required]
        [RegularExpression(@"^\w + ([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Invalid email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Password confirmation")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

        public Inventor ToInventor()
        {
            return new Inventor
            {
                Name = this.FullName,
                Adress = this.Address,
                Password = this.Password,
                Email = this.Email
            };
        }
    }
}