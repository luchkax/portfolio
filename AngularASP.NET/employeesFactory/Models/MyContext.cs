using employeesFactory.Models;
using Microsoft.EntityFrameworkCore;

namespace employeesFactory
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Employee> Employees {get; set;}
        public DbSet<Company> Companies {get; set;}
    }
}