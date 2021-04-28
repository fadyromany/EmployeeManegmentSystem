using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManegmentSystem.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList; // constructor injection
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee(){Id=1,Name="emp1",Email="emp1@yahho.com",Department="HR"},
                new Employee(){Id=2,Name="emp2",Email="emp2@yahho.com",Department="IT"},
                new Employee(){Id=3,Name="emp3",Email="emp3@yahho.com",Department="HR"},
                new Employee(){Id=4,Name="emp4",Email="emp4@yahho.com",Department="IT"},
                new Employee(){Id=5,Name="emp5",Email="emp5@yahho.com",Department="HR"}
            };
        }
        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == id);
        }
    }
}
