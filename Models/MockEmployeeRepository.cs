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
                new Employee(){Id=1,Name="emp1",Email="emp1@yahho.com",Department=DeptEnum.HR},
                new Employee(){Id=2,Name="emp2",Email="emp2@yahho.com",Department=DeptEnum.IT},
                new Employee(){Id=3,Name="emp3",Email="emp3@yahho.com",Department=DeptEnum.HR},
                new Employee(){Id=4,Name="emp4",Email="emp4@yahho.com",Department=DeptEnum.IT},
                new Employee(){Id=5,Name="emp5",Email="emp5@yahho.com",Department=DeptEnum.HR}
            };
        }


        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public Employee Update(Employee employee)
        {
            Employee emp = _employeeList.FirstOrDefault(e => e.Id == employee.Id);
            if (emp!=null)
            {
                emp.Name = employee.Name;
                emp.Email = employee.Email;
                emp.Department = employee.Department;
            }
            return emp; 
        }

        public Employee Delete(int id)
        {
            Employee emp = _employeeList.FirstOrDefault(e => e.Id == id);
            if(emp!=null)
            {
                _employeeList.Remove(emp);
            }
            return emp;
        }
    }
}
