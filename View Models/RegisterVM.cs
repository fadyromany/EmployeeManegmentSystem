using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManegmentSystem.View_Models
{
    public class RegisterVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")] // to use it to dispaly as a label in UI
        [Compare("Password",ErrorMessage ="password and confirmed password do not match .")]
        public string ConfirmPassword { get; set; }
    }
}
