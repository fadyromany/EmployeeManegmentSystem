using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManegmentSystem.Models
{
    public class EmployeeManegmentSystemDbContext : DbContext
    {
        public EmployeeManegmentSystemDbContext(DbContextOptions<EmployeeManegmentSystemDbContext> options)
            :base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
