using EmployeeService.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Persistence
{
    internal class EmployeeServiceDbContext : DbContext, IEmployeeServiceDbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Unit> Units { get; set; }

        public EmployeeServiceDbContext(DbContextOptions<EmployeeServiceDbContext> contextOptions)
            : base(contextOptions) { }
    }
}
