using Employee18.models;
using Microsoft.EntityFrameworkCore;

namespace Employee18.Data
{
    public class EmployeeDB: DbContext
    {
        public EmployeeDB(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> employees { get; set; }
    }
}
