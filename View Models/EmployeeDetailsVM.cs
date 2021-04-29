using EmployeeManegmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManegmentSystem.View_Models
{
    public class EmployeeDetailsVM
    {
        public Employee Employee { get; set; }
        public string PageTitle { get; set; }
    }
}
