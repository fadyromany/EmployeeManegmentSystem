using EmployeeManegmentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManegmentSystem.View_Models
{ 
    public class EmployeeEditVM : EmployeeCreateVM
    {
        public int Id { get; set; }
        public string Existingphotopath { get; set; }
    }
}
