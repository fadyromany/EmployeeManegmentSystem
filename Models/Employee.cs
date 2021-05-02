using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManegmentSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50 ,ErrorMessage ="Thats Name Length Not VALIED!")]
        public string Name { get; set; }
        [Required]
        public DeptEnum  Department { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",ErrorMessage ="Invalid Email Format !")]
        public string Email { get; set; }
    }
}
