using Microsoft.EntityFrameworkCore;


namespace Class01.Model
{
    public class EmployeeDbContext :DbContext
    {

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
        }

       public DbSet<Employee> EmployeeTable { get; set; }
    }
}
