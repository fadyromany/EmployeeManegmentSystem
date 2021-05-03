using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManegmentSystem.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeManegmentSystemDbContext context;
        public SQLEmployeeRepository(EmployeeManegmentSystemDbContext context)
        {
            this.context = context;
        }
        public Employee Add(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee emp= context.Employees.Find(id);
            if(emp!=null)
            {
                context.Employees.Remove(emp);
                context.SaveChanges();

            }
            return emp;

        }

        public IEnumerable<Employee> GetAllEmployees()
        {
           return context.Employees;
        }

        public Employee GetEmployee(int Id)
        {
            return context.Employees.Find(Id);
        }

        public Employee Update(Employee employee)
        {
            var emp = context.Employees.Attach(employee);
            emp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return employee;
        }
    }
}
